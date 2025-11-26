using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using SilkERP360.CCL.Validation;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;



namespace SilkERP360.BML.HRIS
{
   public class PromotionHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase


    {
       public PromotionHistoryManager()
       {
           //ExceptionManagement Initialization
           this.Initialize();
       }

        public ulong Save(CCL.BusinessEntities.HRIS.PromotionHistory promotionHistory)
        {
            if (!DateTime.TryParse(promotionHistory.EffectiveFrom, out DateTime effectiveDate))
                throw new ArgumentException("Invalid EffectiveFrom date.");

            if(promotionHistory.CurrentDesignationCode == promotionHistory.PreviousDesignationCode)
                throw new ArgumentException("Current Designation  and New Designation cannot be same.");

            return this.ExceptionManager.Process<ulong>(() =>
            {
                using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (dbManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        dbManager.InternalResource.Open();

                    // Check for duplicate promotion for the same employee on the same date
                    string checkSql = $"SELECT COUNT(*) AS CNT FROM PROMOTION_HISTORY " +
                                      $"WHERE EMPLOYEE_CODE = {promotionHistory.EmployeeCode} " +
                                      $"AND TRUNC(EFFECTIVE_FROM) = TO_DATE('{effectiveDate:yyyy-MM-dd}', 'YYYY-MM-DD')";

                    var reader = dbManager.InternalResource.ExecuteDataReader(checkSql);
                    reader.Read();
                    int count = int.Parse(reader["CNT"].ToString());
                    reader.Close();


                    if (count > 0)
                        throw new Exception("A record already exists for the same employee and date.");

                    // Get next sequence value
                    string seqSql = $"SELECT {promotionHistory.GetSequence()}.NEXTVAL AS ID FROM DUAL";
                    var seqReader = dbManager.InternalResource.ExecuteDataReader(seqSql);
                    seqReader.Read();
                    ulong promotionId = ulong.Parse(seqReader["ID"].ToString());
                    seqReader.Close();

                    promotionHistory.PromotionID = promotionId;

                    // Insert promotion history
                    string insertSql = promotionHistory.GenerateSqlInsert();
                    dbManager.InternalResource.ExecuteScalar(insertSql);

                    // Save approver details
                    if (promotionHistory.approverDetails != null && promotionHistory.approverDetails.Count > 0)
                    {
                        foreach (var approver in promotionHistory.approverDetails)
                        {
                            // Get next sequence value for approver
                            string seqSqlApprover = $"SELECT {approver.GetSequence()}.NEXTVAL AS ID FROM DUAL";
                            var seqReaderApprover = dbManager.InternalResource.ExecuteDataReader(seqSqlApprover);
                            seqReaderApprover.Read();
                            ulong approverID = ulong.Parse(seqReaderApprover["ID"].ToString());
                            seqReaderApprover.Close();

                            // Set approver properties
                            approver.Id = approverID;
                            approver.HistoryId = promotionId;
                            approver.Status = (int)PromotionStatus.Pending;

                            // Generate and execute insert SQL
                            string approverSql = approver.GenerateSqlInsert();
                            dbManager.InternalResource.ExecuteScalar(approverSql);
                        }
                    }

                    dbManager.InternalResource.CommitTransaction();

                    // Send SMS notifications to approvers
                    var employeeInfo = GetApproverInfo(promotionHistory);

                    string smsText = string.Format(
                        "A promotion approval is pending for Employee ID {0}, Name {1}, for the designation {2}.",
                        promotionHistory.EmployeeId,
                        promotionHistory.EmployeeName,
                        promotionHistory.CurentDesignationName
                    );

                    SmsNotifier notifier = new SmsNotifier();
                    var sendSms = false;
                    var sendMail = true;
                    if (sendSms)
                    SendSmsToApprovers(employeeInfo, smsText);
                    if(sendMail)
                    SendMailToApprovers(employeeInfo, promotionHistory);

                    return promotionId;
                }
            }, "BMLExceptionPolicy");
        }

