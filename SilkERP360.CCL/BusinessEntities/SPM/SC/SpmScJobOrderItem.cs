using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SC
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SC_JOB_ORDER_ITEM", "SEQ_SC_JOB_ORDER_ITEM")]
    public class SpmScJobOrderItem : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JOB_ORDER_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJobOrderItemCode;
        public System.UInt64 ScJobOrderItemCode
        {
            get { return m_ui64_ScJobOrderItemCode; }
            set { this.m_ui64_ScJobOrderItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JOB_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJobOrderCode;
        public System.UInt64 ScJobOrderCode
        {
            get { return m_ui64_ScJobOrderCode; }
            set { this.m_ui64_ScJobOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PURCHASE_ORDER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPurchaseOrderCode;
        public System.UInt64 ScPurchaseOrderCode
        {
            get { return m_ui64_ScPurchaseOrderCode; }
            set { this.m_ui64_ScPurchaseOrderCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PURCHASE_ORDER_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPurchaseOrderItemCode;
        public System.UInt64 ScPurchaseOrderItemCode
        {
            get { return m_ui64_ScPurchaseOrderItemCode; }
            set { this.m_ui64_ScPurchaseOrderItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SPM_PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SpmProductCode;
        public System.UInt64 SpmProductCode
        {
            get { return m_ui64_SpmProductCode; }
            set { this.m_ui64_SpmProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HRN_COVER", typeof(SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover), true, false)]
        protected SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover m_enm_HrnCover;
        public SilkERP360.CCL.Enums.SPM.ScratchCardHRNCover HrnCover
        {
            get { return m_enm_HrnCover; }
            set { m_enm_HrnCover = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVER_PRINT", typeof(SilkERP360.CCL.Enums.YesNo), true, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_OverPrint;
        public SilkERP360.CCL.Enums.YesNo OverPrint
        {
            get { return m_enm_OverPrint; }
            set { m_enm_OverPrint = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WRAPPING", typeof(SilkERP360.CCL.Enums.YesNo), true, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_Wrapping;
        public SilkERP360.CCL.Enums.YesNo Wrapping
        {
            get { return m_enm_Wrapping; }
            set { m_enm_Wrapping = value; }
        }

        /// <summary>
        /// Number of Cards contained in a packaged box
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUTER_BOX", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_OuterBox;
        public System.UInt64 OuterBox
        {
            get { return m_ui64_OuterBox; }
            set { this.m_ui64_OuterBox = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BOX_SL_START", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_BoxSlStart;
        public System.UInt64 BoxSlStart
        {
            get { return m_ui64_BoxSlStart; }
            set { this.m_ui64_BoxSlStart = value; }
        }


        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Quantity;
        public System.UInt64 Quantity
        {
            get { return m_ui64_Quantity; }
            set { this.m_ui64_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.SPM.DeliveryStatus), true, false)]
        protected SilkERP360.CCL.Enums.SPM.DeliveryStatus m_enm_Status;
        public SilkERP360.CCL.Enums.SPM.DeliveryStatus Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }

       
    }
}
