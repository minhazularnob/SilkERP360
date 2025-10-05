using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SC
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SC_PURCHASE_ORDER", "SEQ_SC_PURCHASE_ORDER")]
    public class SpmScPurchaseOrder : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PURCHASE_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPurchaseOrderCode;
        public System.UInt64 ScPurchaseOrderCode
        {
            get { return m_ui64_ScPurchaseOrderCode; }
            set { this.m_ui64_ScPurchaseOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CustomerCode;
        public System.UInt64 CustomerCode
        {
            get { return m_ui64_CustomerCode; }
            set { this.m_ui64_CustomerCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PO_REF_NUMBER", typeof(System.String), true, false)]
        protected System.String m_str_PoRefNumber;
        public System.String PoRefNumber
        {
            get { return m_str_PoRefNumber; }
            set { this.m_str_PoRefNumber = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ISSUE_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_IssueDate;
        public System.DateTime IssueDate
        {
            get { return m_dt_IssueDate; }
            set { this.m_dt_IssueDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.SPM.DeliveryStatus), true, false)]
        protected SilkERP360.CCL.Enums.SPM.DeliveryStatus m_enm_Status;
        public SilkERP360.CCL.Enums.SPM.DeliveryStatus Status
        {
            get { return m_enm_Status; }
            set { this.m_enm_Status = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { this.m_ui64_EntryEmployeeCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return m_dt_EntryDate; }
            set { this.m_dt_EntryDate = value; }
        }

        /// <summary>
        /// While saving, check if this field is NULL.
        /// if not NULL, SAVE
        /// </summary>
        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> m_objLst_PurchaseOrderItems;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SPM.SC.SpmScPurchaseOrderItem> PurchaseOrderItems
        {
            get { return m_objLst_PurchaseOrderItems; }
            set { m_objLst_PurchaseOrderItems = value; }
        }

    }
}
