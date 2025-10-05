using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for PurchaseOrder
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class PurchaseOrder : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
       [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse POSave(SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrder IP_obj_PO)
        {

            try
            {
                SilkERP360.FL.WPMS.PurchaseOrderFacade lcl_obj_PurchaseOrderFacade = new SilkERP360.FL.WPMS.PurchaseOrderFacade();
                System.UInt64 lcl_ui64_PurchaseOrderFacade = lcl_obj_PurchaseOrderFacade.Save(IP_obj_PO);


                if (lcl_ui64_PurchaseOrderFacade > 0)
                {
                    //SilkERP360.FL.WPMS.Mailer lcl_obj_Mailer = new SilkERP360.FL.WPMS.Mailer();
                    //lcl_obj_Mailer.Send_P_O_Mail(IP_obj_Quotaion);
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Purchase Order Saved Successfully", true, lcl_ui64_PurchaseOrderFacade);

                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }

            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

       [System.Web.Services.WebMethod(EnableSession = true)]
       public SilkERP360.CCL.Misc.WSResponse Retrive(System.UInt64 IP_ui64_ddlPOCode)
       {

           

           System.String lcl_str_SqlQuery = System.String.Format(@"Select POD.PURCHASE_ORDER_DETAILS_CODE ,
POD.PURCHASE_ORDER_CODE ,
POD.PRODUCT_REF ,
POD.PRODUCT_DESC ,
POD.QUANTITY ,
POD.NET_WEIGHT ,
POD.UNIT_PRICE_CIF_FOS ,
POD.TOTAL_AMOUNT_CIF_FOS ,
POD.CURRENCY_CODE ,
POD.CONVERSION_RATE ,
POD.PKG_CARTON ,
POD.QTY_KG ,
POD.CBM ,
POD.PKG_PCS_PER_CARTON ,
POD.PPB ,
POD.BPC ,
POD.QUOTATION_D_CODE ,
POD.ITEM_CODE ,
POD.ITEM_CATAGORY_CODE,
it.gusset,
it.length,
it.density,
it.width,
it.punchout,
it.thickness,
it.printing_charge,
it.processing_cost
from WPMS_PURCHASE_ORDER_DETAILS POD 
inner Join WPMS_PURCHASE_ORDER PO on 
PO.PURCHASE_ORDER_CODE=POD.PURCHASE_ORDER_CODE 
inner join WPMS_ITEM IT
on IT.item_code=POD.item_code

Where POD.PURCHASE_ORDER_CODE={0}", IP_ui64_ddlPOCode);
           SilkERP360.FL.WPMS.PurchaseOrderFacade lcl_obj_PurchaseOrderFacade = new SilkERP360.FL.WPMS.PurchaseOrderFacade();
           lcl_obj_PurchaseOrderFacade.Initialize();
           System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.PurchaseOrderDetails> lcl_obj_PurchaseOrderDetailsTmp = lcl_obj_PurchaseOrderFacade.GetAllPO(lcl_str_SqlQuery);

           if (IP_ui64_ddlPOCode > 0)
           {
               //SilkERP360.FL.WPMS.Mailer lcl_obj_Mailer = new SilkERP360.FL.WPMS.Mailer();
               //lcl_obj_Mailer.Send_P_O_Mail(IP_obj_Quotaion);
               return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Purchase Order Saved Successfully", true, lcl_obj_PurchaseOrderDetailsTmp);

           }
           return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

       }
    }
}
