using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_QUOTATION_D", "WPMS_SEC_QUOTATION_DEATILS")]
    public class QuotationDetails : SilkERP360.CCL.Validation.ValidationBase
    {
        public QuotationDetails()
        {
            
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_D_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_QuotationDCode;
        public System.UInt64 QuotationDCode
        {
            get { return this.m_ui64_QuotationDCode; }
            set { this.m_ui64_QuotationDCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_M_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_QuotationMCode;
        public System.UInt64 QuotationMCode
        {
            get { return this.m_ui64_QuotationMCode; }
            set { this.m_ui64_QuotationMCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ProductCode;
        public System.UInt64 ProductCode
        {
            get { return this.m_ui64_ProductCode; }
            set { this.m_ui64_ProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_REF", typeof(System.String), true, false)]
        protected System.String m_str_ProductRef;
        public System.String ProductRef
        {
            get { return this.m_str_ProductRef; }
            set { this.m_str_ProductRef = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_DESC", typeof(System.String), true, false)]
        protected System.String m_str_ProductDesc;
        public System.String ProductDesc     
        {
            get { return this.m_str_ProductDesc; }
            set { this.m_str_ProductDesc = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_Quantity;
        public System.Decimal Quantity
        {
            get { return this.m_dbl_Quantity; }
            set { this.m_dbl_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NET_WEIGHT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_NetWeight;
        public System.Decimal NetWeight
        {
            get { return this.m_dbl_NetWeight; }
            set { this.m_dbl_NetWeight = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("UNIT_PRICE_CIF_FOS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcl_UnitPriceCifFos;
        public System.Decimal UnitPriceCifFos
        {
            get { return this.m_dcl_UnitPriceCifFos; }
            set { this.m_dcl_UnitPriceCifFos = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_AMOUNT_CIF_FOS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcl_TotalAmountCofFos;
        public System.Decimal TotalAmountCofFos
        {
            get { return this.m_dcl_TotalAmountCofFos; }
            set { this.m_dcl_TotalAmountCofFos = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PKG_CARTON", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_PkgCarton;
        public System.UInt32 PkgCarton
        {
            get { return this.m_ui32_PkgCarton; }
            set { this.m_ui32_PkgCarton = value; }
        }        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PKG_PCS_PER_CARTON", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_PkgPcsPerCarton;
        public System.UInt32 PkgPcsPerCarton
        {
            get { return this.m_ui32_PkgPcsPerCarton; }
            set { this.m_ui32_PkgPcsPerCarton = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CBM", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_CBM;
        public System.Decimal CBM
        {
            get { return this.m_dcm_CBM; }
            set { this.m_dcm_CBM = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PPB", typeof(System.UInt16), true, false)]
        protected System.UInt16 m_ui16_PPB;
        public System.UInt16 PPB
        {
            get { return this.m_ui16_PPB; }
            set { this.m_ui16_PPB = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BPC", typeof(System.UInt16), true, false)]
        protected System.UInt16 m_ui16_BPC;
        public System.UInt16 BPC
        {
            get { return this.m_ui16_BPC; }
            set { this.m_ui16_BPC = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QTY_KG", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcl_QtyKg;
        public System.Decimal QtyKg
        {
            get { return this.m_dcl_QtyKg; }
            set { this.m_dcl_QtyKg = value; }
        }
    }
}
