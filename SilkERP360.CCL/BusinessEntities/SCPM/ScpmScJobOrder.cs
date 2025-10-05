using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SC_JOB_ORDER", "SEQ_SCPM_SC_JO")]
    public class ScpmScJobOrder : SilkERP360.CCL.Validation.ValidationBase
    {
        public ScpmScJobOrder()
        {
            this.m_objLst_JobOrderItems = new List<ScpmScJobOrderItem>();
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJOCode;
        public System.UInt64 ScJOCode
        {
            get { return m_ui64_ScJOCode; }
            set { m_ui64_ScJOCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SCPM_PO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScpmPOCode;
        public System.UInt64 ScpmPOCode
        {
            get { return m_ui64_ScpmPOCode; }
            set { m_ui64_ScpmPOCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_STATUS", typeof(SilkERP360.CCL.Enums.SPM.DeliveryStatus), true, false)]
        protected SilkERP360.CCL.Enums.SPM.DeliveryStatus m_enm_DeliveryStatus;
        public SilkERP360.CCL.Enums.SPM.DeliveryStatus DeliveryStatus
        {
            get { return m_enm_DeliveryStatus; }
            set { m_enm_DeliveryStatus = value; }
        }
       

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_enm_Status;
        public CCL.Enums.YesNo Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { m_str_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_CANCELLED", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_enm_IsCancelled;
        public CCL.Enums.YesNo IsCancelled
        {
            get { return m_enm_IsCancelled; }
            set { m_enm_IsCancelled = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { m_ui64_EntryEmployeeCode = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return m_dt_EntryDate; }
            set { m_dt_EntryDate = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> m_objLst_JobOrderItems;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmScJobOrderItem> JobOrderItems
        {
            get { return m_objLst_JobOrderItems; }
            set { m_objLst_JobOrderItems = value; }
        }
    }
}
