using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_QUOTATION_M", "WPMS_SEC_QUOTATION")]
    public class Quotation : SilkERP360.CCL.Validation.ValidationBase
   {
[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_M_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_QuotationMCode;
        
       public System.UInt64 QuotationMCode
       {
           get { return m_ui64_QuotationMCode; }
           set { m_ui64_QuotationMCode = value; }
       }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BUYER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BuyerCode;

        public System.UInt64 BuyerCode
        {
            get { return m_ui64_BuyerCode; }
            set { m_ui64_BuyerCode = value; }
        }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_QuotationDate;

        public System.DateTime QuotationDate
        {
            get { return m_dt_QuotationDate; }
            set { m_dt_QuotationDate = value; }
        }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsActive;
         public SilkERP360.CCL.Enums.YesNo IsActive
         {
             get { return m_enm_IsActive; }
             set { m_enm_IsActive = value; }
         }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_REQ", typeof(System.String), false, false)]
        protected System.String m_str_CustomerReq;

        public System.String CustomerReq
        {
            get { return m_str_CustomerReq; }
            set { m_str_CustomerReq = value; }
        }


         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENCY", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_Currency;

        public System.UInt16 Currency
        {
            get { return m_ui16_Currency; }
            set { m_ui16_Currency = value; }
        }
 [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENCY_CONVERSION_RATE", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dec_CrrencyConversionRate;

        public System.Decimal CrrencyConversionRate
        {
            get { return m_dec_CrrencyConversionRate; }
            set { m_dec_CrrencyConversionRate = value; }
        }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PO_ISSUED", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_IsPOIssued;

        public System.UInt16 IsPOIssued
        {
            get { return m_ui16_IsPOIssued; }
            set { m_ui16_IsPOIssued = value; }
        }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IP_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_IPEmployeeCode;

        public System.UInt64 IPEmployeeCode
        {
            get { return m_ui64_IPEmployeeCode; }
            set { m_ui64_IPEmployeeCode = value; }
        }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IP_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_IPDate;

        public System.DateTime IPDate
        {
            get { return m_dt_IPDate; }
            set { m_dt_IPDate = value; }
        }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), false, false)]
        protected System.String m_str_Remarks;

        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { m_str_Remarks = value; }
        }                

            protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> m_objLst_QuotationDetails;
            protected SilkERP360.CCL.BusinessEntities.WPMS.Buyer m_objLst_Buyer;
            public SilkERP360.CCL.BusinessEntities.WPMS.Buyer Buyer
            {
                get { return m_objLst_Buyer; }
                set { this.m_objLst_Buyer = value; }
            }

public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.QuotationDetails> QuotationDetails
{
    get { return m_objLst_QuotationDetails; }
    set { m_objLst_QuotationDetails = value; }
}



   }
}
