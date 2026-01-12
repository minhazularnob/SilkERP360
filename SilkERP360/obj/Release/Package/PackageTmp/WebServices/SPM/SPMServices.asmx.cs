using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SilkERP360.WebServices.SPM
{
    /// <summary>
    /// Summary description for SPMServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SPMServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region PO & JO SERVICE
        //[System.Web.Services.WebMethod(EnableSession = true)]
        //public SilkERP360.CCL.Misc.WSResponse SaveSIMCardPO(SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder IP_obj_SpmSmPurchaseOrder, SilkERP360.CCL.BusinessEntities.SPM.SpmSmJobOrder IP_obj_ScpmSimJobOrder)
        //{
        //    try
        //    {
        //        IP_obj_ScpmPurchaseOrder.Status = CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        //IP_obj_ScpmPurchaseOrder.IsCancelled = CCL.Enums.YesNo.No;
        //        //IP_obj_ScpmPurchaseOrder.Status = CCL.Enums.YesNo.Yes;

        //        foreach (SilkERP360.CCL.BusinessEntities.SPM.SpmSmPurchaseOrderItem lcl_obj_ScpmPurchaseOrderItem in IP_obj_ScpmPurchaseOrder.PurchaseOrderItems)
        //        {
        //            lcl_obj_ScpmPurchaseOrderItem.Status = CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        }

        //        IP_obj_ScpmSimJobOrder.Status = CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        foreach (SilkERP360.CCL.BusinessEntities.SPM.SpmSmJobOrderItem lcl_obj_SpmSmJobOrderItem in IP_obj_ScpmSimJobOrder.JobOrderItems)
        //        {
        //            lcl_obj_SpmSmJobOrderItem.Status = CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        }

        //        SilkERP360.SP.SCPM.POJOServices lcl_obj_POJOService = new SP.SCPM.POJOServices();
        //        lcl_obj_POJOService.Initialize();
        //        System.UInt64 lcl_ui64_POCode = lcl_obj_POJOService.SaveSIMCardPurchaseOrder(IP_obj_ScpmPurchaseOrder, IP_obj_ScpmSimJobOrder);
        //        return null;

        //    }
        //    catch (System.Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse SaveScratchcardPO(SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder IP_obj_SpmScPurchaseOrder, SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder IP_obj_SpmScJobOrder)
        {
            SilkERP360.CCL.Misc.WSResponse lcl_obj_WSREsponse = null;
            try
            {
                //SilkERP360.CCL.Enums.SCPM.ProductType lcl_enm_POType = CCL.Enums.SCPM.ProductType.ScratchCard;
                //IP_obj_SpmScPurchaseOrder.ProductType = lcl_enm_POType;
                IP_obj_SpmScPurchaseOrder.Status = CCL.Enums.SPM.DeliveryStatus.Incomplete;
                //IP_obj_SpmScPurchaseOrder.i = CCL.Enums.YesNo.No;
                //IP_obj_ScpmPurchaseOrder.Status = CCL.Enums.YesNo.Yes;

                foreach (SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem in IP_obj_SpmScPurchaseOrder.PurchaseOrderItems)
                {
                    lcl_obj_SpmScPurchaseOrderItem.Status = CCL.Enums.SPM.DeliveryStatus.Incomplete;
                }

                IP_obj_SpmScJobOrder.Status = CCL.Enums.SPM.DeliveryStatus.Incomplete;
                //IP_obj_SpmScJobOrder.IsCancelled = CCL.Enums.YesNo.No;
                foreach (SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_SpmScJobOrderItem in IP_obj_SpmScJobOrder.ScJobOrderItems)
                {
                    lcl_obj_SpmScJobOrderItem.Status = CCL.Enums.SPM.DeliveryStatus.Incomplete;
                }

                SilkERP360.SP.SPM.PurchaseJobOrderServiceProvider lcl_obj_PurchaseJobOrderProvider = new SilkERP360.SP.SPM.PurchaseJobOrderServiceProvider();
                lcl_obj_PurchaseJobOrderProvider.Initialize();
                System.Int32 lcl_i32_Response = lcl_obj_PurchaseJobOrderProvider.SaveScratchcardPurchaseOrder(IP_obj_SpmScPurchaseOrder, IP_obj_SpmScJobOrder);
                switch (lcl_i32_Response)
                {
                    case 0:
                        lcl_obj_WSREsponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "Scratch Card Purchase Order Saved Successfully & Automated Job Order Has been Dispatched!!!", true, null);
                        break;
                    case -1:
                        lcl_obj_WSREsponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -1, "The Scratch Card P.O Ref already exists in the database!Operation Terminated!", true, null);
                        break;
                    

                }
                
                return lcl_obj_WSREsponse;

            }
            catch (System.Exception Ex)
            {
                lcl_obj_WSREsponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -100, Ex.Message, true, null);
                return lcl_obj_WSREsponse;
            }
        }
        #endregion

        #region PRODUCT SERVICES
        /// <summary>
        /// Returns 1 -> No Product Master Exists for the Selected Customer
        /// </summary>
        /// <param name="IP_ui64_CustomerCode"></param>
        /// <returns></returns>
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetProductMasterListByCustomer(System.UInt64 IP_ui64_CustomerCode)
        {
            try
            {
                SilkERP360.SP.SPM.SpmProductMasterServiceProvider lcl_obj_ProductServices = new SilkERP360.SP.SPM.SpmProductMasterServiceProvider();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SpmProductMaster> lcl_objLst_ProductMaster = lcl_obj_ProductServices.GetProductMasterListByCustomer(IP_ui64_CustomerCode);

                if (lcl_objLst_ProductMaster.Count == 0)
                {
                    return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 1, "No Product Master Exists For Selected Customer!!!", true, null);
                }
                SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Success, 0, "", true, lcl_objLst_ProductMaster);
                return lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }
        #endregion

        #region CUSTOMER SERVICES
        [System.Web.Services.WebMethod(EnableSession = true)]
        public SilkERP360.CCL.Misc.WSResponse GetCustomerDetailsByCode(System.UInt64 IP_ui64_CustomerCode)
        {
            try
            {
                //SilkERP360.SP.SCPM.CustomerServices lcl_obj_CustomerService = new SP.SCPM.CustomerServices();
                //SilkERP360.CCL.Misc.WSResponse lcl_obj_WSResponse = lcl_obj_CustomerService.GetCustomerDetailsByCode(IP_ui64_CustomerCode);
                return null;// lcl_obj_WSResponse;
            }
            catch (System.Exception Ex)
            {
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, "Unknown Error : " + Ex.Message, false, null);
            }
        }
        #endregion CUSTOMER SERVICES
    }
}
