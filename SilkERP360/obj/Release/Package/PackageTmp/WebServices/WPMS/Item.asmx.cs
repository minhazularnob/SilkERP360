using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for Item
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Item : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> IP_objLst_Item, System.Boolean IP_b_AutoItemCode)
        {
            SilkERP360.FL.SqlFacade lcl_obj_SqlFacade = new SilkERP360.FL.SqlFacade();
            try
            {
              
                SilkERP360.FL.WPMS.ItemFacade lcl_obj_ItemFacade = new SilkERP360.FL.WPMS.ItemFacade();

                lcl_obj_ItemFacade.Initialize();

                System.Collections.Generic.List<UInt64> lcl_ui64List_ItemCodes = lcl_obj_ItemFacade.SaveList(IP_objLst_Item, IP_b_AutoItemCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Item Saved Successfully", true, lcl_ui64List_ItemCodes);
            }

      
 
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadItem(System.UInt64 IP_ui64_BuyerCode, System.UInt64 IP_ui64_CatagoryCode)
        {
            try{
              System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_ItemList = null;

//              System.String lcl_str_SqlQuery = System.String.Format(@"Select ITEM_CODE
//,ITEM_CATAGORY_CODE
//,BUYER_CODE
//,PROCESSING_COST
//,PRINTING_CHARGE
//,IS_ACTIVE
//,WIDTH
//,LENGTH
//,GUSSET
//,DENSITY
//,THICKNESS
//,ITEM_NAME
//,PUNCHOUT
//,IP_EMPLOYEE_CODE
//,IP_DATE
//,ITEM_REF_CODE FROM WPMS_ITEM where BUYER_CODE={0} and ITEM_CATAGORY_CODE= {1}", IP_ui64_BuyerCode, IP_ui64_CatagoryCode);
              System.String lcl_str_SqlQuery = System.String.Format(@"Select * from WPMS_ITEM where BUYER_CODE={0} and ITEM_CATAGORY_CODE= {1}", IP_ui64_BuyerCode, IP_ui64_CatagoryCode);
           SilkERP360.FL.WPMS.ItemFacade lcl_obj_ItemFacade = new SilkERP360.FL.WPMS.ItemFacade();
           lcl_obj_ItemFacade.Initialize();
           lcl_obj_ItemList =lcl_obj_ItemFacade.GetList(lcl_str_SqlQuery);

           if (lcl_obj_ItemList.Count == 0)
           {
               return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, -1, "", false, lcl_obj_ItemList);
           }
           return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_ItemList);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadItemSpec(System.UInt64 IP_obj_ddlItemSpec)
        {
            try
            {
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_obj_ItemList = null;

                System.String lcl_str_SqlQuery = System.String.Format(@"Select ITEM_CODE
,ITEM_CATAGORY_CODE
,BUYER_CODE
,PROCESSING_COST
,PRINTING_CHARGE
,IS_ACTIVE
,WIDTH
,LENGTH
,GUSSET
,DENSITY
,THICKNESS
,ITEM_NAME
,PUNCHOUT
,IP_EMPLOYEE_CODE
,IP_DATE
,ITEM_REF_CODE FROM WPMS_ITEM where ITEM_CODE={0}", IP_obj_ddlItemSpec);
                SilkERP360.FL.WPMS.ItemFacade lcl_obj_ItemFacade = new SilkERP360.FL.WPMS.ItemFacade();
                lcl_obj_ItemFacade.Initialize();
                lcl_obj_ItemList = lcl_obj_ItemFacade.GetList(lcl_str_SqlQuery);


                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", false, lcl_obj_ItemList);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}
