using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for IncrementAndPromotionService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class IncrementAndPromotionService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllApprovedIncrementAndPromotionHistory(System.UInt64 IP_ui64_companyCode, string from, string to)
        {
            try
            {
                SilkERP360.SP.HRIS.IncrementAndPromotionHistoryService lcl_obj_incrementAndPromotionHistoryService = new SilkERP360.SP.HRIS.IncrementAndPromotionHistoryService();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory> lcl_objLst_Designation =
                    lcl_obj_incrementAndPromotionHistoryService.GetAllApprovedIncrementAndPromotionHistory(IP_ui64_companyCode, from, to);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Designation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
