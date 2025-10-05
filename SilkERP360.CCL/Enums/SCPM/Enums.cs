using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Enums.SCPM
{

    
    public enum QCTestResult
    {
        None = 0,
        Passed = 1,
        Failed = -1
    }
    
    public enum PurchaseOrderDeliveryStatus
    {
        None = 0,
        Complete = 1,
        Incomplete = 2
    }
    public enum JobOrderStatus
    {
        None = 0,
        DeliveryComplete = 1,
        DeliveryIncomplete = -1
    }

    public enum JobOrderItemProductionStatus
    {
        None = 0,
        Inprocess = 1,
        Complete = 2
    }
    public enum ProductType
    {
        None = 0,
        SIM = 1,
        ScratchCard = 2,
        BankCard = 3
    }
    public enum MachineOutputMeasurementUnit
    {
        Piece = 1, Sheet = 2
    }

    public enum MachineOperationalStatus
    {
        Off = 0, On = 1, ServiceIntervention = 2
    }

    public enum VendorGroup
    {
        None=0, PVCSheetSupplier = 1, ModuleSupplier = 2
    }

    public enum SMQCTestTypes
    {
        None = 0,PeelOff = 1,AppearanceColorDensity = 2,LengthWidthThickness = 3,CavityDimensionDepthLocation = 4,
        Bending = 5,Torsion=6,PushOutChip=7,ChipLocationAppearance = 8,BreakoutForce = 9,Dimension = 10,
        TelecapersBarcodeICCID = 11
    }

    public enum SMMasterBatchStatus
    {
        None = 0,
        /// <summary>
        /// All QC OK. 1 or More or All SubBatch waiting to be released
        /// </summary>
        Passed = 1,
        /// <summary>
        /// All Q.C Okay. Full Batch released
        /// </summary>
        ReleasedAll = 2,
        /// <summary>
        /// If a Master Batch contains n SubBatches,
        /// 1 or (n-1) SubBatch QC passed-SubBatch waiting to be released.
        /// At least 1 SubBatch QC failed.
        /// At least 1 SubBatch QC Passed.
        /// </summary>
        QCPartialOK_ReleaseAwaited = 3,
        /// <summary>
        /// All SubBatch QC Failed
        /// </summary>
        QCFailed_All = -1,
        /// <summary>
        /// 
        /// </summary>
        QCFailed_ReTest = -3
    }

    public enum SMSubBatchDeliveryStatus
    {
        None = 0,
        OK = 1,
        OnHold = -1
    }
    public enum SMSubBatchStatus
    {
        None = 0,
        AllOK_BatchReleased = 1,
        /// <summary>
        /// The Q.C of the SubBatch is OK. Some or All quantity is waiting to be realeased.
        /// </summary>
        QCOk_RealeaseAwaited = 2,
        QCFailed = -1,
        ReQC_Ordered = -2,
        /// <summary>
        /// The Batch cannot be recovered.Has been Ordered to scrap.
        /// </summary>
        ScrapOrdered = -3,
        /// <summary>
        /// Batch Has been Scrapped & Destroyed
        /// </summary>
        BatchScrapped = -4,
        ReQC_FailedAlso = -5
    }

    public enum SMQCMasterStatus
    {
        None =0,
        Passed = 1,
        Failed = -1,
        ReQCOrdered = -2,
        ReQCFailed = -3
    }

    public enum SCPMRawMaterialType
    {
        None = 0,
        PVCSheet = 1,
        Module = 2
    }
}