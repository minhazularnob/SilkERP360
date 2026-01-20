using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.BusinessEntities.WPMS;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using SilkERP360.CCL.Utils;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class IncrementManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        CommonManager _commonManager = new CommonManager();
        bool sendSms = GlobalFlags.SendSms;
        bool sendMail = GlobalFlags.SendMail;



        public IncrementManager( CommonManager commonManager = null)
        {
           this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.IncrementRequest IP_obj_Increment_Request , object IP_obj_DBManager, List<ApproverDetail> IP_obj_ApproverDetails = null)
        {
            //var sendSms = false;
            //var sendMail = true;

            System.UInt64 lcl_ui64_IncrementCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Increment_Request.GetSequence());
            lcl_ui64_IncrementCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                lcl_obj_IDReader.Read();
                System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                lcl_obj_IDReader.Close();

                IP_obj_Increment_Request.IncrementCode = lcl_ui64_ID;
                IP_obj_Increment_Request.IsApproved = (int)ApproveStatus.Pending;

                // Save approver details
                if (IP_obj_ApproverDetails != null && IP_obj_ApproverDetails.Count > 0)
                {
                    foreach (var approver in IP_obj_ApproverDetails)
                    {
                        _commonManager.SaveApprover(approver, lcl_ui64_ID, lcl_obj_DBManager);
                    }
                }

                System.String lcl_str_SqlInsert = IP_obj_Increment_Request.GenerateSqlInsert();
                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlInsert);


                // Send notifications
                var empInfo = GetEmployeeInfo(IP_obj_Increment_Request.EmployeeCode, IP_obj_DBManager);

                IP_obj_Increment_Request.EmployeeId = empInfo.EmployeeId;
                IP_obj_Increment_Request.EmployeeName = empInfo.EmployeeName;


                if(IP_obj_ApproverDetails != null)
                {
                    List<UInt64> employeeCodes = IP_obj_ApproverDetails.Select(a => a.EmployeeCode).ToList();

                    var employeeInfo = _commonManager.GetApproverInfo(employeeCodes);
                    string smsText = $"Increment approval is pending for Employee ID: {empInfo.EmployeeId}, Name: {empInfo.EmployeeName}. Previous Gross: {IP_obj_Increment_Request.PreviousGross}, Proposed Gross: {IP_obj_Increment_Request.IncGross}.";
                    SmsNotifier notifier = new SmsNotifier();
                    if (sendSms) _commonManager.SendSmsToApprovers(employeeInfo, smsText);
                    if (sendMail) SendMailToApprovers(employeeInfo, IP_obj_Increment_Request);
                }

                return lcl_ui64_ID;
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        private void SendMailToApprovers(Dictionary<string, List<string>> employeeInfo, IncrementRequest incrementRequest)
        {
            var mailNotifier = new SilkERP360.BML.Services.Mail.MailNotifier();
            string emailSubject = "Increment Approval Pending-"+ DateTime.Now.ToString();

            string mailTemplateUrl = _commonManager.mailTemplateUrl;


            foreach (var approver in employeeInfo)
            {
                var email = _commonManager.GetApproverEmail(approver);
                var employeeCode = _commonManager.GetEmployeeCode(approver);

                if (!string.IsNullOrWhiteSpace(email))
                {
                    int month = Convert.ToInt32(incrementRequest.EffectiveMonth);
                    int year = Convert.ToInt32(incrementRequest.EffectiveYear);

                    string token = _commonManager.generateAndSaveToken(new DateTime(year, month, 1), incrementRequest.IncrementCode, "Increment");

                    string templateName = "Increment"; // Increment.html

                    // Generate link to new MailTemplateService
                    string url = $"{mailTemplateUrl}/Mail/Render?template={templateName}" +
                                 $"&IncrementCode={incrementRequest.IncrementCode}" +
                                 $"&EmployeeCode={employeeCode}" +
                                 $"&Token={token}" +
                                 $"&ApproverName={Uri.EscapeDataString(approver.Key)}" +
                                 $"&EmployeeName={Uri.EscapeDataString(incrementRequest.EmployeeName)}" +
                                 $"&EmployeeId={incrementRequest.EmployeeId}" +
                                 $"&PreviousGross={incrementRequest.PreviousGross}" +
                                 $"&ProposedGross={incrementRequest.IncGross}" +
                                 $"&EffectiveFrom={Uri.EscapeDataString(new DateTime(year, month, 1).ToString("dd-MMM-yyyy"))}" +
                                 $"&BaseUrl={Uri.EscapeDataString(_commonManager.hrmBaseUrl)}";

                    string emailBody = $"Dear {approver.Key},<br/><br/>" +
                                       $"An increment request requires your approval. Please click the link below to view and approve/reject:<br/><br/>" +
                                       $"<a href='{url}'>Click here to approve/reject increment</a><br/><br/>" +
                                       $"Regards,<br/>HR Department";

                    mailNotifier.SendEmail(email, emailSubject, emailBody);
                }
            }
        }

        private CCL.BusinessEntities.HRIS.IncrementRequest GetEmployeeInfo(UInt64 employeeCode, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.IncrementRequest lcl_obj_Increment = null;

            lcl_obj_Increment = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.IncrementRequest>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;

                // Open connection if not already open
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }

                System.String lcl_str_SqlQuery = System.String.Format("SELECT e.employee_id, e.employee_code, e.employee_name FROM employee e INNER JOIN employee_personal ep ON e.employee_code = ep.employee_code WHERE e.EMPLOYEE_CODE = {0}", employeeCode);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.IncrementRequest lcl_obj_IncrementTmp = new CCL.BusinessEntities.HRIS.IncrementRequest();
                lcl_obj_IncrementTmp.EmployeeName = lcl_obj_dr["employee_name"].ToString();
                lcl_obj_IncrementTmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_IncrementTmp.EmployeeId = lcl_obj_dr["employee_id"].ToString();


                return lcl_obj_IncrementTmp;
            }, "BMLExceptionPolicy");

            return lcl_obj_Increment;
        }

        public ulong Save(CCL.BusinessEntities.HRIS.IncrementRequest IP_obj_Increment)
        {
            System.UInt64 lcl_ui64_IncrementCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", IP_obj_Increment.GetSequence());
            lcl_ui64_IncrementCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    IP_obj_Increment.IncrementCode = lcl_ui64_ID;
                    System.String lcl_str_SqlInsert = IP_obj_Increment.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(ulong IP_ui64_Code, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_INCREMENT WHERE INCREMENT_CODE = {0}", IP_ui64_Code);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                
                lcl_obj_dr.Close();
                return lcl_obj_TmpIncrement;
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(ulong IP_ui64_Code)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.String lcl_str_SqlQuery = System.String.Format("Select * From SALARY_INCREMENT WHERE INCREMENT_CODE = {0}", IP_ui64_Code);
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    if (lcl_obj_dr.HasRows == false)
                    {
                        return null;
                    }
                    lcl_obj_dr.Read();
                    CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                    lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementMasterCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_MASTER_CODE"].ToString());
                    lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    //lcl_obj_TmpIncrement.IncrementDate = System.DateTime.Parse(lcl_obj_dr["INCREMENT_DATE"].ToString());
                    lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                    lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                    lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                    lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                    lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                    lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                    lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                    //lcl_obj_TmpIncrement.EntryDate = System.DateTime.Parse(lcl_obj_dr["ENTRY_DATE"].ToString());
                    lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpIncrement;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.String lcl_str_SqlQuery = System.String.Format(IP_str_SqlQuery);
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(lcl_str_SqlQuery);
                if (lcl_obj_dr.HasRows == false)
                {
                    return null;
                }
                lcl_obj_dr.Read();
                SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new SilkERP360.CCL.BusinessEntities.HRIS.Increment();
                lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                lcl_obj_dr.Close();
                return lcl_obj_TmpIncrement;
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public CCL.BusinessEntities.HRIS.Increment Get(string IP_str_SqlQuery)
        {
            CCL.BusinessEntities.HRIS.Increment lcl_obj_Increment = null;
            lcl_obj_Increment = this.ExceptionManager.Process<SilkERP360.CCL.BusinessEntities.HRIS.Increment>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return null;
                    }
                    SilkERP360.CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new SilkERP360.CCL.BusinessEntities.HRIS.Increment();
                    lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                    lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                    lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                    lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                    lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                    lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                    lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                    lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                    lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_dr.Close();
                    return lcl_obj_TmpIncrement;
                }
            }, "BMLExceptionPolicy");
            return lcl_obj_Increment;
        }

        public ulong UpdateIncrementStatusForApprover(UInt64 IP_ui64_incrementCode, UInt64 IP_ui64_ApproverCode, int status, string token = null)
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
                        IP_ui64_incrementCode,
                        IP_ui64_ApproverCode
                    );

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
                            HistoryId = IP_ui64_incrementCode,
                            EmployeeCode = IP_ui64_ApproverCode,
                            Status = (UInt16)status,
                        };

                        // Generate and execute update statement
                        string updateSql = detail.GenerateSqlUpdate();
                        lcl_obj_DBManager.InternalResource.ExecuteScalar(updateSql);
                        lcl_ui64_approverDetailCode = approverId;
                        if (status == (int)ApproveStatus.Rejected)
                        {
                            RejectFinalIncrement(lcl_obj_DBManager, IP_ui64_incrementCode);
                        }

                        if (status == (int)ApproveStatus.Approved)
                        {
                            ApprovedFinalIncrement(lcl_obj_DBManager, IP_ui64_incrementCode);
                        }
                        _commonManager.updateTokenStatus(lcl_obj_DBManager, IP_ui64_incrementCode, "Increment");
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_approverDetailCode;
                }
            }, "BMLExceptionPolicy");

            return lcl_ui64_approverDetailCode;
        }
        

        public ulong ApprovedFinalIncrement(System.Object IP_obj_DBManager, ulong history_code)
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

                string sql = $@"UPDATE salary_increment_request SET IS_APPROVED = {(int)ApproveStatus.Approved} WHERE increment_code = {history_code} and is_approved = {(int)ApproveStatus.Pending}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

                // Return the same id for confirmation
                return history_code;

            }, "BMLExceptionPolicy");
        }

        public ulong RejectFinalIncrement(System.Object IP_obj_DBManager, ulong history_code)
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

                string sql = $@"UPDATE salary_increment_request SET IS_APPROVED = {(int)ApproveStatus.Rejected} WHERE increment_code = {history_code} and IS_APPROVED = {(int)ApproveStatus.Pending}";
                System.String lcl_str_SqlQuery = System.String.Format(sql);

                lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);

                // Return the same id for confirmation
                return history_code;

            }, "BMLExceptionPolicy");
        }


        public List<CCL.BusinessEntities.HRIS.Increment> GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_IncrementList = null;
            lcl_objlist_IncrementList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>>(() =>
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                {
                    lcl_obj_DBManager.Open();
                }
                System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_TmpIncrementList = new
                   System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>();
                Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                if (!(lcl_obj_dr.HasRows))
                {
                    return lcl_objlist_TmpIncrementList;
                }

                while (lcl_obj_dr.Read())
                {
                    CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                    lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                    lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.PreviousGross = System.Decimal.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                    lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                    lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                    lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                    lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                    lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                    lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                    lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                    lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                    lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                    lcl_obj_TmpIncrement.IsApproved = System.Int16.Parse(lcl_obj_dr["IS_APPROVED"].ToString());
                    lcl_obj_TmpIncrement.UserSpecifcApprovalStatus = Convert.ToInt16(lcl_obj_dr["specificUserAppraval"]);

                    lcl_objlist_TmpIncrementList.Add(lcl_obj_TmpIncrement);
                }
                lcl_obj_dr.Close();
                return lcl_objlist_TmpIncrementList;
            }, "BMLExceptionPolicy");
            return lcl_objlist_IncrementList;
        }

        public List<CCL.BusinessEntities.HRIS.Increment> GetList(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_IncrementList = null;
            lcl_objlist_IncrementList = this.ExceptionManager.Process<System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment> lcl_objlist_TmpIncrementList = new
                    System.Collections.Generic.List<CCL.BusinessEntities.HRIS.Increment>();
                    Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery);
                    if (!(lcl_obj_dr.HasRows))
                    {
                        return lcl_objlist_TmpIncrementList;
                    }

                    while (lcl_obj_dr.Read())
                    {
                        CCL.BusinessEntities.HRIS.Increment lcl_obj_TmpIncrement = new CCL.BusinessEntities.HRIS.Increment();
                        lcl_obj_TmpIncrement.IncrementCode = System.UInt64.Parse(lcl_obj_dr["INCREMENT_CODE"].ToString());
                        lcl_obj_TmpIncrement.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpIncrement.PreviousGross = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_GROSS"].ToString());
                        lcl_obj_TmpIncrement.IncBasic = System.Decimal.Parse(lcl_obj_dr["INC_BASIC"].ToString());
                        lcl_obj_TmpIncrement.IncHouseRent = System.Decimal.Parse(lcl_obj_dr["INC_HOURSE_RENT"].ToString());
                        lcl_obj_TmpIncrement.IncConveyence = System.Decimal.Parse(lcl_obj_dr["INC_CONVEYENCE"].ToString());
                        lcl_obj_TmpIncrement.IncMedical = System.Decimal.Parse(lcl_obj_dr["INC_MEDICAL"].ToString());
                        lcl_obj_TmpIncrement.IncEntertainment = System.Decimal.Parse(lcl_obj_dr["INC_ENTERTAINMENT"].ToString());
                        lcl_obj_TmpIncrement.IncGross = System.Decimal.Parse(lcl_obj_dr["INC_GROSS"].ToString());
                        lcl_obj_TmpIncrement.EntryEmployeeCode = System.UInt64.Parse(lcl_obj_dr["ENTRY_EMPLOYEE_CODE"].ToString());
                        lcl_obj_TmpIncrement.EffectiveMonth = (SilkERP360.CCL.Enums.Month)System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_MONTH"].ToString());
                        lcl_obj_TmpIncrement.EffectiveYear = System.UInt32.Parse(lcl_obj_dr["EFFECTIVE_YEAR"].ToString());
                        lcl_objlist_TmpIncrementList.Add(lcl_obj_TmpIncrement);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_TmpIncrementList;

                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_IncrementList;
        }
    }
}