using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for RelationBuyerProduct
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class RelationBuyerProduct : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse Save(SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct IP_obj_RelationBuyerProduct)
        {
            try
            {
                SilkERP360.FL.WPMS.RelationBuyerProductFacade lcl_obj_BuyerFacade = new SilkERP360.FL.WPMS.RelationBuyerProductFacade();
                System.UInt64 lcl_ui64_BuyerFacade = lcl_obj_BuyerFacade.Save(IP_obj_RelationBuyerProduct);
                if (lcl_ui64_BuyerFacade > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Your Information Saved Successfully", true, lcl_ui64_BuyerFacade);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse Retrive(System.UInt64 IP_obj_radion)
        {
            try
            {

                SilkERP360.FL.WPMS.ItemFacade lcl_obj_RelationBuyerProductFacade = new SilkERP360.FL.WPMS.ItemFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_objLst_RelationBuyerProduct =
                lcl_obj_RelationBuyerProductFacade.Retrieve(IP_obj_radion);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_RelationBuyerProduct);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse RetriveSizeSpec(System.UInt64 IP_obj_ddlSizeSpecification)
        {
            try
            {

                SilkERP360.FL.WPMS.RelationBuyerProductFacade lcl_obj_RelationBuyerProductFacade = new SilkERP360.FL.WPMS.RelationBuyerProductFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RelationBuyerProduct> lcl_objLst_RelationBuyerProduct =
                lcl_obj_RelationBuyerProductFacade.GetAllDesignationWiseSize(IP_obj_ddlSizeSpecification);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_RelationBuyerProduct);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
