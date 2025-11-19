using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.HRIS
{
    /// <summary>
    /// Summary description for PromotionHistoryService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PromotionHistoryService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SavePromotionHistory(SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory IP_Obj_PromotionHistory)
        {
            try
            {
                SilkERP360.SP.HRIS.PromotionHistoryService locl_obj_promotionHistoryService = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.UInt64 lcl_ui64_promotionHistoryCode = locl_obj_promotionHistoryService.SavePromotionHistory(IP_Obj_PromotionHistory);

                if (lcl_ui64_promotionHistoryCode > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Saved Successfully", true, lcl_ui64_promotionHistoryCode);
                }

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, false);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetAllPromotionHistory(System.UInt64 IP_ui64_companyCode)
        {
            try
            {
                SilkERP360.SP.HRIS.PromotionHistoryService lcl_obj_DesignationFacade = new SilkERP360.SP.HRIS.PromotionHistoryService();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_objLst_Designation =
                    lcl_obj_DesignationFacade.GetAllPromotionHistory(IP_ui64_companyCode);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Designation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
