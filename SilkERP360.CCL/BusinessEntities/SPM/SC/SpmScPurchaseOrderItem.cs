using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SC
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SC_PURCHASE_ORDER_ITEM", "SEQ_SC_PURCHASE_ORDER_ITEM")]
    public class SpmScPurchaseOrderItem : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PURCHASE_ORDER_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPurchaseOrderItemCode;
        public System.UInt64 ScPurchaseOrderItemCode
        {
            get { return m_ui64_ScPurchaseOrderItemCode; }
            set { this.m_ui64_ScPurchaseOrderItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PURCHASE_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPurchaseOrderCode;
        public System.UInt64 ScPurchaseOrderCode
        {
            get { return m_ui64_ScPurchaseOrderCode; }
            set { this.m_ui64_ScPurchaseOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SPM_PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SpmProductCode;
        public System.UInt64 SpmProductCode
        {
            get { return m_ui64_SpmProductCode; }
            set { this.m_ui64_SpmProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DESCRIPTION", typeof(System.String), true, false)]
        protected System.String m_str_Description;
        public System.String Description
        {
            get { return m_str_Description; }
            set { this.m_str_Description = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("UNIT_OF_MEASUREMENT", typeof(SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit), true, false)]
        protected SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit m_enm_MeasurementUnit;
        public SilkERP360.CCL.Enums.SPM.SpmMeasurementUnit MeasurementUnit
        {
            get { return m_enm_MeasurementUnit; }
            set { this.m_enm_MeasurementUnit = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Quantity;
        public System.UInt64 Quantity
        {
            get { return m_ui64_Quantity; }
            set { this.m_ui64_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DENOMINATION", typeof(SilkERP360.CCL.Enums.SPM.ScratchCardDenomination), true, false)]
        protected SilkERP360.CCL.Enums.SPM.ScratchCardDenomination m_enm_Denomination;
        public SilkERP360.CCL.Enums.SPM.ScratchCardDenomination Denomination
        {
            get { return m_enm_Denomination; }
            set { this.m_enm_Denomination = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_START_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_DeliveryStartDate;
        public System.DateTime DeliveryStartDate
        {
            get { return m_dt_DeliveryStartDate; }
            set { this.m_dt_DeliveryStartDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EXPIRY_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_ExpiryDate;
        public System.DateTime ExpiryDate
        {
            get { return m_dt_ExpiryDate; }
            set { this.m_dt_ExpiryDate = value; }
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
