using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.SPM
{
    public class PurchaseJobOrderServiceProvider : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public PurchaseJobOrderServiceProvider()
        {
            this.Initialize();
        }

        /// <summary>
        /// Gets the Detail of the PO IP_ui64_PurchaseOrder and returns HTML of the formatted Mail
        /// </summary>
        /// <param name="IP_ui64_PurchaseOrderCode"></param>
        /// <param name="IP_obj_DBManager"></param>
        /// <returns></returns>
        //public System.String GetScratchCardPurchaseOrderHTMLMail(System.UInt64 IP_ui64_PurchaseOrderCode, DAL.DBManager IP_obj_DBManager)
        //{
        //    System.String lcl_str_HTML = this.ExceptionManager.Process<System.String>(() =>
        //    {
        //    }, "SPExceptionPolicy");
        //    return lcl_str_HTML;
        //}
        
        


        /// <summary>
        /// 1. Check If PO Reference already been saved in the system
        /// </summary>
        /// <param name="IP_obj_ScpmPurchaseOrder"></param>
        /// <param name="IP_obj_ScpmSimJobOrder"></param>
        /// <returns>
        /// -1 -> If PO Already exists in database
        /// > 1 when The POCode is returned
        /// </returns>
        public System.Int32 SaveScratchcardPurchaseOrder(SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder IP_obj_SpmScPurchaseOrder, SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrder IP_obj_SpmScJobOrder)
        {
            System.Int32 lcl_ui64_ScPurchaseOrderCode = this.ExceptionManager.Process<System.Int32>(() =>
            {
                System.UInt64 lcl_ui64_ScPurchaseOrderCodeTmp = 0;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_DBQuery = System.String.Format("SELECT * FROM SPM_SC_PURCHASE_ORDER WHERE PO_REF_NUMBER = '{0}'", IP_obj_SpmScPurchaseOrder.PoRefNumber);
                    System.Data.OracleClient.OracleDataReader lcl_obj_POReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_DBQuery);
                    if (lcl_obj_POReader.HasRows == true)
                    {
                        //P.O Already exists in the database
                        lcl_obj_POReader.Close();
                        return -1;
                    }
                    lcl_obj_POReader.Close();
                    IP_obj_SpmScPurchaseOrder.EntryDate = System.DateTime.Today;
                    SilkERP360.BML.SPM.SC.SpmScPurchaseOrderManager lcl_obj_SpmScPurchaseOrderManager = new BML.SPM.SC.SpmScPurchaseOrderManager();
                    lcl_obj_SpmScPurchaseOrderManager.Initialize();
                    lcl_ui64_ScPurchaseOrderCodeTmp = lcl_obj_SpmScPurchaseOrderManager.Save(IP_obj_SpmScPurchaseOrder, lcl_obj_DBManager.InternalResource);
                    //Save PurchaseOrderItems
                    SilkERP360.BML.SPM.SC.SpmScPurchaseOrderItemManager lcl_obj_SpmScPurchaseOrderItemManager = new BML.SPM.SC.SpmScPurchaseOrderItemManager();
                    lcl_obj_SpmScPurchaseOrderItemManager.Initialize();

                    
                    foreach (SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem in IP_obj_SpmScPurchaseOrder.PurchaseOrderItems)
                    {
                        lcl_obj_SpmScPurchaseOrderItem.ScPurchaseOrderCode = lcl_ui64_ScPurchaseOrderCodeTmp;
                        lcl_obj_SpmScPurchaseOrderItem.ScPurchaseOrderItemCode = lcl_obj_SpmScPurchaseOrderItemManager.Save(lcl_obj_SpmScPurchaseOrderItem, lcl_obj_DBManager.InternalResource);
                    }

                    //Save SCPM JobOrder
                    IP_obj_SpmScJobOrder.ScPurchaseOrderCode = IP_obj_SpmScPurchaseOrder.ScPurchaseOrderCode;
                    //Assign the ScpmPOItemCode
                    foreach (SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_SpmScJobOrderItem in IP_obj_SpmScJobOrder.ScJobOrderItems)
                    {

                        foreach (SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItem in IP_obj_SpmScPurchaseOrder.PurchaseOrderItems)
                        {
                            if (lcl_obj_SpmScJobOrderItem.SpmProductCode == lcl_obj_SpmScPurchaseOrderItem.SpmProductCode)
                            {
                                //lcl_obj_SpmScJobOrderItem.DeliveryStartDate = lcl_obj_SpmScPurchaseOrderItem.DeliveryStartDate;
                                lcl_obj_SpmScJobOrderItem.ScPurchaseOrderItemCode = lcl_obj_SpmScPurchaseOrderItem.ScPurchaseOrderItemCode;
                                lcl_obj_SpmScJobOrderItem.ScPurchaseOrderCode = lcl_obj_SpmScPurchaseOrderItem.ScPurchaseOrderCode;
                            }
                        }
                    }

                    //Save the Job Order
                    //Assign PurchaseOrder Codes/PurchaseOrder Items Code
                    /****************************************************************************************************************************/
                    //Generate the Job Order Ref Code
                    //Get Customer Details
                    System.Int32 lcl_i32_CurrentYear = System.DateTime.Now.Year;
                    System.Int32 lcl_i32_ScJobOrderCount = 0;
                    BML.SPM.SpmCustomerManager lcl_obj_SpmCustomer_Manager = new BML.SPM.SpmCustomerManager();
                    lcl_obj_SpmCustomer_Manager.Initialize();
                    CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_SpmCustomer = lcl_obj_SpmCustomer_Manager.Get(IP_obj_SpmScPurchaseOrder.CustomerCode, lcl_obj_DBManager.InternalResource);
                    if (lcl_obj_SpmCustomer == null)
                    {
                        throw new System.Exception("Customer Company Data Could Not Be retrieved!!!");
                    }
                    //get Job Order sequence for running year
                    lcl_str_DBQuery = System.String.Format("SELECT COUNT(*) AS JOB_ORDER_COUNT FROM SPM_SC_JOB_ORDER WHERE CUSTOMER_CODE = {0} AND TO_NUMBER(TO_CHAR(ISSUE_DATE,'YYYY')) = {1}", IP_obj_SpmScPurchaseOrder.CustomerCode, lcl_i32_CurrentYear);
                    System.Data.OracleClient.OracleDataReader lcl_obj_JobOrderCountReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_DBQuery);
                    if (!(lcl_obj_JobOrderCountReader.HasRows))
                    {
                        lcl_i32_ScJobOrderCount = 1;
                    }
                    else
                    {
                        lcl_obj_JobOrderCountReader.Read();
                        lcl_i32_ScJobOrderCount = System.Int32.Parse(lcl_obj_JobOrderCountReader["JOB_ORDER_COUNT"].ToString());
                    }
                    lcl_obj_JobOrderCountReader.Close();
                    
                    if (lcl_i32_CurrentYear == 2015)
                    {
                        //Get JobOrder Seed from Customer Table
                        lcl_i32_ScJobOrderCount += (int)lcl_obj_SpmCustomer.ScJobOrderSeed;
                    }
                    lcl_i32_ScJobOrderCount++;
                    IP_obj_SpmScJobOrder.ScJobOrderRef = System.String.Format("MKT02-{0}-{1}", lcl_obj_SpmCustomer.ShortName, lcl_i32_ScJobOrderCount.ToString());
                    //IP_obj_SpmScJobOrder.ScPurchaseOrderCode = 
                    /****************************************************************************************************************************/
                    IP_obj_SpmScJobOrder.EntryDate = System.DateTime.Today;
                    IP_obj_SpmScJobOrder.IssueDate = System.DateTime.Today;
                    SilkERP360.BML.SPM.SC.SpmScJobOrderManager lcl_obj_SpmScJobOrderManager = new BML.SPM.SC.SpmScJobOrderManager();
                    lcl_obj_SpmScJobOrderManager.Initialize();
                    IP_obj_SpmScJobOrder.ScJobOrderCode = lcl_obj_SpmScJobOrderManager.Save(IP_obj_SpmScJobOrder, lcl_obj_DBManager.InternalResource);

                    //Save ScJobOrderItem
                    SilkERP360.BML.SPM.SC.SpmScJobOrderItemManager lcl_obj_ScJobOrderItemManager = new BML.SPM.SC.SpmScJobOrderItemManager();
                    lcl_obj_ScJobOrderItemManager.Initialize();

                    foreach (CCL.BusinessEntities.SPM.SC.SpmScJobOrderItem lcl_obj_ScJobOrderItem in IP_obj_SpmScJobOrder.ScJobOrderItems)
                    {
                        
                        lcl_obj_ScJobOrderItem.ScJobOrderCode = IP_obj_SpmScJobOrder.ScJobOrderCode;
                        lcl_obj_ScJobOrderItemManager.Save(lcl_obj_ScJobOrderItem,lcl_obj_DBManager.InternalResource);
                    }
                    //lcl_obj_DBManager.InternalResource.CommitTransaction();
                    //lcl_obj_DBManager.InternalResource.Close();
                    //lcl_obj_DBManager.InternalResource.Open();
                    //Mail Purchase Order
                    SP.MailServiceProviders.SPM.SPMDocumentMailer lcl_obj_SPMDocumentMailer = new MailServiceProviders.SPM.SPMDocumentMailer();
                    lcl_obj_SPMDocumentMailer.MailScratchCardPO(IP_obj_SpmScPurchaseOrder.ScPurchaseOrderCode, lcl_obj_DBManager.InternalResource);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();

                }
                return 0;
            }, "SPExceptionPolicy");
            return lcl_ui64_ScPurchaseOrderCode;
        }

        /// <summary>
        /// 1. Check If PO Reference already been saved in the system
        /// </summary>
        /// <param name="IP_obj_ScpmPurchaseOrder"></param>
        /// <param name="IP_obj_ScpmSimJobOrder"></param>
        /// <returns>
        /// 1 -> If PO Already exists in database
        /// > 1 when The POCode is returned
        /// </returns>
        public System.UInt64 SaveSIMCardPurchaseOrder(SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrder IP_obj_SpmSmPurchaseOrder, SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrder IP_obj_SpmSmJobOrder)
        {
            System.UInt64 lcl_ui64_PurchaseOrderCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                System.UInt64 lcl_ui64_PurchaseOrderCodeTmp = 0;
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    System.String lcl_str_DBQuery = System.String.Format("SELECT * FROM SPM_SM_PURCHASE_ORDER WHERE PO_REF_NUMBER = '{0}'", IP_obj_SpmSmPurchaseOrder.PoRefNumber);
                    System.Data.OracleClient.OracleDataReader lcl_obj_POReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_DBQuery);
                    if (lcl_obj_POReader.HasRows == true)
                    {
                        //P.O Already exists in the database
                        lcl_obj_POReader.Close();
                        return 1;
                    }
                    lcl_obj_POReader.Close();

                    SilkERP360.BML.SPM.SM.SpmSmPurchaseOrderManager lcl_obj_SpmSmPurchaseOrderManager = new BML.SPM.SM.SpmSmPurchaseOrderManager();
                    lcl_obj_SpmSmPurchaseOrderManager.Initialize();
                    lcl_ui64_PurchaseOrderCodeTmp = lcl_obj_SpmSmPurchaseOrderManager.Save(IP_obj_SpmSmPurchaseOrder, lcl_obj_DBManager.InternalResource);

                    //Save SCPM JobOrder
                    IP_obj_SpmSmJobOrder.SmPurchaseOrderCode = IP_obj_SpmSmPurchaseOrder.SmPurchaseOrderCode;
                    //Assign the ScpmPOItemCode
                    foreach (SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmJobOrderItem lcl_obj_SpmSmJobOrderItem in IP_obj_SpmSmJobOrder.SmJobOrderItems)
                    {
                        foreach (SilkERP360.CCL.BusinessEntities.SPM.SM.SpmSmPurchaseOrderItem lcl_obj_SpmSmPurchaseOrderItem in IP_obj_SpmSmPurchaseOrder.PurchaseOrderItems)
                        {
                            if (lcl_obj_SpmSmPurchaseOrderItem.SmProductCode == lcl_obj_SpmSmPurchaseOrderItem.SmProductCode)
                            {
                                lcl_obj_SpmSmJobOrderItem.SmPurchaseOrderItemCode = lcl_obj_SpmSmPurchaseOrderItem.SmPurchaseOrderItemCode;
                            }
                        }
                    }

                    //Save the Job Order
                    SilkERP360.BML.SPM.SM.SpmSmJobOrderManager lcl_obj_SpmSmJobOrderManager = new BML.SPM.SM.SpmSmJobOrderManager();
                    lcl_obj_SpmSmJobOrderManager.Initialize();
                    lcl_obj_SpmSmJobOrderManager.Save(IP_obj_SpmSmJobOrder, lcl_obj_DBManager.InternalResource);

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    lcl_obj_DBManager.InternalResource.Close();

                }
                return lcl_ui64_PurchaseOrderCodeTmp;
            }, "SPExceptionPolicy");
            return lcl_ui64_PurchaseOrderCode;
        }
    }
}