        private void SendMailToApprovers(Dictionary<string, List<string>> employeeInfo, PromotionHistory promotionHistory)
        {
            var mailNotifier = new SilkERP360.Notifications.MailNotifier();
            string baseUrl = "http://localhost:4674"; // Local development URL
            string serviceUrl = $"{baseUrl}/WebServices/HRIS/PromotionHistoryService.asmx";
            string emailSubject = "Promotion Approval Pending";

            foreach (var approver in employeeInfo)
            {
                var email = GetApproverEmail(approver);
                var employeeCode = GetEmployeeCode(approver);

                if (!string.IsNullOrWhiteSpace(email))
                {
                    string emailBody = BuildEmailBody(promotionHistory, serviceUrl, employeeCode);
                    mailNotifier.SendEmail(email, emailSubject, emailBody);
                }
            }
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

        private string BuildEmailBody(PromotionHistory promotionHistory, string serviceUrl, ulong employeeCode)
        {
            return $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <div style='background-color: #f8f9fa; padding: 20px; text-align: center; border-bottom: 1px solid #e9ecef;'>
                            <h2>Promotion Approval Request</h2>
                        </div>

                        <div style='padding: 20px;'>
                            <p>Dear Approver,</p>
                            <p>A promotion request requires your approval:</p>

                            <table style='width: 100%; border-collapse: collapse; margin: 15px 0;'>
                                <tr>
                                    <td style='padding: 8px; border: 1px solid #dee2e6;'><strong>Employee:</strong></td>
                                    <td style='padding: 8px; border: 1px solid #dee2e6;'>{promotionHistory.EmployeeName}</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px; border: 1px solid #dee2e6;'><strong>New Designation:</strong></td>
                                    <td style='padding: 8px; border: 1px solid #dee2e6;'>{promotionHistory.CurentDesignationName}</td>
                                </tr>
                                <tr>
                                    <td style='padding: 8px; border: 1px solid #dee2e6;'><strong>Effective From:</strong></td>
                                    <td style='padding: 8px; border: 1px solid #dee2e6;'>{promotionHistory.EffectiveFrom}</td>
                                </tr>
                            </table>

                            <p>Please click one of the buttons below to take action:</p>

                            <div style='text-align: center; margin: 25px 0;'>
                                <form method='post' action='{serviceUrl}/UpdatePromotionStatusForApproverFromMail' style='display: inline; margin: 5px;'>
                                    <input type='hidden' name='IP_ui64_PromotionHistoryCode' value={promotionHistory.PromotionID}>
                                    <input type='hidden' name='status' value='{(int)PromotionStatus.Approved}'>
                                    <input type='hidden' name='employeeCode' value='{employeeCode}'>
                                    <button type='submit' style='background-color: #4CAF50; color: white; padding: 12px 25px; border: none; border-radius: 4px; cursor: pointer;'>
                                        Approve
                                    </button>
                                </form>

                                <form method='post' action='{serviceUrl}/UpdatePromotionStatusForApproverFromMail' style='display: inline; margin: 5px;'>
                                    <input type='hidden' name='IP_ui64_PromotionHistoryCode' value={promotionHistory.PromotionID}>
                                    <input type='hidden' name='status' value='{(int)PromotionStatus.Rejected}'>
                                    <input type='hidden' name='employeeCode' value='{employeeCode}'>
                                    <button type='submit' style='background-color: #f44336; color: white; padding: 12px 25px; border: none; border-radius: 4px; cursor: pointer;'>
                                        Reject
                                    </button>
                                </form>
                            </div>
                        </div>

                        <div style='background-color: #f8f9fa; padding: 10px; text-align: center; font-size: 12px; color: #6c757d; border-top: 1px solid #e9ecef;'>
                            <p>This is an automated message. Please do not reply to this email.</p>
                        </div>
                    </div>";
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
                        UInt64 employeeCode = Convert.ToUInt64(lcl_obj_dr["employee_code"]);

                        // Create list if new employee
                        if (!employeeInfo.ContainsKey(employeeName))
                        {
                            employeeInfo[employeeName] = new List<string>();
                        }

                        // Add mobile if exists
                        if (!string.IsNullOrWhiteSpace(mobile) &&
                            !employeeInfo[employeeName].Contains(mobile))
                        {
                            employeeInfo[employeeName].Add(mobile);
                        }

                        // Add home phone if exists
                        if (!string.IsNullOrWhiteSpace(home) &&
                            !employeeInfo[employeeName].Contains(home))
                        {
                            employeeInfo[employeeName].Add(home);
                        }
                        // Add email if exists
                        if (!string.IsNullOrWhiteSpace(email) &&
                            !employeeInfo[employeeName].Contains(email))
                        {
                            employeeInfo[employeeName].Add(email);
                        }
                        // Add employeeCode if exists
                        employeeInfo[employeeName].Add(Convert.ToString(employeeCode));
                    }
                }
            }
            return employeeInfo;
        }


        public ulong UpdatePromotionStatusForApprover(UInt64 IP_ui64_PromotionHistoryCode, UInt64 IP_ui64_ApproverCode, int status)
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
                            "SELECT ID as approver_id FROM promotion_approvers WHERE history_id = {0} AND employee_code = {1}",
                            IP_ui64_PromotionHistoryCode,
                            IP_ui64_ApproverCode
                        );

                        var lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);

                        if (lcl_obj_IDReader.Read() && lcl_obj_IDReader["approver_id"] != DBNull.Value)
                        {
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
                            if(status == (int)PromotionStatus.Rejected)
                            {
                                RejectFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                            }

                            if(status == (int)PromotionStatus.Approved)
                            {
                                ApprovedFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                            }
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

                string sql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)PromotionStatus.Approved} WHERE promotion_id = {history_code}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

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

                string sql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)PromotionStatus.Rejected} WHERE promotion_id = {history_code}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

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
                            item.UserSpecifcApprovalStatus =Convert.ToInt16(lcl_obj_dr["specificUserAppraval"]);

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
    }
}
