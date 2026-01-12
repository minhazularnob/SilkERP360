using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Summary description for SCPMDataWriterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SCPMDataWriterService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveMachineThroughput(SilkERPDataService.Containers.SCPM.SCMachineThroughput IP_obj_MachineThroughput)
        {
            try
            {
                SilkERPDataService.WriteService.SCPM.SCPMMachineDataLogger lcl_obj_MachineThroughputLogger = new SilkERPDataService.WriteService.SCPM.SCPMMachineDataLogger();
                lcl_obj_MachineThroughputLogger.SaveMachineThroughput(IP_obj_MachineThroughput);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Machine Throughput Saved Successfully Into the SilkERP Database!!!", false, null);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
