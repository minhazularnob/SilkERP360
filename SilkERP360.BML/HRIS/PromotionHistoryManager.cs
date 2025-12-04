using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;



namespace SilkERP360.BML.HRIS
{
    public class PromotionHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        string baseUrl = "http://localhost:4674"; // Replace with actual base URL
        CommonManager _commonManager = new CommonManager();

        public PromotionHistoryManager()
        {
            this.Initialize();

        }

        public ulong Save(CCL.BusinessEntities.HRIS.PromotionHistory promotionHistory)
        {
            var sendSms = false;
            var sendMail = false;

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

                    // Send notifications
                    var employeeInfo = GetApproverInfo(promotionHistory);
                    string smsText = $"A promotion approval is pending for Employee ID {promotionHistory.EmployeeId}, Name {promotionHistory.EmployeeName}, for the designation {promotionHistory.CurentDesignationName}.";
                    SmsNotifier notifier = new SmsNotifier();
                    if (sendSms) SendSmsToApprovers(employeeInfo, smsText);
                    if (sendMail) SendMailToApprovers(employeeInfo, promotionHistory);

                    return promotionId;
                }
            }, "BMLExceptionPolicy");
        }


        private void SendMailToApprovers(Dictionary<string, List<string>> employeeInfo, PromotionHistory promotionHistory)
        {
            var mailNotifier = new SilkERP360.BML.Services.Mail.MailNotifier();

            string serviceUrl = $"{baseUrl}/WebServices/HRIS/PromotionHistoryService.asmx";
            string emailSubject = "Promotion Approval Pending";

            foreach (var approver in employeeInfo)
            {
                var email = GetApproverEmail(approver);
                var employeeCode = GetEmployeeCode(approver);

                if (!string.IsNullOrWhiteSpace(email))
                {
                    string token = generateAndSaveToken(Convert.ToDateTime(promotionHistory.EffectiveFrom));
                    string emailBody = BuildEmailBody(promotionHistory, serviceUrl, employeeCode, token, approver.Key);
                    mailNotifier.SendEmail(email, emailSubject, emailBody);
                }
            }
        }

        private string generateAndSaveToken(DateTime effectiveFrom)
        {
            string token = Guid.NewGuid().ToString("N");

            string createdDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string expiryDate = effectiveFrom.ToString("yyyy-MM-dd HH:mm:ss");

            string sqlInsert = "INSERT INTO TOKENS (TOKEN_ID, CREATED_DATE, IS_VALID, EXPIRY_AT) VALUES" +
            " ('" + token + "', TO_TIMESTAMP('" + createdDate + "', 'YYYY-MM-DD HH24:MI:SS'), 1, TO_TIMESTAMP('" + expiryDate + "', 'YYYY-MM-DD HH24:MI:SS'))";

            using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
            {
                if (dbManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    dbManager.InternalResource.Open();

                dbManager.InternalResource.ExecuteNonQuery(sqlInsert);
                dbManager.InternalResource.CommitTransaction();
            }

            return token;
        }

        private string GetApproverEmail(KeyValuePair<string, List<string>> approver)
        {
            if (approver.Value.Count >= 3)  // Email is at index 2
                return approver.Value[2];
            return null;
        }

        private ulong GetEmployeeCode(KeyValuePair<string, List<string>> approver)
        {
            ulong employeeCode = 0;
            if (approver.Value.Count >= 4)  // Employee code is at index 3
            {
                ulong.TryParse(approver.Value[3], out employeeCode);
            }
            return employeeCode;
        }

        private Dictionary<string, List<string>> GetApproverInfo(PromotionHistory promotionHistory)
        {
            List<UInt64> employeeCodes = promotionHistory.approverDetails
                                                         .Select(a => a.EmployeeCode)
                                                         .ToList();

            Dictionary<string, List<string>> employeeInfo = new Dictionary<string, List<string>>();

            using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
            {
                if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.InternalResource.Open();
                }

                string IP_str_SqlQuery = $@"SELECT e.employee_code, e.employee_name, p.mobile_no, p.home_phone_no, p.email FROM employee e 
                                            INNER JOIN employee_personal p ON e.employee_code = p.employee_code
                                            WHERE e.employee_code IN ({string.Join(",", employeeCodes)})";

                using (System.Data.OracleClient.OracleDataReader lcl_obj_dr =
                       lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                {
                    while (lcl_obj_dr.Read())
                    {
                        string employeeName = lcl_obj_dr["employee_name"]?.ToString();
                        string mobile = lcl_obj_dr["mobile_no"]?.ToString();
                        string home = lcl_obj_dr["home_phone_no"]?.ToString();
                        string email = lcl_obj_dr["email"]?.ToString();
                        string employeeCode = Convert.ToString(lcl_obj_dr["employee_code"]);

                        employeeInfo[employeeName] = new List<string>()
                        {
                            mobile ?? "",        // index 0
                            home ?? "",          // index 1
                            email ?? "",         // index 2
                            employeeCode         // index 3
                        };
                    }
                }
            }
            return employeeInfo;
        }

        private string BuildEmailBody(PromotionHistory promotionHistory, string serviceUrl, ulong employeeCode, string token, string approverName)
        {
            string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                               "UI/MailTemplate/Promotion.html");

            string html = File.ReadAllText(templatePath);

            // ⭐ Safe EffectiveFrom formatting
            string effectiveFromFormatted = "";

            if (promotionHistory.EffectiveFrom != null)
            {
                if (DateTime.TryParse(Convert.ToString(promotionHistory.EffectiveFrom), out DateTime dt))
                {
                    effectiveFromFormatted = dt.ToString("dd-MMM-yyyy");
                }
            }

            // ⭐ All replacements
            html = html.Replace("{ApproverName}", approverName)
                       .Replace("{EmployeeName}", promotionHistory.EmployeeName)
                       .Replace("{EmployeeId}", promotionHistory.EmployeeId.ToString())
                       .Replace("{OldDesignation}", promotionHistory.PreviousDesignationName)
                       .Replace("{NewDesignation}", promotionHistory.CurentDesignationName)
                       .Replace("{EffectiveFrom}", effectiveFromFormatted)
                       .Replace("{EmployeeCode}", employeeCode.ToString())
                       .Replace("{Token}", token)
                       .Replace("{BaseUrl}", baseUrl)
                       .Replace("{PromotionId}", promotionHistory.PromotionID.ToString());

            return html;
        }

        private void SendSmsToApprovers(Dictionary<string, List<string>> employeeInfo, string messageText)
        {
            if (employeeInfo == null || employeeInfo.Count == 0)
                return;

            var messages = PrepareMessages(employeeInfo, messageText);

            if (messages.Count == 0)
                return;

            SmsNotifier smsNotifier = new SmsNotifier();
            smsNotifier.SendDynamicMessages(messages);
        }

        private List<DynamicMessage> PrepareMessages(Dictionary<string, List<string>> employeeInfo, string messageText)
        {
            var messages = new List<DynamicMessage>();

            foreach (var approver in employeeInfo)
            {
                string employeeName = approver.Key;
                foreach (var phone in approver.Value)
                {
                    if (string.IsNullOrWhiteSpace(phone))
                        continue;

                    messages.Add(FormatMessage(employeeName, phone, messageText));
                }
            }

            return messages;
        }

        private DynamicMessage FormatMessage(string employeeName, string phoneNumber, string messageText)
        {
            return new DynamicMessage
            {
                PhoneNumber = phoneNumber,
                Message = $"{employeeName}, {messageText}"
            };
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
                        "SELECT ID as approver_id,status FROM promotion_approvers WHERE history_id = {0} AND employee_code = {1}",
                        IP_ui64_PromotionHistoryCode,
                        IP_ui64_ApproverCode
                    );

                    var lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                    if (lcl_obj_IDReader.Read() && lcl_obj_IDReader["approver_id"] != DBNull.Value)
                    {
                        int approverStatus = Convert.ToInt32(lcl_obj_IDReader["status"]);
                        if (approverStatus != (int)PromotionStatus.Pending)
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
                        if (status == (int)PromotionStatus.Rejected)
                        {
                            RejectFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                        }

                        if (status == (int)PromotionStatus.Approved)
                        {
                            ApprovedFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                        }
                        if (token != null)
                        {
                            updateTokenStatus(lcl_obj_DBManager, token);
                        }
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_approverDetailCode;
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_approverDetailCode;
        }

        private string updateTokenStatus(System.Object IP_obj_DBManager, string token)
        {
            return this.ExceptionManager.Process<string>(() =>
            {
                // Get the actual DBManager from the pooled object wrapper
                var dbManagerWrapper = (SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>)IP_obj_DBManager;
                var lcl_obj_DBManager = dbManagerWrapper.InternalResource;

                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                string sql = $@"UPDATE TOKENS SET IS_VALID = 0 WHERE TOKEN_ID = '{token}'";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                return token;

            }, "BMLExceptionPolicy");

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

                string sql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)PromotionStatus.Approved} WHERE promotion_id = {history_code} and isapproved = {(int)PromotionStatus.Pending}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

                // 2️⃣ Update corresponding salary_increment_request → Approved (only if INCREMENT_CODE exists)
                string updateIncrementRequestSql = $@"
                    UPDATE salary_increment_request s
                    SET s.IS_APPROVED = {(int)PromotionStatus.Approved}
                    WHERE EXISTS (
                        SELECT 1
                        FROM promotion_history p
                        WHERE p.promotion_id = {history_code}
                          AND p.ISAPPROVED = {(int)PromotionStatus.Approved}
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

                string sql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)PromotionStatus.Rejected} WHERE promotion_id = {history_code} and ISAPPROVED = {(int)PromotionStatus.Pending}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

                // 2️⃣ Update corresponding salary_increment_request → Rejected (only if INCREMENT_CODE exists)
                string updateIncrementRequestSql = $@"
                    UPDATE salary_increment_request s
                    SET s.IS_APPROVED = {(int)PromotionStatus.Rejected}
                    WHERE EXISTS (
                        SELECT 1
                        FROM promotion_history p
                        WHERE p.promotion_id = {history_code}
                          AND p.ISAPPROVED = {(int)PromotionStatus.Rejected}
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
                    using (System.Data.OracleClient.OracleDataReader lcl_obj_dr =
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
                    using (System.Data.OracleClient.OracleDataReader lcl_obj_dr =
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

                    using (System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
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