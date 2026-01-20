using Newtonsoft.Json.Linq;
using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using SilkERP360.CCL.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;



namespace SilkERP360.BML.HRIS
{
    public class PromotionHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        CommonManager _commonManager = new CommonManager();
        bool sendSms = GlobalFlags.SendSms;
        bool sendMail = GlobalFlags.SendMail;

        public PromotionHistoryManager()
        {
            this.Initialize();

        }

        public ulong Save(CCL.BusinessEntities.HRIS.PromotionHistory promotionHistory)
        {
            if (!DateTime.TryParse(promotionHistory.EffectiveFrom, out DateTime effectiveDate))
                throw new ArgumentException("Invalid EffectiveFrom date.");

            if (promotionHistory.CurrentDesignationCode == promotionHistory.PreviousDesignationCode)
                throw new ArgumentException("Current Designation and New Designation cannot be same.");

            return this.ExceptionManager.Process<ulong>(() =>
            {
                using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (dbManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        dbManager.InternalResource.Open();

                    // Check duplicate promotion
                    string checkSql = $"SELECT COUNT(*) AS CNT FROM PROMOTION_HISTORY " +
                                      $"WHERE EMPLOYEE_CODE = {promotionHistory.EmployeeCode} " +
                                      $"AND TRUNC(EFFECTIVE_FROM) = TO_DATE('{effectiveDate:yyyy-MM-dd}', 'YYYY-MM-DD')";
                    var reader = dbManager.InternalResource.ExecuteDataReader(checkSql);
                    reader.Read();
                    int count = int.Parse(reader["CNT"].ToString());
                    reader.Close();

                    if (count > 0)
                        throw new Exception("A record already exists for the same employee and date.");

                    // Get next promotion sequence
                    string seqSql = $"SELECT {promotionHistory.GetSequence()}.NEXTVAL AS ID FROM DUAL";
                    var seqReader = dbManager.InternalResource.ExecuteDataReader(seqSql);
                    seqReader.Read();
                    ulong promotionId = ulong.Parse(seqReader["ID"].ToString());
                    seqReader.Close();

                    promotionHistory.PromotionID = promotionId;

                    // --- Save Increment if exists ---
                    if (promotionHistory.IP_obj_Increment != null)
                    {
                        var incrementManager = new SilkERP360.BML.HRIS.IncrementManager();
                        ulong incrementCode = incrementManager.Save(promotionHistory.IP_obj_Increment, dbManager.InternalResource, null);

                        // Set increment code in promotionHistory
                        promotionHistory.IP_obj_Increment.IncrementCode = incrementCode;
                        promotionHistory.IncrementCode = incrementCode;


                        // If Promotion table has a column for IncrementCode
                        // Make sure GenerateSqlInsert includes it, or manually add it:
                        promotionHistory.GenerateSqlInsert(); // Ensure IncrementCode is included
                    }

                    // Insert promotion history
                    string insertSql = promotionHistory.GenerateSqlInsert();
                    dbManager.InternalResource.ExecuteScalar(insertSql);

                    // Save approver details
                    if (promotionHistory.approverDetails != null && promotionHistory.approverDetails.Count > 0)
                    {
                        foreach (var approver in promotionHistory.approverDetails)
                        {
                            _commonManager.SaveApprover(approver, promotionId, dbManager.InternalResource);
                        }
                    }

                    dbManager.InternalResource.CommitTransaction();

                    List<UInt64> employeeCodes = promotionHistory.approverDetails
                                                         .Select(a => a.EmployeeCode)
                                                         .ToList();

                    // Send notifications
                    var employeeInfo = _commonManager.GetApproverInfo(employeeCodes);
                    string smsText = $"A promotion approval is pending for Employee ID {promotionHistory.EmployeeId}, Name {promotionHistory.EmployeeName}, for the designation {promotionHistory.CurentDesignationName}.";
                    SmsNotifier notifier = new SmsNotifier();
                    if (sendSms) _commonManager.SendSmsToApprovers(employeeInfo, smsText);
                    if (sendMail) SendMailToApprovers(employeeInfo, promotionHistory);

                    return promotionId;
                }
            }, "BMLExceptionPolicy");
        }


