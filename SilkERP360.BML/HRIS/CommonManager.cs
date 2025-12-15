using Oracle.ManagedDataAccess.Client;
using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Enums;
using SilkERP360.CCL.ModelClass;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class CommonManager
    {
        internal string hrmBaseUrl = "http://192.168.200.55"; // Replace with actual base URL
        internal string mailTemplateUrl = "http://192.168.200.55/mailTemplate/";

        internal void SaveApprover(ApproverDetail approver, ulong historyId, DBManager db)
        {
            string seqSql = $"SELECT {approver.GetSequence()}.NEXTVAL AS ID FROM DUAL";
            var seqReader = db.ExecuteDataReader(seqSql);

            seqReader.Read();
            ulong approverID = ulong.Parse(seqReader["ID"].ToString());
            seqReader.Close();

            approver.Id = approverID;
            approver.HistoryId = historyId;
            approver.Status = (int)ApproveStatus.Pending;

            string insertSql = approver.GenerateSqlInsert();
            db.ExecuteScalar(insertSql);
        }

        internal string generateAndSaveToken(DateTime effectiveFrom, UInt64 referenceCode, string type)
        {
            string token = Guid.NewGuid().ToString("N");

            using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
            {
                if (dbManager.InternalResource.ConnectionState != ConnectionState.Open)
                    dbManager.InternalResource.Open();

                string sqlInsert = @"
            INSERT INTO TOKENS (TOKEN_ID, CREATED_DATE, IS_VALID, EXPIRY_AT, reference_code, type)
            VALUES (:TOKEN_ID, :CREATED_DATE, 1, :EXPIRY_AT, :reference_code, :type)";

                using (OracleCommand cmd = new OracleCommand(sqlInsert,
                    (OracleConnection)dbManager.InternalResource.Connection))
                {
                    // Parameters add (Types automatically detected)
                    cmd.Parameters.Add(new OracleParameter("TOKEN_ID", token));
                    cmd.Parameters.Add(new OracleParameter("CREATED_DATE", DateTime.Now));
                    cmd.Parameters.Add(new OracleParameter("EXPIRY_AT", effectiveFrom));
                    cmd.Parameters.Add(new OracleParameter("reference_code", Convert.ToInt64(referenceCode)));
                    cmd.Parameters.Add(new OracleParameter("type", type));


                    // Execute query
                    cmd.ExecuteNonQuery();
                }

                dbManager.InternalResource.CommitTransaction();
            }

            return token;
        }

        internal string GetApproverEmail(KeyValuePair<string, List<string>> approver)
        {
            if (approver.Value.Count >= 3)  // Email is at index 2
                return approver.Value[2];
            return null;
        }

        internal ulong GetEmployeeCode(KeyValuePair<string, List<string>> approver)
        {
            ulong employeeCode = 0;
            if (approver.Value.Count >= 4)  // Employee code is at index 3
            {
                ulong.TryParse(approver.Value[3], out employeeCode);
            }
            return employeeCode;
        }

        internal void SendSmsToApprovers(Dictionary<string, List<string>> employeeInfo, string messageText)
        {
            if (employeeInfo == null || employeeInfo.Count == 0)
                return;

            var messages = PrepareMessages(employeeInfo, messageText);

            if (messages.Count == 0)
                return;

            SmsNotifier smsNotifier = new SmsNotifier();
            smsNotifier.SendDynamicMessages(messages);
        }

        internal List<DynamicMessage> PrepareMessages(Dictionary<string, List<string>> employeeInfo, string messageText)
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

        internal DynamicMessage FormatMessage(string employeeName, string phoneNumber, string messageText)
        {
            return new DynamicMessage
            {
                PhoneNumber = phoneNumber,
                Message = $"{employeeName}, {messageText}"
            };
        }

        internal Dictionary<string, List<string>> GetApproverInfo(List<UInt64> employeeCodes)
        {
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

                using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr =
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

        internal UInt64 updateTokenStatus(object IP_obj_DBManager, UInt64 referenceCode, string type)
        {
            var dbManager = ((SilkERP360.CCL.ObjectPool.PooledObjectWrapper<SilkERP360.DAL.DBManager>)IP_obj_DBManager).InternalResource;
            if (dbManager.ConnectionState != System.Data.ConnectionState.Open)
                dbManager.Open();

            using (var cmd = new OracleCommand { Connection = (OracleConnection)dbManager.Connection })
            {

                cmd.CommandText = @"UPDATE TOKENS SET IS_VALID = 0 
                                WHERE reference_code = :reference_code AND type = :type";
                cmd.Parameters.Add("reference_code", OracleDbType.Decimal).Value = (decimal)referenceCode;
                cmd.Parameters.Add("type", OracleDbType.Varchar2).Value = type;
                cmd.ExecuteNonQuery();
            }

            dbManager.CommitTransaction();
            return referenceCode;
        }
    }
}