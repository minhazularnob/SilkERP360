using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for SCProductionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SCProductionService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetMachinewiseThroughputByDateRange(System.UInt64 IP_ui64_MachineCode, System.String IP_str_StartDate, System.String IP_str_EndDate)
        {
            try
            {
                System.DateTime lcl_dt_StartDate = System.DateTime.Parse(IP_str_StartDate);
                System.DateTime lcl_dt_EndDate = System.DateTime.Parse(IP_str_EndDate);
                SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_SCDataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();
                SilkERPDataService.Containers.SCPM.SC.SCMachine lcl_obj_SCMachine = lcl_obj_SCDataProvider.GetSCMachine(IP_ui64_MachineCode);
                SilkERPDataService.Containers.SCPM.DataStructure.SC.DayRangeMachineThroughput lcl_obj_DayRangeMachinewiseThroughput = 
                    lcl_obj_SCDataProvider.GetDaywiseMachineThroughputByDayRange(IP_ui64_MachineCode, lcl_dt_StartDate, lcl_dt_EndDate);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", false, lcl_obj_DayRangeMachinewiseThroughput);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllSectionThroughput(System.String IP_str_StartDate,System.String IP_str_EndDate)
        {
            try
            {
                System.DateTime lcl_dt_StartDate = System.DateTime.Parse(IP_str_StartDate);
                System.DateTime lcl_dt_EndDate = System.DateTime.Parse(IP_str_EndDate);
                SilkERPDataService.AnalyticService.SCPM.ThroughputAnalytics lcl_obj_ThroughputAnalytic = new SilkERPDataService.AnalyticService.SCPM.ThroughputAnalytics();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMSectionExt> lcl_objLst_SectionExt = lcl_obj_ThroughputAnalytic.GetSectionExtAll(lcl_dt_StartDate, lcl_dt_EndDate);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", false, lcl_objLst_SectionExt);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllSectionAvgThroughput(System.String IP_str_StartDate, System.String IP_str_EndDate)
        {
            try
            {
                System.DateTime lcl_dt_StartDate = System.DateTime.Parse(IP_str_StartDate);
                System.DateTime lcl_dt_EndDate = System.DateTime.Parse(IP_str_EndDate);
                SilkERPDataService.AnalyticService.SCPM.ThroughputAnalytics lcl_obj_ThroughputAnalytic = new SilkERPDataService.AnalyticService.SCPM.ThroughputAnalytics();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgSectionExt> lcl_objLst_AvgSectionExt = lcl_obj_ThroughputAnalytic.GetAvgSectionExtAll(lcl_dt_StartDate, lcl_dt_EndDate);


                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", false, lcl_objLst_AvgSectionExt);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllSectionThroughputByDate(System.String IP_str_Date)
        {
            try
            {
                System.DateTime lcl_dt_Date = System.DateTime.Parse(IP_str_Date);
                SilkERPDataService.ReadService.SCPM.SCDataProvider lcl_obj_DataProvider = new SilkERPDataService.ReadService.SCPM.SCDataProvider();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.SectionwiseThroughput> lcl_obj_SectionwiseThroughputList =
                    lcl_obj_DataProvider.GetAllSectionThroughputByDate(lcl_dt_Date);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Success", false, lcl_obj_SectionwiseThroughputList);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -100, Ex.Message, false, null);
            }
        }
    }
}
