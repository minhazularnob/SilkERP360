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
using System.IO;
using System.Linq;
using System.Text;



namespace SilkERP360.BML.HRIS
{
   public class PromotionHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase


    {
        string baseUrl = "http://localhost:4674";
        public PromotionHistoryManager()
        {
            this.Initialize();
        }

        public ulong Save(CCL.BusinessEntities.HRIS.PromotionHistory promotionHistory)
        {
            var sendSms = false;
            var sendMail = true;

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



        //        private string BuildEmailBody(PromotionHistory promotionHistory, string serviceUrl, ulong employeeCode, string token, string approverName)
        //        {
        //            return $@"<!DOCTYPE html>
        //                        <html lang=""en"">
        //                        <head>
        //                            <meta charset=""UTF-8"">
        //                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
        //                            <title>Promotion Approval Request</title>

        //                            <style>
        //                                body {{
        //                                    font-family: 'Segoe UI', Tahoma, sans-serif;
        //                                    background: #f2f4f6;
        //                                    margin: 0;
        //                                    padding: 20px;
        //                                    display: flex;
        //                                    justify-content: center;
        //                                }}

        //                                .wrapper {{
        //                                    width: 100%;
        //                                    max-width: 700px;
        //                                    background: #fff;
        //                                    border-radius: 8px;
        //                                    overflow: hidden;
        //                                    box-shadow: 0 0 10px rgba(0,0,0,0.08);
        //                                }}

        //                                .header {{
        //                                    background-color: #2c3e50;
        //                                    color: white;
        //                                    padding: 20px;
        //                                    text-align: center;
        //                                }}

        //                                .content {{
        //                                    padding: 25px;
        //                                }}

        //                                .promotion-details {{
        //                                    width: 100%;
        //                                    border-collapse: collapse;
        //                                    margin-top: 20px;
        //                                }}

        //                                .promotion-details th,
        //                                .promotion-details td {{
        //                                    text-align: left;
        //                                    padding: 12px;
        //                                    border-bottom: 1px solid #e3e3e3;
        //                                }}

        //                                .promotion-details th {{
        //                                    width: 35%;
        //                                    background: #f7f7f7;
        //                                }}

        //                                .login-box {{
        //                                    margin: 25px auto;
        //                                    width: 100%;
        //                                    max-width: 350px;
        //                                    padding: 20px;
        //                                    background: #f7f9fc;
        //                                    border-radius: 8px;
        //                                    border: 1px solid #e2e2e2;
        //                                }}

        //                                .login-box h3 {{
        //                                    text-align: center;
        //                                    margin-top: 0;
        //                                    color: #333;
        //                                }}

        //                                .login-box input {{
        //                                    width: 100%;
        //                                    padding: 10px;
        //                                    margin: 6px 0 15px 0;
        //                                    border: 1px solid #d1d1d1;
        //                                    border-radius: 5px;
        //                                }}

        //                                .login-box button {{
        //                                    width: 100%;
        //                                    padding: 10px;
        //                                    background: #0069d9;
        //                                    border: none;
        //                                    color: #fff;
        //                                    font-size: 15px;
        //                                    border-radius: 5px;
        //                                    cursor: pointer;
        //                                }}

        //                                .action-buttons {{
        //                                    margin-top: 35px;
        //                                    text-align: center;
        //                                }}

        //                                .btn {{
        //                                    display: inline-block;
        //                                    padding: 12px 25px;
        //                                    margin: 0 10px;
        //                                    border-radius: 4px;
        //                                    text-decoration: none;
        //                                    font-weight: 500;
        //                                    color: #fff;
        //                                    transition: 0.3s;
        //                                }}

        //                                .btn-approve {{
        //                                    background: #28a745;
        //                                }}

        //                                .btn-reject {{
        //                                    background: #dc3545;
        //                                }}

        //                                .btn:hover {{
        //                                    opacity: 0.9;
        //                                }}

        //                                .footer {{
        //                                    padding: 15px;
        //                                    text-align: center;
        //                                    background: #f1f1f1;
        //                                    font-size: 12px;
        //                                    color: #666;
        //                                }}
        //                            </style>
        //                        </head>

        //                        <body>
        //                        <div id=""tokenExpiredDiv"" 
        //                        style=""display:none; 
        //                                padding:20px; 
        //                                margin-top:20px; 
        //                                border:1px solid #dc3545; 
        //                                background:#ffe6e6; 
        //                                color:#b30000; 
        //                                border-radius:5px;"">
        //                        <h3>Token Expired</h3>
        //                        <p>Your approval link has expired. Please contact HR for a new link.</p>
        //                        </div>

        //                        <div class=""wrapper"" id=""wrapperId"">

        //                            <div class=""header"">
        //                                <h2>Promotion Approval Request</h2>
        //                            </div>

        //                            <div class=""content"">

        //                                <p>Dear {approverName},</p>
        //                                <p>A promotion request requires your approval. Details are given below:</p>

        //                                <table class=""promotion-details"">
        //                                    <tr><th>Employee Name</th> <td>{promotionHistory.EmployeeName}</td></tr>
        //                                    <tr><th>Employee ID</th> <td>{promotionHistory.EmployeeId}</td></tr>
        //                                    <tr><th>Current Designation</th> <td>{promotionHistory.PreviousDesignationName}</td></tr>
        //                                    <tr><th>New Designation</th> <td>{promotionHistory.CurentDesignationName}</td></tr>
        //                                    <tr><th>Effective From</th> <td>{promotionHistory.EffectiveFrom}</td></tr>
        //                                </table>

        //                                <input type=""hidden"" id=""employeeCodeHidden"" value=""{employeeCode}"">
        //                                <input type=""hidden"" id=""token"" value=""{token}"">

        //                                <!-- LOGIN BOX -->
        //                                <div class=""login-box"" id=""loginSection"">
        //                                    <h3>Login</h3>

        //                                    <label>User ID</label>
        //                                    <input type=""text"" id=""txtUserId"" placeholder=""Enter User ID"">

        //                                    <label>Password</label>
        //                                    <input type=""password"" id=""txtPassword"" placeholder=""Enter Password"">

        //                                    <button id=""btnLogin"">Login</button>
        //                                </div>

        //                                <!-- Action buttons will be injected here after login -->
        //                                <div id=""actionSectionContainer""></div>

        //                                <p>For any queries, contact HR department.</p>
        //                                <p>Regards,<br>HR Department</p>
        //                            </div>

        //                            <div class=""footer"">
        //                                This is an automated message. Please do not reply.<br>
        //                                © 2025 Silkways Card and Printings Ltd.
        //                            </div>

        //                        </div>

        //                        <script src=""https://code.jquery.com/jquery-3.6.0.min.js""></script>

        //                        <script>
        //                        $(document).ready(function () {{
        //                            $.ajax({{
        //                                type: ""POST"",
        //                                url: '{baseUrl}/WebServices/HRIS/PromotionHistoryService.asmx/GetTokenStatus',
        //                                contentType: ""application/json; charset=utf-8"",
        //                                dataType: ""json"",
        //                                data: JSON.stringify({{
        //                                    token: $('#token').val(),

        //                                }}),
        //                                success: function (response) {{
        //                                    var data = response.d;

        //                                    if(data.ResponseCode == 0){{
        //                                    // Hide login area
        //                                    $(""#wrapperId"").hide();

        //                                    // Show token expired message div
        //                                    $(""#tokenExpiredDiv"").show();

        //                                    return;
        //                                    }}
        //                                }},
        //                                error: function () {{
        //                                    alert(""Can't check token."");
        //                                }}
        //                            }});
        //                        }});

        //                        // LOGIN CLICK
        //                        $(""#btnLogin"").click(function () {{

        //                            let userId = $(""#txtUserId"").val();
        //                            let password = $(""#txtPassword"").val();

        //                            if (userId === """" || password === """") {{
        //                                alert(""Please enter User ID and Password"");
        //                                return;
        //                            }}

        //                            $.ajax({{
        //                                type: ""POST"",
        //                                url: ""{baseUrl}/WebServices/UserServices.asmx/Authenticate"",
        //                                contentType: ""application/json; charset=utf-8"",
        //                                dataType: ""json"",
        //                                data: JSON.stringify({{
        //                                    IP_str_Username: userId,
        //                                    IP_str_Password: password
        //                                }}),
        //                                success: function (response) {{
        //                                    debugger;
        //                                    var data = response.d;



        //                                    if (data.ResponseCode === 0 && data.BResponse === true) {{

        //                                    if(response.d.Data.EmployeeCode != $('#employeeCodeHidden').val()){{
        //                                        alert(""You are not authorized to do this action"");
        //                                        return;
        //                                    }};

        //                                        $(""#loginSection"").hide();

        //                                        // inject secure action buttons
        //                                        $(""#actionSectionContainer"").html(`
        //                                            <div class=""action-buttons"" id=""actionSection"">
        //                                                <p>Please choose an action:</p>

        //                                                <a href=""#"" class=""btn btn-approve""
        //                                                onclick=""updatePromotionStatus(2, this); return false;"">Approve</a>

        //                                                <a href=""#"" class=""btn btn-reject""
        //                                                onclick=""updatePromotionStatus(0, this); return false;"">Reject</a>
        //                                            </div>
        //                                        `);

        //                                    }} else {{
        //                                        alert(data.Message || ""Authentication failed"");
        //                                    }}
        //                                }},
        //                                error: function () {{
        //                                    alert(""Login request failed. Please try again."");
        //                                }}
        //                            }});
        //                        }});


        //                        // APPROVAL / REJECT ACTION
        //                        function updatePromotionStatus(status, element) {{

        //                            $('.btn').css('opacity', '0.5').css('pointer-events', 'none');
        //                            $(element).text(""Processing..."");

        //                            $.ajax({{
        //                                type: 'POST',
        //                                url: '{baseUrl}/WebServices/HRIS/PromotionHistoryService.asmx/UpdatePromotionStatusForApproverFromMail',
        //                                data: JSON.stringify({{
        //                                    IP_ui64_PromotionHistoryCode: {promotionHistory.PromotionID},
        //                                    status: status,
        //                                    employeeCode: {employeeCode},
        //                                    token: $('#token').val()
        //                                }}),
        //                                contentType: 'application/json; charset=utf-8',
        //                                dataType: 'json',

        //                                success: function () {{
        //                                    $("".content"").html(`
        //                                        <div style=""text-align:center; padding:40px;"">
        //                                            <h3 style=""color:#28a745;"">Action Completed</h3>
        //                                            <p>${{status === 2 ? ""Approval successful."" : ""Rejection submitted.""}}</p>
        //                                            <p>This window will close automatically in 5 seconds.</p>
        //                                        </div>
        //                                    `);

        //                                    setTimeout(() => window.close(), 5000);
        //                                }},

        //                                error: function () {{
        //                                    alert(""Error processing request."");
        //                                    location.reload();
        //                                }}
        //                            }});
        //                        }}

        //                        </script>

        //                        </body>
        //                        </html>
        //";
        //        }


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
                            if(approverStatus != (int)PromotionStatus.Pending)
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
                            if(status == (int)PromotionStatus.Rejected)
                            {
                                RejectFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                            }

                            if(status == (int)PromotionStatus.Approved)
                            {
                                ApprovedFinalPromotion(lcl_obj_DBManager, IP_ui64_PromotionHistoryCode);
                            }
                            if(token != null) { 
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
