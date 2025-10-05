using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Dynamic;
namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for SCPMReaderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SCPMReaderService : System.Web.Services.WebService
    {
        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public SilkERP360.CCL.Misc.WSResponse GetMachineExtThroughput()
        //{
        //    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Machine Throughput Saved Successfully Into the SilkERP Database!!!", true, null);
        //}

        

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetMachineSTRExtThroughput(System.String IP_str_SectionCode, System.String IP_str_ProcessCode, System.String IP_str_StartDate, System.String IP_str_EndDate)
        {
            try
            {
                System.DateTime lcl_dt_Startdate = System.DateTime.Parse(IP_str_StartDate);
                System.DateTime lcl_dt_Enddate = System.DateTime.Parse(IP_str_EndDate);
                //get All Machines that belongs to IP_str_SectionCode IP_str_ProcessCode
                SilkERPDataService.ReadService.SCPM.SCPMMachineService lcl_obj_SCPMMachineService = new SilkERPDataService.ReadService.SCPM.SCPMMachineService();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineSTRExt> lcl_objLst_SCPMMachineSTRExt = lcl_obj_SCPMMachineService.GetMachineSTRExtThroughputByProcessDateRange(System.UInt64.Parse(IP_str_SectionCode), System.UInt64.Parse(IP_str_ProcessCode), lcl_dt_Startdate, lcl_dt_Enddate);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Machine Throughput Saved Successfully Into the SilkERP Database!!!", true, lcl_objLst_SCPMMachineSTRExt);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetMachineExtThroughput(System.String IP_str_SectionCode, System.String IP_str_ProcessCode, System.String IP_str_StartDate, System.String IP_str_EndDate)
        {
            try
            {
                System.DateTime lcl_dt_Startdate = System.DateTime.Parse(IP_str_StartDate);
                System.DateTime lcl_dt_Enddate = System.DateTime.Parse(IP_str_EndDate);
                //get All Machines that belongs to IP_str_SectionCode IP_str_ProcessCode
                SilkERPDataService.ReadService.SCPM.SCPMMachineService lcl_obj_SCPMMachineService = new SilkERPDataService.ReadService.SCPM.SCPMMachineService();
                System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt> lcl_objLst_SCPMMachineExt = lcl_obj_SCPMMachineService.GetMachineExtThroughputByProcessDateRange(System.UInt64.Parse(IP_str_SectionCode), System.UInt64.Parse(IP_str_ProcessCode), lcl_dt_Startdate, lcl_dt_Enddate);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Machine Throughput Saved Successfully Into the SilkERP Database!!!", true, lcl_objLst_SCPMMachineExt);
              

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