        private void SendMailToApprovers(Dictionary<string, List<string>> employeeInfo, PromotionHistory promotionHistory)
        {
            var mailNotifier = new SilkERP360.BML.Services.Mail.MailNotifier();
            string emailSubject = "Promotion Approval Pending-"+DateTime.Now.ToString();

            string mailTemplateUrl = _commonManager.mailTemplateUrl;

            foreach (var approver in employeeInfo)
            {
                var email = _commonManager.GetApproverEmail(approver);
                var employeeCode = _commonManager.GetEmployeeCode(approver);

                if (!string.IsNullOrWhiteSpace(email))
                {
                    string token = _commonManager.generateAndSaveToken(Convert.ToDateTime(promotionHistory.EffectiveFrom), promotionHistory.PromotionID, "Promotion");
                    string templateName = "Promotion"; // Template name (Promotion.html)

                    // ⭐ Generate URL with all required parameters
                    string url = $"{mailTemplateUrl}/Mail/Render?template={templateName}" +
                                 $"&PromotionId={promotionHistory.PromotionID}" +
                                 $"&Token={token}" +
                                 $"&EmployeeCode={employeeCode}" +
                                 $"&ApproverName={Uri.EscapeDataString(approver.Key)}" +
                                 $"&EmployeeName={Uri.EscapeDataString(promotionHistory.EmployeeName)}" +
                                 $"&EmployeeId={promotionHistory.EmployeeId}" +
                                 $"&OldDesignation={Uri.EscapeDataString(promotionHistory.PreviousDesignationName)}" +
                                 $"&NewDesignation={Uri.EscapeDataString(promotionHistory.CurentDesignationName)}" +
                                 $"&EffectiveFrom={promotionHistory.EffectiveFrom:dd-MMM-yyyy}" +
                                 $"&BaseUrl={Uri.EscapeDataString(_commonManager.hrmBaseUrl)}";

                    // ⭐ Email body with link
                    string emailBody = $"Dear {approver.Key},<br/><br/>" +
                                       $"A promotion request requires your approval. Please click the link below to view and approve/reject:<br/><br/>" +
                                       $"<a href='{url}'>Click here to approve/reject promotion</a><br/><br/>" +
                                       $"Regards,<br/>HR Department";

                    mailNotifier.SendEmail(email, emailSubject, emailBody);
                }
            }
        }

