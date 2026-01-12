using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for QuotationDetails
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class QuotationDetails : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public SilkERP360.CCL.Misc.WSResponse QuotationSave(SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails IP_obj_Quotaion)
        //{
        //    try
        //    {
        //        SilkERP360.FL.WPMS.QuotationDetailsFacade lcl_obj_QuotationDetailsFacade = new SilkERP360.FL.WPMS.QuotationDetailsFacade();
        //        System.UInt64 lcl_ui64_QuotationDetailsFacade = lcl_obj_QuotationDetailsFacade.Save(IP_obj_Quotaion);
        //        if (lcl_ui64_QuotationDetailsFacade > 0)
        //        {
        //            return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "QuotationDetails Saved Successfully", true, lcl_ui64_QuotationDetailsFacade);
        //        }
        //        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

        //    }
        //    catch (System.Exception Ex)
        //    {
        //        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
        //    }
        //}
    }
}
