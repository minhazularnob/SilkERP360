using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_MASTER_BATCH","SEQ_SCPM_MASTER_BATCH")]
    public class ScpmSmMasterBatch : SilkERP360.CCL.Validation.ValidationBase
    {
        public ScpmSmMasterBatch()
        {
            this.m_objLst_ScpmSmSubBatch = new List<ScpmSmSubBatch>();
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MASTER_BATCH_CODE",typeof(System.UInt64),true,false)]
        protected System.UInt64 m_ui64_MasterBatchCode;
        public System.UInt64 MasterBatchCode
        {
            get { return this.m_ui64_MasterBatchCode; }
            set { this.m_ui64_MasterBatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MASTER_BATCH", typeof(System.String), false, false)]
        protected System.String m_str_MasterBatch;
        public System.String MasterBatch
        {
            get { return this.m_str_MasterBatch; }
            set { this.m_str_MasterBatch = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MACHINE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_MachineCode;
        public System.UInt64 MachineCode
        {
            get { return this.m_ui64_MachineCode; }
            set { this.m_ui64_MachineCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SHIFT_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ShiftCode;
        public System.UInt64 ShiftCode
        {
            get { return this.m_ui64_ShiftCode; }
            set { this.m_ui64_ShiftCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PROCESS_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ProcessCode;
        public System.UInt64 ProcessCode
        {
            get { return this.m_ui64_ProcessCode; }
            set { this.m_ui64_ProcessCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("JOB_ORDER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_JobOrderCode;
        public System.UInt64 JobOrderCode
        {
            get { return this.m_ui64_JobOrderCode; }
            set { this.m_ui64_JobOrderCode = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MEASUREMENT_UNIT", typeof(SilkERP360.CCL.Enums.SCPM.ScpmMeasurementUnit), false, false)]
        //protected System.Int16 m_i16_MeasurementUnit;
        //public System.Int16 MeasurementUnit
        //{
        //    get { return this.m_i16_MeasurementUnit; }
        //    set { this.m_i16_MeasurementUnit = value; }
        //}

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_QUANTITY", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalQuantity;
        public System.UInt32 TotalQuantity
        {
            get { return this.m_ui32_TotalQuantity; }
            set { this.m_ui32_TotalQuantity = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_GOOD_QTY", typeof(System.UInt32), false, false)]
        //protected System.UInt32 m_ui32_TotalGoodQuantity;
        //public System.UInt32 TotalGoodQuantity
        //{
        //    get { return this.m_ui32_TotalGoodQuantity; }
        //    set { this.m_ui32_TotalGoodQuantity = value; }
        //}

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_WASTAGE", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalWastageQuantity;
        public System.UInt32 TotalWastageQuantity
        {
            get { return this.m_ui32_TotalWastageQuantity; }
            set { this.m_ui32_TotalWastageQuantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_RELEASED", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalReleasedQuantity;
        public System.UInt32 TotalReleasedQuantity
        {
            get { return this.m_ui32_TotalReleasedQuantity; }
            set { this.m_ui32_TotalReleasedQuantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY_ON_HOLD", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalQuantityOnHold;
        public System.UInt32 TotalQuantityOnHold
        {
            get { return this.m_ui32_TotalQuantityOnHold; }
            set { this.m_ui32_TotalQuantityOnHold = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY_SCRAPPED", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalQuantityScrapped;
        public System.UInt32 TotalQuantityScrapped
        {
            get { return this.m_ui32_TotalQuantityScrapped; }
            set { this.m_ui32_TotalQuantityScrapped = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_REMAINING", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalStockQuantity;
        public System.UInt32 TotalStockQuantity
        {
            get { return this.m_ui32_TotalStockQuantity; }
            set { this.m_ui32_TotalStockQuantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MASTER_BATCH_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_MasterBatchDate;
        public System.DateTime MasterBatchDate
        {
            get { return this.m_dt_MasterBatchDate; }
            set { this.m_dt_MasterBatchDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.SCPM.SMMasterBatchStatus), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.SMMasterBatchStatus m_enm_Status;
        public SilkERP360.CCL.Enums.SCPM.SMMasterBatchStatus Status
        {
            get { return this.m_enm_Status; }
            set { this.m_enm_Status = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> m_objLst_ScpmSmSubBatch;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmSubBatch> ScpmSmSubBatchList
        {
            get { return this.m_objLst_ScpmSmSubBatch; }
            set { this.m_objLst_ScpmSmSubBatch = value; }
        }

    }
}
