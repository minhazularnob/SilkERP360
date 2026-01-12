using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for ReportService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ReportService : System.Web.Services.WebService
    {
        
        [System.Web.Services.WebMethod(EnableSession = true)]
        public void ReportSubmit(System.String[] obj)
        {
            Session["ReportID"] = obj[0];
            Session["EmployeeCode"] = obj[1];
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public void  ReportAttendance(System.String[] obj)
        {
            Session["ReportID"] = obj[0];
            Session["dDate"] = obj[1];
            Session["DeptCode"] = obj[2];
            Session["CompCode"] = obj[3];
        }
    }
}
