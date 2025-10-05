using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SM_PACKAGED_BOX", "SEQ_SPM_SM_PACKAGED_BOX")]
    public class SpmSmPackagedBox : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PACKAGED_BOX_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPackagedBoxCode;
        public System.UInt64 SmPackagedBoxCode
        {
            get { return m_ui64_SmPackagedBoxCode; }
            set { this.m_ui64_SmPackagedBoxCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PURCHASE_ODER_CODE", typeof(System.UInt64), true, false)]
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
