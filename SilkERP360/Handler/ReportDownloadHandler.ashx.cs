using Microsoft.Reporting.WebForms;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;

namespace SilkERP360.Handler
{
    public class ReportDownloadHandler : IHttpHandler
    {
        SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();

        Warning[] warnings;
        string[] streams;

        public void ProcessRequest(HttpContext context)
        {
            string reportName = context.Request.QueryString["report"];
            string company = context.Request.QueryString["company"];
            if (string.IsNullOrEmpty(reportName))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Report name missing");
                return;
            }

            string startDateStr = context.Request.QueryString["startDate"];
            string endDateStr = context.Request.QueryString["endDate"];
            string type = context.Request.QueryString["type"];

            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;

            string format = "dd/MMMM/yyyy hh:mm tt"; // full month name

            CultureInfo provider = new CultureInfo("en-US"); // ensures month names are recognized

            if (!string.IsNullOrEmpty(startDateStr))
                DateTime.TryParseExact(startDateStr, format, provider, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out startDate);

            if (!string.IsNullOrEmpty(endDateStr))
                DateTime.TryParseExact(endDateStr, format, provider, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeLocal, out endDate);


            try
            {
                var reportConfig = GetReportConfig(reportName, company);

                // Prepare parameters for Attendance report
                Dictionary<string, object> parameters = null;
                if (reportName.Equals("Attendance", StringComparison.OrdinalIgnoreCase))
                {
                    if (startDate == DateTime.MinValue || endDate == DateTime.MinValue)
                        throw new Exception("Start Date and End Date are required for Attendance report");

                    parameters = new Dictionary<string, object>
                    {
                        { "startDate", startDate },
                        { "endDate", endDate }
                    };
                }

                DataTable dt = GetReportData(reportConfig, parameters);

                LocalReport lr = new LocalReport
                {
                    ReportPath = context.Server.MapPath("~/Reports/" + reportName + ".rdlc")
                };
                lr.DataSources.Clear();
                lr.DataSources.Add(new ReportDataSource("DataSet1", dt));

                string mimeType, encoding, extension;
                byte[] bytes;

                context.Response.Clear();

                if (type == "1")
                {
                    // PDF
                    bytes = lr.Render(
                        "PDF",
                        null,
                        out mimeType,
                        out encoding,
                        out extension,
                        out streams,
                        out warnings
                    );

                    context.Response.ContentType = "application/pdf";
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + reportName + ".pdf");
                }
                else
                {
                    // Excel
                    bytes = lr.Render(
                        "EXCELOPENXML",
                        null,
                        out mimeType,
                        out encoding,
                        out extension,
                        out streams,
                        out warnings
                    );

                    context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + reportName + ".xlsx");
                }

