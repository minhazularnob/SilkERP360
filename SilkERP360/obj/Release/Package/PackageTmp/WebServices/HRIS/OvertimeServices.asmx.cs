using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for OvertimeServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class OvertimeServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveOvertime(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> IP_objLst_NewOvertime)
        {
            try
            {
                SilkERP360.FL.HRIS.OvertimeFacade lcl_obj_OvertimeFacade = new FL.HRIS.OvertimeFacade();
                //SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new FL.SqlFacade();
                //lcl_obj_SqlFacade.Initialize();
                //System.String lcl_str_SqlUpdate = System.String.Format("UPDATE OVERTIME SET OT_HOUR = {0} WHERE OT_CODE = {1}", IP_obj_NewOT.OvertimeHour, IP_obj_NewOT.OvertimeCode);
                //lcl_obj_SqlFacade.ExecuteScaler(lcl_str_SqlUpdate);
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> lcl_objLst_NewOvertime = new List<CCL.BusinessEntities.HRIS.Overtime>();
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.Overtime lcl_obj_Overtime in IP_objLst_NewOvertime)
                {
                    System.UInt64 lcl_ui64_OvertimeCode = lcl_obj_OvertimeFacade.Save(lcl_obj_Overtime);
                    lcl_obj_Overtime.OvertimeCode = lcl_ui64_OvertimeCode;
                    lcl_objLst_NewOvertime.Add(lcl_obj_Overtime);
                }
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_objLst_NewOvertime);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse UpdateOvertime(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Overtime> IP_objLst_Overtime)
        {
            try
            {
                SilkERP360.FL.HRIS.OvertimeFacade lcl_obj_OvertimeFacade = new SilkERP360.FL.HRIS.OvertimeFacade();
                lcl_obj_OvertimeFacade.Update(IP_objLst_Overtime);
                
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetDepartmentwiseOvertimeListByDateRange(System.UInt64 IP_ui64_DepartmentCode, System.DateTime IP_dt_StartDate, System.DateTime IP_dt_EndDate)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.OvertimeHistoryFacade lcl_obj_OvertimeHistoryFacade = new SilkERP360.FL.HRIS.DataStructures.OvertimeHistoryFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryList =
                    lcl_obj_OvertimeHistoryFacade.GetDepartmentwiseOvertimeListByDateRange(IP_ui64_DepartmentCode, IP_dt_StartDate, IP_dt_EndDate);
                //var lcl_str_LeaveListJson = new JavaScriptSerializer().Serialize (lcl_objLst_EmployeeLeaveList);
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_objLst_OvertimeHistoryList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetDepartmentwiseOvertimeListByDate(System.UInt64 IP_ui64_DepartmentCode, System.DateTime IP_dt_OvertimeDate)
        {
            try
            {
                SilkERP360.FL.HRIS.DataStructures.OvertimeHistoryFacade lcl_obj_OvertimeHistoryFacade = new SilkERP360.FL.HRIS.DataStructures.OvertimeHistoryFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.OvertimeHistory> lcl_objLst_OvertimeHistoryList =
                    lcl_obj_OvertimeHistoryFacade.GetDepartmentwiseOvertimeListByDate(IP_ui64_DepartmentCode, IP_dt_OvertimeDate);
                //var lcl_str_LeaveListJson = new JavaScriptSerializer().Serialize (lcl_objLst_EmployeeLeaveList);
                return new SilkERP360.CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Succedded", true, lcl_objLst_OvertimeHistoryList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }
    }
}
