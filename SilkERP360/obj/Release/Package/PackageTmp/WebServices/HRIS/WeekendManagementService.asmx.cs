using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for WeekendManagementService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WeekendManagementService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateEmployeeWeekend(System.UInt64 IP_ui64_EntryEmployeeCode, System.DateTime IP_dt_FromDate, System.DateTime IP_dt_UptoDate, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers.EmployeeAssignedWeekend> IP_objLst_EmployeeAssignedWeekend)
        {
            try
            {
                SilkERP360.SP.HRIS.WeekendSP lcl_obj_WeekendSP = new SP.HRIS.WeekendSP();
                CCL.Misc.WSResponse lcl_obj_WSResponse = lcl_obj_WeekendSP.AssignWeekend(IP_ui64_EntryEmployeeCode,IP_dt_FromDate, IP_dt_UptoDate, IP_objLst_EmployeeAssignedWeekend);
                return lcl_obj_WSResponse;
                
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetWeekendEmployeesByDate(System.DateTime IP_dt_WeekendDate)
        {
            try
            {
                SilkERP360.SP.HRIS.WeekendSP lcl_obj_WeekendSP = new SP.HRIS.WeekendSP();
                CCL.Misc.WSResponse lcl_obj_WSResponse = lcl_obj_WeekendSP.GetWeekendEmployeesByDate(IP_dt_WeekendDate);
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CancelWeekend(System.UInt64 IP_ui64_WeekendCode)
        {
            try
            {
                SilkERP360.SP.HRIS.WeekendSP lcl_obj_WeekendSP = new SP.HRIS.WeekendSP();
                CCL.Misc.WSResponse lcl_obj_WSResponse = lcl_obj_WeekendSP.CancelWeekend(IP_ui64_WeekendCode);
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