                context.Response.BinaryWrite(bytes);
                context.Response.Flush();
                context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Error: " + ex.Message);
            }
        }

        // Fetch report configuration
        private ReportConfig GetReportConfig(string reportName, string company)
        {
            var reports = new Dictionary<string, ReportConfig>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    "EmployeeList",
                    new ReportConfig
                    {
                        Query = @"SELECT e.employee_code, e.employee_id, e.employee_name, de.degn_name,dep.dept_name, 
                                  e.joining_date, e.confirmation_date, e.job_location, ep.blood_group,e.bank_account_no, s.basic, s.gross FROM employee e
                                  INNER JOIN designation de ON e.designation_code = de.designation_code
                                  INNER JOIN department dep ON e.department_code = dep.department_code
                                  LEFT JOIN employee_personal ep ON e.employee_code = ep.employee_code
                                  left join employee_salary_structure s on e.employee_code=s.employee_code
                                  WHERE e.is_deleted = 1 AND e.employee_status IN(0,1,2) and e.company_code = "+company+" order by dep.rank asc",
                        Columns = new Dictionary<string, Type>
                        {
                            { "EMPLOYEE_ID", typeof(string) },
                            { "EMPLOYEE_NAME", typeof(string) },
                            { "degn_name", typeof(string) },
                            { "dept_name", typeof(string) },
                            { "bank_account_no", typeof(string) },
                            { "joining_date", typeof(DateTime) },
                            { "confirmation_date", typeof(DateTime) },
                            { "job_location", typeof(string) },
                            { "blood_group", typeof(string) },
                            { "basic", typeof(decimal) },
                            { "gross", typeof(decimal) }
                        }
                    }
                },
                {
                    "Attendance",
                    new ReportConfig
                    {
                        //Query = @"SELECT * FROM ATTENDANCE WHERE attendance_date BETWEEN :startDate AND :endDate ORDER BY ATTENDANCE_DATE, EMPLOYEE_CODE",
                        Query = @"select * from attendance a inner join attendance_master m on a.attendance_master_code=m.attendance_master_code where m.company_code= "+company+" and a.attendance_date BETWEEN :startDate AND :endDate ORDER BY a.ATTENDANCE_DATE, a.EMPLOYEE_CODE",
                        Columns = new Dictionary<string, Type>
                        {
                            { "ATTENDANCE_CODE", typeof(decimal) },
                            { "ATTENDANCE_MASTER_CODE", typeof(decimal) },
                            { "ATTENDANCE_DATE", typeof(DateTime) },
                            { "EMPLOYEE_CODE", typeof(decimal) },
                            { "DUTY_FROM", typeof(DateTime) },
                            { "IN_THROUGH", typeof(string) },
                            { "DUTY_UPTO", typeof(DateTime) },
                            { "OUT_THROUGH", typeof(string) },
                            { "DUTY_MINUTES", typeof(decimal) },
                            { "OVERTIME_AUTO", typeof(decimal) },
                            { "ATTN_STATUS", typeof(decimal) },
                            { "REMARKS", typeof(string) },
                            { "WG_OPERATION_MASTER_CODE", typeof(decimal) },
                            { "EMPLOYEE_ID", typeof(string) },
                            { "EMPLOYEE_NAME", typeof(string) },
                            { "DEPARTMENT", typeof(string) },
                            { "DESIGNATION", typeof(string) },
                            { "STATUS_OVERRIDE_EMPLOYEE_CODE", typeof(decimal) },
                            { "PAID_PER_HOUR", typeof(decimal) },
                            { "OVERTIME_ENTRY_TYPE", typeof(decimal) },
                            { "OVERTIME_ENTRY_EMPLOYEE_CODE", typeof(decimal) },
                            { "DUTY_SCHEDULE_FROM", typeof(DateTime) },
                            { "DUTY_SCHEDULE_UPTO", typeof(DateTime) },
                            { "OVERTIME_MANUAL_ADJUSTMENT", typeof(decimal) },
                            { "OVERTIME_TOTAL", typeof(decimal) },
                            { "MANUAL_OT_ADJUSTMENT_EMP_CODE", typeof(decimal) },
                            { "IN_DOOR_NO", typeof(decimal) },
                            { "OUT_DOOR_NO", typeof(decimal) },
                            { "NIGHT_ALLOWANCE", typeof(decimal) }
                        }
                    }
                }
            };

            if (!reports.ContainsKey(reportName))
                throw new Exception("Report configuration not found!");

            return reports[reportName];
        }

        // Fetch data from Oracle
        private DataTable GetReportData(ReportConfig config, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            // Create DataTable columns
            foreach (var col in config.Columns)
                dt.Columns.Add(col.Key, col.Value);

            string query = config.Query;

            // If parameters exist, replace placeholders with Oracle-compatible literals
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    if (param.Value is DateTime dtValue)
                    {
                        // Format as Oracle date literal: TO_DATE('dd-MM-yyyy HH24:MI', 'DD-MM-YYYY HH24:MI')
                        string formatted = dtValue.ToString("dd-MM-yyyy HH:mm");
                        query = query.Replace(":" + param.Key, $"TO_DATE('{formatted}', 'DD-MM-YYYY HH24:MI')");
                    }
                    else
                    {
                        query = query.Replace(":" + param.Key, param.Value.ToString());
                    }
                }
            }

            // Execute reader using SqlFacade
            using (OracleDataReader reader = lcl_obj_SqlFacade.ExecuteDataReader(query))
            {
                if (reader == null || !reader.HasRows)
                    throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("No records found!");

                while (reader.Read())
                {
                    DataRow dr = dt.NewRow();
                    foreach (var col in config.Columns)
                    {
                        try
                        {
                            int ord = reader.GetOrdinal(col.Key);
                            dr[col.Key] = reader.IsDBNull(ord)
                                ? (col.Value == typeof(string) ? null : Activator.CreateInstance(col.Value))
                                : reader.GetValue(ord);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            dr[col.Key] = col.Value == typeof(string) ? null : Activator.CreateInstance(col.Value);
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        public bool IsReusable => false;

        // Report config helper
        private class ReportConfig
        {
            public string Query { get; set; }
            public Dictionary<string, Type> Columns { get; set; }
        }
    }
}
