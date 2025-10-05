using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SM_PURCHASE_ORDER_ITEM", "SEQ_SM_PURCHASE_ORDER_ITEM")]
    public class SpmSmPurchaseOrderItem : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PURCHASE_ORDER_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPurchaseOrderItemCode;
        public System.UInt64 SmPurchaseOrderItemCode
        {
            get { return m_ui64_SmPurchaseOrderItemCode; }
            set { this.m_ui64_SmPurchaseOrderItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PURCHASE_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPurchaseOrderCode;
        public System.UInt64 SmPurchaseOrderCode
        {
            get { return m_ui64_SmPurchaseOrderCode; }
            set { this.m_ui64_SmPurchaseOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmProductCode;
        public System.UInt64 SmProductCode
        {
            get { return m_ui64_SmProductCode; }
            set { this.m_ui64_SmProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HLR_DESC", typeof(System.String), true, false)]
        protected System.String m_str_HlrDesc;
        public System.String HlrDesc
        {
            get { return m_str_HlrDesc; }
            set { this.m_str_HlrDesc = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Quantity;
        public System.UInt64 Quantity
        {
            get { return m_ui64_Quantity; }
            set { this.m_ui64_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_START_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_DeliveryStartDate;
        public System.DateTime DeliveryStartDate
        {
            get { return m_dt_DeliveryStartDate; }
            set { this.m_dt_DeliveryStartDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(CCL.Enums.SPM.DeliveryStatus), true, false)]
        protected CCL.Enums.SPM.DeliveryStatus m_enm_Status;
        public CCL.Enums.SPM.DeliveryStatus Status
        {
            get { return m_enm_Status; }
            set { this.m_enm_Status = value; }
        }
                
    
    }
}
