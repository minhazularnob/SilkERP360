using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for Quotation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Quotation : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveItems(SilkERP360.CCL.BusinessEntities.WPMS.Quotation IP_obj_Quotaion)
        {
            try
            {
                SilkERP360.FL.WPMS.QuotationFacade lcl_obj_QuotationFacade = new SilkERP360.FL.WPMS.QuotationFacade();
                System.UInt64 lcl_ui64_QuotationFacade = lcl_obj_QuotationFacade.Save(IP_obj_Quotaion);
                if (lcl_ui64_QuotationFacade > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Quotation Saved Successfully", true, lcl_ui64_QuotationFacade);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse Retrive(System.UInt64 IP_obj_Status)
        {
            try
            {

                SilkERP360.FL.WPMS.QuotationFacade lcl_obj_QuotationFacade = new SilkERP360.FL.WPMS.QuotationFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Quotation =
                lcl_obj_QuotationFacade.GetAllQuotation(IP_obj_Status);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse RetriveCodeNameDate(System.UInt64 IP_obj_Status)
        {
            try
            {

                SilkERP360.FL.WPMS.QuotationFacade lcl_obj_QuotationFacade = new SilkERP360.FL.WPMS.QuotationFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Quotation =
                lcl_obj_QuotationFacade.GetAllCodeNameDate(IP_obj_Status);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
