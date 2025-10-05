using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for Buyer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Buyer : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse BuyerSave(SilkERP360.CCL.BusinessEntities.WPMS.Buyer IP_obj_Buyer)
        {
            try
            {
                SilkERP360.FL.WPMS.BuyerFacade lcl_obj_BuyerFacade = new SilkERP360.FL.WPMS.BuyerFacade();
                System.UInt64 lcl_ui64_BuyerFacade = lcl_obj_BuyerFacade.Save(IP_obj_Buyer);
                if (lcl_ui64_BuyerFacade > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Buyer Information Saved Successfully", true, lcl_ui64_BuyerFacade);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadCustomerInfoQuotatioCode(System.UInt64 IP_obj_ddlCustomerCode)
        {
            try
            {
                SilkERP360.FL.WPMS.BuyerFacade lcl_obj_BuyerFacade = new SilkERP360.FL.WPMS.BuyerFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_Quotation =
                lcl_obj_BuyerFacade.GetAllQuotationWise(IP_obj_ddlCustomerCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadCustomer(System.UInt64 IP_str_Status)
        {
            try
            {
                SilkERP360.FL.WPMS.BuyerFacade lcl_obj_BuyerFacade = new SilkERP360.FL.WPMS.BuyerFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_Quotation =
                lcl_obj_BuyerFacade.GetAllCustomer(IP_str_Status);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }

        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadCustomerCode(System.UInt64 IP_obj_ddlCustomerCode)
        {
            try
            {
                SilkERP360.FL.WPMS.BuyerFacade lcl_obj_BuyerFacade = new SilkERP360.FL.WPMS.BuyerFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_Quotation =
                lcl_obj_BuyerFacade.GetAllCustomerCode(IP_obj_ddlCustomerCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}