        public ulong UpdatePromotionStatusForApprover(UInt64 IP_ui64_PromotionHistoryCode, UInt64 IP_ui64_ApproverCode, int status, string token = null)
        {
            UInt64 lcl_ui64_approverDetailCode = 0;

            lcl_ui64_approverDetailCode = this.ExceptionManager.Process<UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Using string format for the query (be aware of SQL injection risks)
                    string lcl_str_SqlQuery = string.Format(
                        "SELECT ID as approver_id,status FROM promotion_approvers WHERE history_id = {0} AND employee_code = {1}", IP_ui64_PromotionHistoryCode, IP_ui64_ApproverCode);

                    var lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (lcl_obj_IDReader.Read() && lcl_obj_IDReader["approver_id"] != DBNull.Value)
                    {
                        int approverStatus = Convert.ToInt32(lcl_obj_IDReader["status"]);
                        if (approverStatus != (int)ApproveStatus.Pending)
                        {
                            throw new Exception("Approver status cannot be updated");
                        }

                        var approverId = Convert.ToUInt64(lcl_obj_IDReader["approver_id"]);
                        var detail = new ApproverDetail
                        {
                            Id = approverId,
                            HistoryId = IP_ui64_PromotionHistoryCode,
                            EmployeeCode = IP_ui64_ApproverCode,
                            Status = (UInt16)status,
                        };

                        // Generate and execute update statement
                        string updateSql = detail.GenerateSqlUpdate();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(updateSql);
                        lcl_ui64_approverDetailCode = approverId;
                        if (status == (int)ApproveStatus.Rejected)
                        {
                            RejectFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                        }

                        if (status == (int)ApproveStatus.Approved)
                        {
                            ApprovedFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                        }
                        
                        _commonManager.updateTokenStatus(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode, "Promotion");
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_approverDetailCode;
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_approverDetailCode;
        }

        public ulong ApprovedFinalPromotion(System.Object IP_obj_DBManager, ulong history_code)
        {
            return this.ExceptionManager.Process<ulong>(() =>
            {
                // Get the actual DBManager from the pooled object wrapper
                var dbManagerWrapper = (SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>)IP_obj_DBManager;
                var lcl_obj_DBManager = dbManagerWrapper.InternalResource;

                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                // Check all approvers status
                string checkSql = $@"SELECT COUNT(*) FROM promotion_approvers WHERE history_id = {history_code} AND status <> 2";

                var pendingCount = Convert.ToInt32(lcl_obj_DBManager.ExecuteScalar(checkSql));

                // If any row status is not 2 → do not update
                if (pendingCount > 0)
                {
                    // Some approvers are still pending or rejected
                    return 0;
                }

                string sql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)ApproveStatus.Approved} WHERE promotion_id = {history_code} and isapproved = {(int)ApproveStatus.Pending}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

                // 2️⃣ Update corresponding salary_increment_request → Approved (only if INCREMENT_CODE exists)
                string updateIncrementRequestSql = $@"
                    UPDATE salary_increment_request s
                    SET s.IS_APPROVED = {(int)ApproveStatus.Approved}
                    WHERE EXISTS (
                        SELECT 1
                        FROM promotion_history p
                        WHERE p.promotion_id = {history_code}
                          AND p.ISAPPROVED = {(int)ApproveStatus.Approved}
                          AND p.INCREMENT_CODE IS NOT NULL
                          AND p.INCREMENT_CODE = s.INCREMENT_CODE
                    )";

                lcl_obj_DBManager.ExecuteScalar(updateIncrementRequestSql);

                // Return the same id for confirmation
                return history_code;

            }, "BMLExceptionPolicy");
        }

        public ulong RejectFinalPromotion(System.Object IP_obj_DBManager, ulong history_code)
        {
            return this.ExceptionManager.Process<ulong>(() =>
            {
                // Get the actual DBManager from the pooled object wrapper
                var dbManagerWrapper = (SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>)IP_obj_DBManager;
                var lcl_obj_DBManager = dbManagerWrapper.InternalResource;

                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                string sql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)ApproveStatus.Rejected} WHERE promotion_id = {history_code} and ISAPPROVED = {(int)ApproveStatus.Pending}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

                // 2️⃣ Update corresponding salary_increment_request → Rejected (only if INCREMENT_CODE exists)
                string updateIncrementRequestSql = $@"
                    UPDATE salary_increment_request s
                    SET s.IS_APPROVED = {(int)ApproveStatus.Rejected}
                    WHERE EXISTS (
                        SELECT 1
                        FROM promotion_history p
                        WHERE p.promotion_id = {history_code}
                          AND p.ISAPPROVED = {(int)ApproveStatus.Rejected}
                          AND p.INCREMENT_CODE IS NOT NULL
                          AND p.INCREMENT_CODE = s.INCREMENT_CODE
                    )";

                lcl_obj_DBManager.ExecuteScalar(updateIncrementRequestSql);

                // Return the same id for confirmation
                return history_code;

            }, "BMLExceptionPolicy");
        }

        public List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> GetAllPromotionHistory(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr =
                           lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> list =
                            new List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>();

                        // If no rows → return empty list (not exception)
                        if (!lcl_obj_dr.HasRows)
                        {
                            return list;
                        }

                        // Populate list
                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory();

                            // Safe parsing
                            item.PromotionID = Convert.ToUInt64(lcl_obj_dr["promotion_id"]);
                            item.EmployeeCode = Convert.ToUInt64(lcl_obj_dr["EMPLOYEE_CODE"]);
                            item.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"]?.ToString();
                            item.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"]?.ToString();

                            item.PreviousDesignationCode = Convert.ToUInt64(lcl_obj_dr["PREVIOUS_DESIGNATION_CODE"]);
                            item.CurrentDesignationCode = Convert.ToUInt64(lcl_obj_dr["CURRENT_DESIGNATION_CODE"]);

                            item.PreviousDesignationName = lcl_obj_dr["PREVIOUSDESNAME"]?.ToString();
                            item.CurentDesignationName = lcl_obj_dr["CURRENTDESNAME"]?.ToString();
                            item.Remarks = lcl_obj_dr["REMARKS"]?.ToString();

                            // EffectiveFrom stored as string
                            item.EffectiveFrom = lcl_obj_dr["EFFECTIVE_FROM"]?.ToString();
                            item.IsApproved = Convert.ToInt16(lcl_obj_dr["ISAPPROVED"]);
                            item.UserSpecifcApprovalStatus = Convert.ToInt16(lcl_obj_dr["specificUserAppraval"]);
                            item.WithIncrement = Convert.ToString(lcl_obj_dr["IS_INCREMENTED"]);

                            list.Add(item);
                        }

                        return list;
                    }
                }
            }, "BMLExceptionPolicy");
        }

        public List<SilkERP360.CCL.BusinessEntities.HRIS.Notification> GetAllNotifications(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.Notification>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.Notification> lcl_obj_notificationList = new List<SilkERP360.CCL.BusinessEntities.HRIS.Notification>();

                        // If no rows → return empty list (not exception)
                        if (!lcl_obj_dr.HasRows)
                        {
                            return lcl_obj_notificationList;
                        }

                        // Populate list
                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.Notification();

                            item.EmployeeCode = Convert.ToInt64(lcl_obj_dr["Employee_Code"]);
                            item.EmployeeID = lcl_obj_dr["Employee_Id"]?.ToString();
                            item.EmployeeName = lcl_obj_dr["Employee_Name"]?.ToString();
                            item.ConfirmationDate = lcl_obj_dr["confirmation_date"]?.ToString();
                            item.JoiningDate = lcl_obj_dr["joining_date"]?.ToString();

                            lcl_obj_notificationList.Add(item);
                        }

                        return lcl_obj_notificationList;
                    }
                }
            }, "BMLExceptionPolicy");
        }


        public List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> GetAllApprovers(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr =
                           lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> list =
                            new List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail>();

                        // If no rows → return empty list (not exception)
                        if (!lcl_obj_dr.HasRows)
                        {
                            return list;
                        }

                        // Populate list
                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail();

                            // Safe parsing
                            item.EmployeeCode = Convert.ToUInt64(lcl_obj_dr["EMPLOYEE_CODE"]);
                            item.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"]?.ToString();
                            item.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"]?.ToString();

                            list.Add(item);
                        }

                        return list;
                    }
                }
            }, "BMLExceptionPolicy");
        }
        public int GetTokenStatus(string IP_str_SqlQuery)
        {
            int isValid = 0;
            return this.ExceptionManager.Process<int>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        if (lcl_obj_dr.Read())
                        {
                            return Convert.ToInt32(lcl_obj_dr["IS_VALID"]);
                        }
                        return isValid;
                    }
                }
            }, "BMLExceptionPolicy");
        }
    }
}