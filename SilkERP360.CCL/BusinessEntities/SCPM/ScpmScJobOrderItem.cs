using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SC_JOB_ORDER_ITEM", "SEQ_SCPM_SC_JO_ITEM")]
    public class ScpmScJobOrderItem : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JO_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJOItemCode;
        public System.UInt64 ScJOItemCode
        {
            get { return m_ui64_ScJOItemCode; }
            set { m_ui64_ScJOItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJOCode;
        public System.UInt64 ScJOCode
        {
            get { return m_ui64_ScJOCode; }
            set { m_ui64_ScJOCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PO_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPOItemCode;
        public System.UInt64 ScPOItemCode
        {
            get { return m_ui64_ScPOItemCode; }
            set { m_ui64_ScPOItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ProductCode;
        public System.UInt64 ProductCode
        {
            get { return m_ui64_ProductCode; }
            set { m_ui64_ProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_Quantity;
        public System.UInt32 Quantity
        {
            get { return m_ui32_Quantity; }
            set { m_ui32_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("START_BOX_SERIAL", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_StartBoxSerial;
        public System.UInt32 StartBoxSerial
        {
            get { return m_ui32_StartBoxSerial; }
            set { m_ui32_StartBoxSerial = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LAST_BOX_SERIAL", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_LastBoxSerial;
        public System.UInt32 LastBoxSerial
        {
            get { return m_ui32_LastBoxSerial; }
            set { m_ui32_LastBoxSerial = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INNER_BOX", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_InnerBox;
        public System.UInt32 InnerBox
        {
            get { return m_ui32_InnerBox; }
            set { m_ui32_InnerBox = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUTER_BOX", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_OuterBox;
        public System.UInt32 OuterBox
        {
            get { return m_ui32_OuterBox; }
            set { m_ui32_OuterBox = value; }
        }
       

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_STATUS", typeof(SilkERP360.CCL.Enums.SPM.DeliveryStatus), true, false)]
        protected SilkERP360.CCL.Enums.SPM.DeliveryStatus m_enm_DeliveryStatus;
        public SilkERP360.CCL.Enums.SPM.DeliveryStatus DeliveryStatus
        {
            get { return m_enm_DeliveryStatus; }
            set { m_enm_DeliveryStatus = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_CANCELLED", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_enm_IsCancelled;
        public CCL.Enums.YesNo IsCancelled
        {
            get { return m_enm_IsCancelled; }
            set { m_enm_IsCancelled = value; }
        }

    }
}
