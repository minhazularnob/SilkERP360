using Microsoft.Reporting.WebForms;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace SilkERP360.Handler
{
    public class ReportDownloadHandler : IHttpHandler
    {
        SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
        public void ProcessRequest(HttpContext context)
        {
            string reportName = context.Request.QueryString["report"];
            if (string.IsNullOrEmpty(reportName))
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Report name missing");
                return;
            }

            DataTable dt = GetReportData(reportName);

            LocalReport lr = new LocalReport();
            lr.ReportPath = context.Server.MapPath("~/Reports/" + reportName + ".rdlc");
            lr.DataSources.Clear();
            lr.DataSources.Add(new ReportDataSource("DataSet1", dt));

            string mimeType, encoding, extension;
            Warning[] warnings;
            string[] streams;

            byte[] bytes = lr.Render("PDF", null, out mimeType, out encoding, out extension, out streams, out warnings);

            context.Response.Clear();
            context.Response.ContentType = "application/pdf";
            context.Response.AddHeader("Content-Disposition", "inline; filename=" + reportName + ".pdf");
            context.Response.BinaryWrite(bytes);
            context.Response.Flush();
            context.ApplicationInstance.CompleteRequest();
        }



        private DataTable GetReportData(string reportName)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("EMPLOYEE_ID", typeof(string));
            dt.Columns.Add("EMPLOYEE_NAME", typeof(string));
            dt.Columns.Add("degn_name", typeof(string));
            dt.Columns.Add("joining_date", typeof(DateTime));
            dt.Columns.Add("confirmation_date", typeof(DateTime));
            dt.Columns.Add("job_location", typeof(string));
            dt.Columns.Add("blood_group", typeof(string));

            string lcl_str_SqlQuery = "select e.employee_code,e.employee_id,e.employee_name,de.degn_name,e.joining_date,e.confirmation_date,e.job_location,ep.blood_group from employee e inner join designation de on e.designation_code=de.designation_code inner join department dep on e.department_code= dep.department_code left join employee_personal ep on e.employee_code= ep.employee_code where e.is_deleted=1 and e.employee_status in(0,1,3)";

            Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_Reader = lcl_obj_SqlFacade.ExecuteDataReader(lcl_str_SqlQuery);

            if (!lcl_obj_Reader.HasRows)
            {
                throw new SilkERP360.CCL.ExceptionManagement.Exceptions.UIException("No employees found in the database!");
            }

            while (lcl_obj_Reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["EMPLOYEE_ID"] = lcl_obj_Reader["EMPLOYEE_ID"]?.ToString();
                dr["EMPLOYEE_NAME"] = lcl_obj_Reader["EMPLOYEE_NAME"]?.ToString();
                dr["degn_name"] = lcl_obj_Reader["degn_name"]?.ToString();
                dr["joining_date"] = lcl_obj_Reader["joining_date"]?.ToString();
                dr["confirmation_date"] = lcl_obj_Reader["confirmation_date"]?.ToString();
                dr["job_location"] = lcl_obj_Reader["job_location"]?.ToString();
                dr["blood_group"] = lcl_obj_Reader["blood_group"]?.ToString();

                dt.Rows.Add(dr);
            }

            lcl_obj_SqlFacade.CloseReader();

            return dt;
        }


        public bool IsReusable => false;
    }
}
