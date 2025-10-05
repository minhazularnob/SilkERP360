using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SM_ISO_PERSO", "SEQ_SPM_SM_ISO_PERSO")]
    public class SpmSmIsoPerso : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_ISO_PERSO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmIsoPersoCode;
        public System.UInt64 SmIsoPersoCode
        {
            get { return m_ui64_SmIsoPersoCode; }
            set { this.m_ui64_SmIsoPersoCode = value; }
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

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PROJECT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmProjectCode;
        public System.UInt64 SmProjectCode
        {
            get { return m_ui64_SmProjectCode; }
            set { this.m_ui64_SmProjectCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PROJECT_DATA_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmProjectDataCode;
        public System.UInt64 SmProjectDataCode
        {
            get { return m_ui64_SmProjectDataCode; }
            set { this.m_ui64_SmProjectDataCode = value; }
        }
    
    }
}
