using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SCPM
{
    /// <summary>
    /// Misc. Services of SCPM System
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SCPMServices : System.Web.Services.WebService
    {
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GenerateRandomSequenceForSIMQC(SilkERP360.CCL.Enums.SCPM.SMQCTestTypes IP_enm_SMQCTestType, System.UInt32 IP_ui32_Quantity)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
