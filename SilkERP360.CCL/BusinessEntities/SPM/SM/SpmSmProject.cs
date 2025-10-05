using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SM_PROJECT", "SEQ_SPM_SM_PROJECT")]
    public class SpmSmProject : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PROJECT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmProjectCode;
        public System.UInt64 SmProjectCode
        {
            get { return m_ui64_SmProjectCode; }
            set { this.m_ui64_SmProjectCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PURCHASE_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPurchaseOrderCode;
        public System.UInt64 SmPurchaseOrderCode
        {
            get { return m_ui64_SmPurchaseOrderCode; }
            set { this.m_ui64_SmPurchaseOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PURCHASE_ORDER_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPurchaseOrderItemCode;
        public System.UInt64 SmPurchaseOrderItemCode
        {
            get { return m_ui64_SmPurchaseOrderItemCode; }
            set { this.m_ui64_SmPurchaseOrderItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_JOB_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmJobOrderCode;
        public System.UInt64 SmJobOrderCode
        {
            get { return m_ui64_SmJobOrderCode; }
            set { this.m_ui64_SmJobOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_JOB_ORDER_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmJobOrderItemCode;
        public System.UInt64 SmJobOrderItemCode
        {
            get { return m_ui64_SmJobOrderItemCode; }
            set { this.m_ui64_SmJobOrderItemCode = value; }
        }
    }
}
