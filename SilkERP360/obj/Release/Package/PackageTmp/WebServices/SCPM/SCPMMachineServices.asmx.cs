using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for SCPMMachineServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SCPMMachineServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// Generates List of SCPM_MACHINES based on ProductionProcess
        /// </summary>
        /// <param name="IP_ui64_ProcessCode"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        public SilkERP360.CCL.Misc.WSResponse GetMachinesByProductionProcess(System.UInt64 IP_ui64_ProductionProcessCode)
        {
            try
            {
                SilkERP360.FL.SCPM.MachineFacade lcl_obj_MachineFacade = new SilkERP360.FL.SCPM.MachineFacade();
                SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine lcl_obj_SCPMMachine = new CCL.BusinessEntities.SCPM.SCPMMachine();
                System.String lcl_str_SqlQuery = lcl_obj_SCPMMachine.GenerateSqlSelect("WHERE PROCESS_CODE = " + IP_ui64_ProductionProcessCode.ToString());
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.SCPMMachine> lcl_objLst_SCPMMachine = lcl_obj_MachineFacade.GetList(lcl_str_SqlQuery);
                return new SilkERP360.CCL.Misc.WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_objLst_SCPMMachine);
            }
            catch (System.Exception Ex)
            {
                return new SilkERP360.CCL.Misc.WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }
    }
}
