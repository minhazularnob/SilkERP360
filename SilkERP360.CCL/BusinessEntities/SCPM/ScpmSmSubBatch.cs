using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SM_BATCH", "SEQ_SCPM_SM_BATCH")]
    public class ScpmSmSubBatch : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_BatchCode;
        public System.UInt64 BatchCode
        {
            get { return this.m_ui64_BatchCode; }
            set { this.m_ui64_BatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MASTER_BATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_MasterBatchCode;
        public System.UInt64 MasterBatchCode
        {
            get { return this.m_ui64_MasterBatchCode; }
            set { this.m_ui64_MasterBatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OPERATOR_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_OperatorCode;
        public System.UInt64 OperatorCode
        {
            get { return this.m_ui64_OperatorCode; }
            set { this.m_ui64_OperatorCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_DATE_TIME", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_BatchDate;
        public System.DateTime BatchDate
        {
            get { return this.m_dt_BatchDate; }
            set { this.m_dt_BatchDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Quantity;
        public System.UInt32 Quantity
        {
            get { return this.m_ui32_Quantity; }
            set { this.m_ui32_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WASTAGE", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Wastage;
        public System.UInt32 Wastage
        {
            get { return this.m_ui32_Wastage; }
            set { this.m_ui32_Wastage = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_RELEASED", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalReleased;
        public System.UInt32 TotalReleased
        {
            get { return this.m_ui32_TotalReleased; }
            set { this.m_ui32_TotalReleased = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SUB_BATCH", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_SubBatch;
        public System.UInt32 SubBatch
        {
            get { return this.m_ui32_SubBatch; }
            set { this.m_ui32_SubBatch = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_REMAINING", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TotalRemaining;
        public System.UInt32 TotalRemaining
        {
            get { return this.m_ui32_TotalRemaining; }
            set { this.m_ui32_TotalRemaining = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), false, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_STATUS", typeof(SilkERP360.CCL.Enums.SCPM.SMSubBatchDeliveryStatus), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.SMSubBatchDeliveryStatus m_enm_DeliveryStatus;
        public SilkERP360.CCL.Enums.SCPM.SMSubBatchDeliveryStatus DeliveryStatus
        {
            get { return this.m_enm_DeliveryStatus; }
            set { this.m_enm_DeliveryStatus = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.SCPM.SMSubBatchStatus), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.SMSubBatchStatus m_enm_Status;
        public SilkERP360.CCL.Enums.SCPM.SMSubBatchStatus Status
        {
            get { return this.m_enm_Status; }
            set { this.m_enm_Status = value; }
        }

        /// <summary>
        /// This Field is Nullable.Will contain value only for Personalization Process
        /// </summary>
        protected SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace m_obj_ScpmSMPersoTrace;
        public SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPersoTrace ScpmSMPersoTrace
        {
            get { return this.m_obj_ScpmSMPersoTrace; }
            set { this.m_obj_ScpmSMPersoTrace = value; }
        }

        /// <summary>
        /// Refers Multiple QC Master. Can have multiple QCMaster but there can be 
        /// only one QCMaster With the status ALLOK
        /// </summary>
        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> m_objList_SMQCMaster;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmQCMaster> SMQCMasterList
        {
            get { return this.m_objList_SMQCMaster; }
            set { this.m_objList_SMQCMaster = value; }
        }

        /// <summary>
        /// </summary>
        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmRMVendorRef> m_objList_RMVendorRef;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmRMVendorRef> RMVendorRefList
        {
            get { return this.m_objList_RMVendorRef; }
            set { this.m_objList_RMVendorRef = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> m_objList_SMInputBatchRef;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmInputBatchRef> SMInputBatchRefList
        {
            get { return this.m_objList_SMInputBatchRef; }
            set { this.m_objList_SMInputBatchRef = value; }
        }
    }
}
