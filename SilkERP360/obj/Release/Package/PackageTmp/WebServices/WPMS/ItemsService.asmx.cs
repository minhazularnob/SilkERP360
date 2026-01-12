using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.WPMS
{
    /// <summary>
    /// Summary description for ItemsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ItemsService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveItemsList(System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> IP_objLst_ItemsList)
        {
            throw new NotImplementedException();
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveItems(SilkERP360.CCL.BusinessEntities.WPMS.SalesContract IP_obj_SalesContract)
        {
            try
            {
                SilkERP360.FL.WPMS.SalesContractFacade lcl_obj_SalesContractFacade = new SilkERP360.FL.WPMS.SalesContractFacade();
                System.UInt64 lcl_ui64_SalesContractFacade = lcl_obj_SalesContractFacade.Save(IP_obj_SalesContract);
                if (lcl_ui64_SalesContractFacade > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "SalesContract Saved Successfully", true, lcl_ui64_SalesContractFacade);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse CustomerSave(SilkERP360.CCL.BusinessEntities.WPMS.Buyer IP_obj_Buyer)
        {
            try
            {
                SilkERP360.FL.WPMS.BuyerFacade lcl_obj_CustomerFacade = new SilkERP360.FL.WPMS.BuyerFacade();
                System.UInt64 lcl_ui64_CustomerFacade = lcl_obj_CustomerFacade.Save(IP_obj_Buyer);
                if (lcl_ui64_CustomerFacade > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Buyer Information Saved Successfully", true, lcl_ui64_CustomerFacade);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse QuotationSave(SilkERP360.CCL.BusinessEntities.WPMS.Quotation IP_obj_Quotaion)
        {          
            
            try
            {
                SilkERP360.FL.WPMS.QuotationFacade lcl_obj_QuotationFacade = new SilkERP360.FL.WPMS.QuotationFacade();
                System.UInt64 lcl_ui64_QuotationFacade = lcl_obj_QuotationFacade.Save(IP_obj_Quotaion);

                
                if (lcl_ui64_QuotationFacade > 0)
                {
                    //SilkERP360.FL.WPMS.Mailer lcl_obj_Mailer = new SilkERP360.FL.WPMS.Mailer();
                    //lcl_obj_Mailer.Send_P_O_Mail(IP_obj_Quotaion);
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Quotation Saved Successfully", true, lcl_ui64_QuotationFacade);
                  
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);
                
            }
               
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public SilkERP360.CCL.Misc.WSResponse Retrive(System.UInt64 IP_ui64_QuotationCode)
        //{
        //    try
        //    {
                                
        //        SilkERP360.FL.WPMS.QuotationDetailsFacade lcl_obj_QuotationDetailsFacade = new SilkERP360.FL.WPMS.QuotationDetailsFacade();
        //        System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> lcl_objLst_QuotationDetails =
        //        lcl_obj_QuotationDetailsFacade.GetAllDesignationWise(IP_ui64_QuotationCode);
        //        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_QuotationDetails);
        //    }
        //    catch (System.Exception Ex)
        //    {
        //        return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
        //    }
        //}

        public SilkERP360.CCL.Misc.WSResponse NewPrice(SilkERP360.CCL.BusinessEntities.WPMS.RawMaterials IP_obj_RawMaterials)
        {
            try
            {
                SilkERP360.FL.WPMS.RawMaterialsFacade lcl_obj_RawMaterialsFacade = new SilkERP360.FL.WPMS.RawMaterialsFacade();
                System.UInt64 lcl_ui64_RawMaterialsFacade = lcl_obj_RawMaterialsFacade.Save(IP_obj_RawMaterials);
                if (lcl_ui64_RawMaterialsFacade > 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "New Price Update Successfully", true, lcl_ui64_RawMaterialsFacade);
                }
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Critical Unknown Error!", false, null);

            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadQuotationInfoQuotatioCode(System.UInt64 IP_ui64_QuotationCode)
        {
           try 
            {
                SilkERP360.FL.WPMS.QuotationFacade lcl_obj_QuotationFacade = new SilkERP360.FL.WPMS.QuotationFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Quotation> lcl_objLst_Quotation =
                lcl_obj_QuotationFacade.GetAllDesignationWise(IP_ui64_QuotationCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }

       

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadCustomerInfoCreateQuotatio(System.UInt64 IP_obj_ddlCustomerCode)
        {
            try
            {
                SilkERP360.FL.WPMS.BuyerFacade lcl_obj_BuyerFacade = new SilkERP360.FL.WPMS.BuyerFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Buyer> lcl_objLst_Quotation =
                lcl_obj_BuyerFacade.GetAllDesignationWise(IP_obj_ddlCustomerCode);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_Quotation);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse LoadItemSize(System.UInt64 IP_obj_ddlSizeSpecification)
        {
            try
            {
                SilkERP360.FL.WPMS.ItemFacade lcl_obj_ItemFacade = new SilkERP360.FL.WPMS.ItemFacade();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.Item> lcl_objLst_ItemFacade =
                lcl_obj_ItemFacade.GetAllDesignationWise(IP_obj_ddlSizeSpecification);

                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_ItemFacade);
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, Ex.Message, false, null);
            }
        }
    }
}