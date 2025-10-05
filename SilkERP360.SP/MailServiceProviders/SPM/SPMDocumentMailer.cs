using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.SP.MailServiceProviders.SPM
{
    public class SPMDocumentMailer : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public SPMDocumentMailer()
        {
            this.Initialize();
        }
        public void MailScratchCardPO(System.UInt64 IP_ui64_SCPurchaseOrderCode, DAL.DBManager IP_obj_DBManager)
        {
            System.Int32 lcl_i32_Return = this.ExceptionManager.Process<System.Int32>(() =>
            {
                System.String lcl_str_DBQuery = "";
                SilkERP360.BML.SPM.SC.SpmScPurchaseOrderManager lcl_obj_SpmScPurchaseOrderManager = new BML.SPM.SC.SpmScPurchaseOrderManager();
                lcl_obj_SpmScPurchaseOrderManager.Initialize();
                SilkERP360.BML.SPM.SC.SpmScPurchaseOrderItemManager lcl_obj_SpmScPurchaseOrderItemManager = new BML.SPM.SC.SpmScPurchaseOrderItemManager();
                lcl_obj_SpmScPurchaseOrderItemManager.Initialize();
                SilkERP360.BML.SPM.SC.SpmScJobOrderManager lcl_obj_SpmScJobOrderManager = new BML.SPM.SC.SpmScJobOrderManager();
                lcl_obj_SpmScJobOrderManager.Initialize();
                SilkERP360.BML.SPM.SC.SpmScJobOrderItemManager lcl_obj_SpmScJobOrderItemManager = new BML.SPM.SC.SpmScJobOrderItemManager();
                lcl_obj_SpmScJobOrderItemManager.Initialize();
                SilkERP360.BML.SPM.SpmCustomerManager lcl_obj_SpmCustomerManager = new BML.SPM.SpmCustomerManager();
                lcl_obj_SpmCustomerManager.Initialize();
                SilkERP360.BML.SPM.SpmProductMasterManager lcl_obj_SpmProductMasterManager = new BML.SPM.SpmProductMasterManager();
                lcl_obj_SpmProductMasterManager.Initialize();

                CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrder lcl_obj_SpmScPurchaseOrder = lcl_obj_SpmScPurchaseOrderManager.Get(IP_ui64_SCPurchaseOrderCode, IP_obj_DBManager);
                lcl_str_DBQuery = System.String.Format("SELECT * FROM SPM_SC_PURCHASE_ORDER_ITEM WHERE SC_PURCHASE_ORDER_CODE = {0}",lcl_obj_SpmScPurchaseOrder.ScPurchaseOrderCode);
                lcl_obj_SpmScPurchaseOrder.PurchaseOrderItems = lcl_obj_SpmScPurchaseOrderItemManager.GetList(lcl_str_DBQuery, IP_obj_DBManager);

                lcl_str_DBQuery = System.String.Format("SELECT * FROM SPM_SC_JOB_ORDER WHERE SC_PURCHASE_ORDER_CODE = {0}", lcl_obj_SpmScPurchaseOrder.ScPurchaseOrderCode);
                CCL.BusinessEntities.SPM.SC.SpmScJobOrder lcl_obj_SpmScJobOrder = lcl_obj_SpmScJobOrderManager.Get(lcl_str_DBQuery, IP_obj_DBManager);
                
                lcl_str_DBQuery = System.String.Format("SELECT * FROM SPM_SC_JOB_ORDER_ITEM WHERE SC_JOB_ORDER_CODE = {0}", lcl_obj_SpmScJobOrder.ScJobOrderCode);
                lcl_obj_SpmScJobOrder.ScJobOrderItems = lcl_obj_SpmScJobOrderItemManager.GetList(lcl_str_DBQuery, IP_obj_DBManager);

                CCL.BusinessEntities.SPM.SpmCustomer lcl_obj_Customer = lcl_obj_SpmCustomerManager.Get(lcl_obj_SpmScPurchaseOrder.CustomerCode, IP_obj_DBManager);

                System.String lcl_str_HTMLReport = "";
                /**************************************************************************************************************************/
                #region MAIL FORMAT
                lcl_str_HTMLReport = @"<style type='text/css'>
        .report_head
        {
            width:100%;
            font-size:12px;
        }
        
        .report_head tr
        {
            
        }
        
        .report_head tr td
        {
            border:1px solid #cccccc  ;
        }
        
        .report_header_label
        {
            text-align:left;
            /*border:1px solid #F8F8F8  ;*/
            font-weight:bold;
            font-family:Verdana;
            color: #ffffff;
            background-color:#66cc33;
            border:1px solid #cccccc;

        }

        .report_header_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;

        }

        
        .report_summery_label
        {
            text-align:right;
            color: #ffffff;
            background-color:#66cc33;
            font-weight:bold;
            border:1px solid #cccccc;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_summery_text
        {
            text-align:left;
            border:1px solid #aaaaaa  ;
            background-color:#ffffff;
            color: #000;
            font-weight:normal;
            border:1px solid #aaaaaa;
            font-family:Verdana;
            font-size:12px;
        }
        
        .report_grid_text
        {
            text-align:center;
             border:1px solid #cccccc  ;
            background-color:#FFFFFF;
            color: #000;
            font-weight:normal;
            font-family:Verdana;
        }
        .report_grid_header
        {
            line-height:25px;
            text-align:center;
             border:1px solid #F8F8F8  ;
            background-color:#3399FF;
            color: #ffffff;
            font-weight:bold;
            font-size:14px;
            border:1px solid black;
            font-family:Verdana;
        }
        .report_body
        {
            width:100%;
            font-size:10px;
             font-family:Verdana;
            
        }
        
    </style>";

                lcl_str_HTMLReport += System.String.Format(@"
                                                            <div>
                                                                <div id='dvBody' style=' width:100%; border:1px solid gray; font-size:12px; font-family:Arial;'>
                                                                    <table id='tblReportHead' class='report_head' style='width:100%;'>
                                                                        <tr style=''>    
                                                                            <td class='report_header_label' style='width:25%'>
                                                                                System :
                                                                            </td>
                                                                            <td class='report_header_text'  style='width:75%;'>
                                                                                SilkERP360-Silkcard Production Management System (S.P.M) v.1.0
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Report Title : 
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                                New Purchase Order For Scratch Card
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                               P.O Date
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            {0}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                Telco :
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            {1}
                                                                            </td>
                                                                        </tr>
                                                                        <tr>    
                                                                            <td class='report_header_label'>
                                                                                P.O Ref 
                                                                            </td>
                                                                            <td style='text-align:left;'>
                                                                            {2}
                                                                            </td>
                                                                        </tr>
                                                                    </table>", lcl_obj_SpmScPurchaseOrder.IssueDate.ToLongDateString(),
                                                                             lcl_obj_Customer.CompanyName,
                                                                             lcl_obj_SpmScPurchaseOrder.PoRefNumber);
                lcl_str_HTMLReport += @"<table id='GridTableStyle' class='report_body'>
                                            <tr style=''>    
                                                <td class='report_grid_header' style='width:5%'>
                                                    SL
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    Code
                                                </td>
                                                <td class='report_grid_header' style='width:25%'>
                                                    Product (S.C)
                                                </td>
                                                <td class='report_grid_header' style='width:20%'>
                                                    Deno.
                                                </td>
                                                <td class='report_grid_header' style='width:20%'>
                                                    M.Unit
                                                </td>
                                                <td class='report_grid_header' style='width:5%'>
                                                    Quantity
                                                </td>
                                                <td class='report_grid_header' style='width:10%'>
                                                    Del. Date
                                                </td>
                                                <td class='report_grid_header' style='width:5%'>
                                                    Status
                                                </td>
                                             </tr>";
                System.UInt32 lcl_ui32_Sequence = 1;
                System.String lcl_str_Denomination = "";
                System.String lcl_str_MeasurementUnit = "";
                System.String lcl_str_Status = "";
                foreach (CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem lcl_obj_SpmScPurchaseOrderItemTmp in lcl_obj_SpmScPurchaseOrder.PurchaseOrderItems)
                {
                    CCL.BusinessEntities.SPM.SpmProductMaster lcl_obj_SpmProductMaster = lcl_obj_SpmProductMasterManager.Get(lcl_obj_SpmScPurchaseOrderItemTmp.SpmProductCode, IP_obj_DBManager);
                    
                    switch(lcl_obj_SpmScPurchaseOrderItemTmp.Denomination)
                    {
                        case CCL.Enums.SPM.ScratchCardDenomination.None:
                            lcl_str_Denomination = "None";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.OneInOne:
                            lcl_str_Denomination = "1x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.TwoInOne:
                            lcl_str_Denomination = "2x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.ThreeInOne:
                            lcl_str_Denomination = "3x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.FourInOne:
                            lcl_str_Denomination = "4x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.FiveInOne:
                            lcl_str_Denomination = "5x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.SixInOne:
                            lcl_str_Denomination = "6x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.SevenInOne:
                            lcl_str_Denomination = "7x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.EightInOne:
                            lcl_str_Denomination = "8x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.NineInOne:
                            lcl_str_Denomination = "9x1";
                            break;
                        case CCL.Enums.SPM.ScratchCardDenomination.TenInOne:
                            lcl_str_Denomination = "10x1";
                            break;
                    }

                    switch(lcl_obj_SpmScPurchaseOrderItemTmp.MeasurementUnit)
                    {
                        case CCL.Enums.SPM.SpmMeasurementUnit.None:
                            lcl_str_MeasurementUnit = "None";
                            break;
                        case CCL.Enums.SPM.SpmMeasurementUnit.Piece:
                            lcl_str_MeasurementUnit = "PCS";
                            break;
                        case CCL.Enums.SPM.SpmMeasurementUnit.PIN:
                            lcl_str_MeasurementUnit = "PIN";
                            break;
                    }

                    switch(lcl_obj_SpmScPurchaseOrderItemTmp.Status)
                    {
                        case CCL.Enums.SPM.DeliveryStatus.None:
                            lcl_str_Status = "None";
                            break;
                        case CCL.Enums.SPM.DeliveryStatus.Complete:
                            lcl_str_Status = "C";
                            break;
                        case CCL.Enums.SPM.DeliveryStatus.Incomplete:
                            lcl_str_Status = "I.C";
                            break;
                    }

                    lcl_str_HTMLReport += System.String.Format(@"<tr style=''>    
                                                <td class='report_grid_text' style=''>
                                                    {0}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {1}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {2}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {3}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {4}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {5}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {6}
                                                </td>
                                                <td class='report_grid_text' style=''>
                                                    {7}
                                                </td>
                                               
                                             </tr>", lcl_ui32_Sequence.ToString(),
                                                  lcl_obj_SpmScPurchaseOrderItemTmp.SpmProductCode,
                                                  lcl_obj_SpmProductMaster.ProductName,
                                                  lcl_str_Denomination,
                                                  lcl_str_MeasurementUnit,
                                                  lcl_obj_SpmScPurchaseOrderItemTmp.Quantity.ToString(),
                                                  lcl_obj_SpmScPurchaseOrderItemTmp.DeliveryStartDate.ToShortDateString(),
                                                  lcl_str_Status);


                    lcl_ui32_Sequence++;

                }
                lcl_str_HTMLReport += "</table></div></div>";
                #endregion

                //Get Mail To for Scratchcard P.O
                lcl_str_DBQuery = "SELECT * FROM AUTO_MAIL_LIST WHERE SC_PO_TO = 1 or SC_PO_CC = 1";
                System.Collections.Generic.List<System.String> lcl_obj_SCPOTOList = new List<string>();
                System.Collections.Generic.List<System.String> lcl_obj_SCPOCCList = new List<string>();
                System.Data.OracleClient.OracleDataReader lcl_obj_MailListReader = IP_obj_DBManager.ExecuteDataReader(lcl_str_DBQuery);
                if (!(lcl_obj_MailListReader.HasRows))
                {
                    return -1;
                }

                while (lcl_obj_MailListReader.Read())
                {
                    if(System.Int32.Parse(lcl_obj_MailListReader["SC_PO_TO"].ToString()) == 1)
                    {
                        lcl_obj_SCPOTOList.Add(lcl_obj_MailListReader["MAIL_ID"].ToString());
                    }
                    if (System.Int32.Parse(lcl_obj_MailListReader["SC_PO_CC"].ToString()) == 1)
                    {
                        lcl_obj_SCPOCCList.Add(lcl_obj_MailListReader["MAIL_ID"].ToString());
                    }
                }

                lcl_obj_MailListReader.Close();

                SP.MailServiceProviders.Mailer lcl_obj_Mailer = new Mailer(lcl_obj_SCPOTOList, lcl_obj_SCPOCCList);
                //Send Mail Asynchronously.Fire and forget
                new Task(() => { lcl_obj_Mailer.SendMail("New Scratchcard (S.C) Purchase Order From " + lcl_obj_Customer.CompanyName, lcl_str_HTMLReport); }).Start();
                //lcl_obj_Mailer.SendMail("New Scratchcard (S.C) Purchase Order From " + lcl_obj_Customer.CompanyName, lcl_str_HTMLReport);
                return 0;
            }, "SPExceptionPolicy");
        }

    }
}
