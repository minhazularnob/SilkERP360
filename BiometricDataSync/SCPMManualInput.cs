using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace BiometricDataSync
{
    public class SCPMManualInput
    {
        //public void InsertSCPMCustomer(SilkERP360.DAL.DBManager IP_obj_DBManager)
        //{
        //    try
        //    {
        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmCustomer lcl_obj_Customer = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmCustomer();
        //        lcl_obj_Customer.CustomerCompanyName = "Citycell Ltd";
        //        lcl_obj_Customer.Address = "Basundhara; Dhaka";
        //        lcl_obj_Customer.CompanyCode = 110000000001;
        //        lcl_obj_Customer.IsActive = SilkERP360.CCL.Enums.YesNo.Yes;

        //        SilkERP360.BML.SCPM.ScpmCustomerManager lcl_obj_CustomerManager = new SilkERP360.BML.SCPM.ScpmCustomerManager();
        //        lcl_obj_CustomerManager.Save(lcl_obj_Customer, IP_obj_DBManager);


        //        //lcl_obj_ScpmProductMaster.
        //    }
        //    catch (System.Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        //public void InsertSCPMProducts(SilkERP360.DAL.DBManager IP_obj_DBManager)
        //{
        //    try
        //    {
        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmProductMaster lcl_obj_SCPMProductMaster = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmProductMaster();
        //        lcl_obj_SCPMProductMaster.CustomerCode = 1007;
        //        lcl_obj_SCPMProductMaster.EntryEmployeeCode = 1010000000001;
        //        lcl_obj_SCPMProductMaster.ProductName = "Scratch Off Card Tk.50";
        //        lcl_obj_SCPMProductMaster.ProductType = SilkERP360.CCL.Enums.SCPM.ProductType.ScratchCard;
        //        lcl_obj_SCPMProductMaster.Denomination = SilkERP360.CCL.Enums.SCPM.Denomination.FourInOne;
        //        lcl_obj_SCPMProductMaster.Specification = "As per spec";
        //        lcl_obj_SCPMProductMaster.IsActive = SilkERP360.CCL.Enums.YesNo.Yes;

        //        SilkERP360.BML.SCPM.ScpmProductMasterManager lcl_obj_ScpmProductMasterManager = new SilkERP360.BML.SCPM.ScpmProductMasterManager();
        //        lcl_obj_ScpmProductMasterManager.Initialize();
        //        lcl_obj_ScpmProductMasterManager.Save(lcl_obj_SCPMProductMaster, IP_obj_DBManager);
        //    }
        //    catch (System.Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        //public void InsertSCPMPurchaseOrder(SilkERP360.DAL.DBManager IP_obj_DBManager)
        //{
        //    try
        //    {
        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrder lcl_obj_SCPMPurchaseOrder = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrder();
        //        lcl_obj_SCPMPurchaseOrder.CustomerCode = 1007;//ROBI
        //        lcl_obj_SCPMPurchaseOrder.ProductType = SilkERP360.CCL.Enums.SCPM.ProductType.ScratchCard;
        //        lcl_obj_SCPMPurchaseOrder.PORefCode = "4500033015";
        //        lcl_obj_SCPMPurchaseOrder.IssueDate = System.DateTime.ParseExact("22/10/2014", "dd/M/yyyy", CultureInfo.InvariantCulture);
        //        lcl_obj_SCPMPurchaseOrder.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_SCPMPurchaseOrder.Status = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_SCPMPurchaseOrder.Remarks = "";
        //        lcl_obj_SCPMPurchaseOrder.IsCancelled = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_SCPMPurchaseOrder.EntryEmployeeCode = 101000000001;

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem lcl_obj_ScpmPurchaseOrderItem1 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem();
        //        lcl_obj_ScpmPurchaseOrderItem1.ProductCode = 20000100000000007;
        //        lcl_obj_ScpmPurchaseOrderItem1.Description = "";
        //        lcl_obj_ScpmPurchaseOrderItem1.Quantity = 3750000;
        //        lcl_obj_ScpmPurchaseOrderItem1.Remarks = "";
        //        lcl_obj_ScpmPurchaseOrderItem1.Status = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmPurchaseOrderItem1.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;

        //        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems.Add(lcl_obj_ScpmPurchaseOrderItem1);

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem lcl_obj_ScpmPurchaseOrderItem2 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem();
        //        lcl_obj_ScpmPurchaseOrderItem2.ProductCode = 20000100000000008;
        //        lcl_obj_ScpmPurchaseOrderItem2.Description = "";
        //        lcl_obj_ScpmPurchaseOrderItem2.Quantity = 4000000;
        //        lcl_obj_ScpmPurchaseOrderItem2.Remarks = "";
        //        lcl_obj_ScpmPurchaseOrderItem2.Status = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmPurchaseOrderItem2.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems.Add(lcl_obj_ScpmPurchaseOrderItem2);

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem lcl_obj_ScpmPurchaseOrderItem3 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem();
        //        lcl_obj_ScpmPurchaseOrderItem3.ProductCode = 20000100000000011;
        //        lcl_obj_ScpmPurchaseOrderItem3.Description = "";
        //        lcl_obj_ScpmPurchaseOrderItem3.Quantity = 375000;
        //        lcl_obj_ScpmPurchaseOrderItem3.Remarks = "";
        //        lcl_obj_ScpmPurchaseOrderItem3.Status = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmPurchaseOrderItem3.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems.Add(lcl_obj_ScpmPurchaseOrderItem3);

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem lcl_obj_ScpmPurchaseOrderItem4 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmPurchaseOrderItem();
        //        lcl_obj_ScpmPurchaseOrderItem4.ProductCode = 20000100000000006;
        //        lcl_obj_ScpmPurchaseOrderItem4.Description = "";
        //        lcl_obj_ScpmPurchaseOrderItem4.Quantity = 300000;
        //        lcl_obj_ScpmPurchaseOrderItem4.Remarks = "";
        //        lcl_obj_ScpmPurchaseOrderItem4.Status = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmPurchaseOrderItem4.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_SCPMPurchaseOrder.PurchaseOrderItems.Add(lcl_obj_ScpmPurchaseOrderItem4);

        //        SilkERP360.BML.SCPM.ScpmPurchaseOrderManager lcl_obj_ScpmPurchaseOrderManager = new SilkERP360.BML.SCPM.ScpmPurchaseOrderManager();
        //        lcl_obj_ScpmPurchaseOrderManager.Initialize();
        //        lcl_obj_ScpmPurchaseOrderManager.Save(lcl_obj_SCPMPurchaseOrder, IP_obj_DBManager);
        //    }
        //    catch (System.Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}

        //public void InsertSCPMJobOrder(SilkERP360.DAL.DBManager IP_obj_DBManager)
        //{
        //    try
        //    {
        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder lcl_obj_ScpmScJobOrder = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrder();
        //        lcl_obj_ScpmScJobOrder.ScpmPOCode = 20000200000000001;
        //        lcl_obj_ScpmScJobOrder.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_ScpmScJobOrder.EntryEmployeeCode = 101000000001;
        //        lcl_obj_ScpmScJobOrder.IsCancelled = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmScJobOrder.Remarks = "";
        //        lcl_obj_ScpmScJobOrder.Status = SilkERP360.CCL.Enums.YesNo.Yes;

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem1 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
        //        lcl_obj_ScpmScJobOrderItem1.ScJOCode = lcl_obj_ScpmScJobOrder.ScJOCode;
        //        lcl_obj_ScpmScJobOrderItem1.ScPOItemCode = 20000300000000001;
        //        lcl_obj_ScpmScJobOrderItem1.ProductCode = 20000100000000007;
        //        lcl_obj_ScpmScJobOrderItem1.Quantity = 3750000;
        //        lcl_obj_ScpmScJobOrderItem1.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_ScpmScJobOrderItem1.IsCancelled = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmScJobOrderItem1.StartBoxSerial = 1;
        //        lcl_obj_ScpmScJobOrderItem1.LastBoxSerial = 0;
        //        lcl_obj_ScpmScJobOrderItem1.InnerBox = 500;
        //        lcl_obj_ScpmScJobOrderItem1.OuterBox = 5000;
        //        lcl_obj_ScpmScJobOrder.JobOrderItems.Add(lcl_obj_ScpmScJobOrderItem1);

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem2 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
        //        lcl_obj_ScpmScJobOrderItem2.ScJOCode = lcl_obj_ScpmScJobOrder.ScJOCode;
        //        lcl_obj_ScpmScJobOrderItem2.ScPOItemCode = 20000300000000002;
        //        lcl_obj_ScpmScJobOrderItem2.ProductCode = 20000100000000008;
        //        lcl_obj_ScpmScJobOrderItem2.Quantity = 4000000;
        //        lcl_obj_ScpmScJobOrderItem2.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_ScpmScJobOrderItem2.IsCancelled = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmScJobOrderItem2.StartBoxSerial = 1;
        //        lcl_obj_ScpmScJobOrderItem2.LastBoxSerial = 0;
        //        lcl_obj_ScpmScJobOrderItem2.InnerBox = 500;
        //        lcl_obj_ScpmScJobOrderItem2.OuterBox = 5000;
        //        lcl_obj_ScpmScJobOrder.JobOrderItems.Add(lcl_obj_ScpmScJobOrderItem2);

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem3 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
        //        lcl_obj_ScpmScJobOrderItem3.ScJOCode = lcl_obj_ScpmScJobOrder.ScJOCode;
        //        lcl_obj_ScpmScJobOrderItem3.ScPOItemCode = 20000300000000003;
        //        lcl_obj_ScpmScJobOrderItem3.ProductCode = 20000100000000011;
        //        lcl_obj_ScpmScJobOrderItem3.Quantity = 375000;
        //        lcl_obj_ScpmScJobOrderItem3.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_ScpmScJobOrderItem3.IsCancelled = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmScJobOrderItem3.StartBoxSerial = 1;
        //        lcl_obj_ScpmScJobOrderItem3.LastBoxSerial = 0;
        //        lcl_obj_ScpmScJobOrderItem3.InnerBox = 500;
        //        lcl_obj_ScpmScJobOrderItem3.OuterBox = 5000;
        //        lcl_obj_ScpmScJobOrder.JobOrderItems.Add(lcl_obj_ScpmScJobOrderItem3);

        //        SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem lcl_obj_ScpmScJobOrderItem4 = new SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem();
        //        lcl_obj_ScpmScJobOrderItem4.ScJOCode = lcl_obj_ScpmScJobOrder.ScJOCode;
        //        lcl_obj_ScpmScJobOrderItem4.ScPOItemCode = 20000300000000003;
        //        lcl_obj_ScpmScJobOrderItem4.ProductCode = 20000100000000006;
        //        lcl_obj_ScpmScJobOrderItem4.Quantity = 300000;
        //        lcl_obj_ScpmScJobOrderItem4.DeliveryStatus = SilkERP360.CCL.Enums.SCPM.DeliveryStatus.Incomplete;
        //        lcl_obj_ScpmScJobOrderItem4.IsCancelled = SilkERP360.CCL.Enums.YesNo.No;
        //        lcl_obj_ScpmScJobOrderItem4.StartBoxSerial = 1;
        //        lcl_obj_ScpmScJobOrderItem4.LastBoxSerial = 0;
        //        lcl_obj_ScpmScJobOrderItem4.InnerBox = 500;
        //        lcl_obj_ScpmScJobOrderItem4.OuterBox = 5000;
        //        lcl_obj_ScpmScJobOrder.JobOrderItems.Add(lcl_obj_ScpmScJobOrderItem4);

        //        SilkERP360.BML.SCPM.ScpmScJobOrderManager lcl_obj_ScpmScJobOrderManager = new SilkERP360.BML.SCPM.ScpmScJobOrderManager();
        //        lcl_obj_ScpmScJobOrderManager.Initialize();
        //        lcl_obj_ScpmScJobOrderManager.Save(lcl_obj_ScpmScJobOrder, IP_obj_DBManager);

        //    }
        //    catch (System.Exception Ex)
        //    {
        //        throw Ex;
        //    }
        //}
    }
}
