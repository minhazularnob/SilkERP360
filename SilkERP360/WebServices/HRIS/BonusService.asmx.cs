using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for BonusService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class BonusService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetBonusMasterDetailsByBonusMasterCode(System.UInt64 IP_ui64_BonusMasterCode)
        {
            try
            {
                SilkERP360.SP.HRIS.BonusServices lcl_obj_BonusServices = new SP.HRIS.BonusServices();
                lcl_obj_BonusServices.Initialize();
                SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = lcl_obj_BonusServices.GetBonusMasterByBonusMasterCode(IP_ui64_BonusMasterCode);

                if (lcl_obj_BonusMaster == null)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "Unknown Error!!Contact SSL!!!", false, null);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_BonusMaster);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, false, null);
            }
        }

    }
}
