using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_PURCHASE_ORDER_DETAILS", "WPMS_SEC_PURCHASE_ORDER_DETAILS")]
    public class PurchaseOrderDetails : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PURCHASE_ORDER_DETAILS_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_PurchaseOrderDetailsCode;
        public System.UInt64 PurchaseOrderDetailsCode
        {
            get { return this.m_ui64_PurchaseOrderDetailsCode; }
            set { this.m_ui64_PurchaseOrderDetailsCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PURCHASE_ORDER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_PurchaseOrderCode;
        public System.UInt64 PurchaseOrderCode
        {
            get { return this.m_ui64_PurchaseOrderCode; }
            set { this.m_ui64_PurchaseOrderCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_REF", typeof(System.String), false, false)]
        protected System.String m_str_ProductRef;
        public  System.String ProductRef
        {
            get { return this.m_str_ProductRef; }
            set { this.m_str_ProductRef = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_DESC", typeof(System.String), false, false)]
        protected System.String m_str_ProductDesc;
        public System.String ProductDesc
        {
            get { return this.m_str_ProductDesc; }
            set { this.m_str_ProductDesc = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_Quantity;
        public System.Decimal Quantity
        {
            get { return this.m_dec_Quantity; }
            set { this.m_dec_Quantity = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NET_WEIGHT", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_Weight;
        public System.Decimal Weight
        {
            get { return this.m_dec_Weight; }
            set { this.m_dec_Weight = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("UNIT_PRICE_CIF_FOS", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_UnitPriceCifFos;
        public System.Decimal UnitPriceCifFos
        {
            get { return this.m_dec_UnitPriceCifFos; }
            set { this.m_dec_UnitPriceCifFos = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_AMOUNT_CIF_FOS", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_TotalAmountCifFos;
        public System.Decimal TotalAmountCifFos
        {
            get { return this.m_dec_TotalAmountCifFos; }
            set { this.m_dec_TotalAmountCifFos = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENCY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_dec_CurrencyCode;
        public System.UInt64 CurrencyCode
        {
            get { return this.m_dec_CurrencyCode; }
            set { this.m_dec_CurrencyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CONVERSION_RATE", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_ConversionRate;
        public System.Decimal ConversionRate
        {
            get { return this.m_dec_ConversionRate; }
            set { this.m_dec_ConversionRate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_dec_ProductCode;
        public System.UInt64 ProductCode
        {
            get { return this.m_dec_ProductCode; }
            set { this.m_dec_ProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PKG_CARTON", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Carton;
        public System.UInt32 Carton
        {
            get { return this.m_ui32_Carton; }
            set { this.m_ui32_Carton = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QTY_KG", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_QtyKg;
        public System.Decimal QtyKg
        {
            get { return this.m_dec_QtyKg; }
            set { this.m_dec_QtyKg = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CBM", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_Cbm;
        public System.Decimal Cbm
        {
            get { return this.m_dec_Cbm; }
            set { this.m_dec_Cbm = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PKG_PCS_PER_CARTON", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_PcsPerCarton;
        public System.UInt32 PcsPerCarton
        {
            get { return this.m_ui32_PcsPerCarton; }
            set { this.m_ui32_PcsPerCarton = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PPB", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Ppb;
        public System.UInt32 Ppb
        {
            get { return this.m_ui32_Ppb; }
            set { this.m_ui32_Ppb = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BPC", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Bpc;
        public System.UInt32 Bpc
        {
            get { return this.m_ui32_Bpc; }
            set { this.m_ui32_Bpc = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_DETAILS_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_QuotationDetailsCode;
        public System.UInt64 QuotationDetailsCode
        {
            get { return this.m_ui64_QuotationDetailsCode; }
            set { this.m_ui64_QuotationDetailsCode = value; }
        }

    }
}
