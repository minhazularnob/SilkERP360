using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_SALES_CONTRACT", "SEQ_WPMS_BUYER")]
   public class SalesContract : SilkERP360.CCL.Validation.ValidationBase
    {
       public SalesContract()
       {

       }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALES_CONTRACT_CODE", typeof(System.UInt64), false, false)]
       public System.UInt64 m_ui64_SalesContractCode;

        public System.UInt64 SalesContractCode
        {
            get { return m_ui64_SalesContractCode; }
            set { m_ui64_SalesContractCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PORT_OF_DELIVERY", typeof(System.String), false, false)]
        public System.String m_str_PortOfDelivery;

        public System.String PortOfDelivery
        {
            get { return m_str_PortOfDelivery; }
            set { m_str_PortOfDelivery = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADVISING_BANK", typeof(System.String), false, false)]
        public System.String m_str_AdvisingBank;

        public System.String AdvisingBank
        {
            get { return m_str_AdvisingBank; }
            set { m_str_AdvisingBank = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LC_VALIDITY", typeof(System.DateTime), false, false)]
        public System.DateTime m_dt_LCValidity;

        public System.DateTime LCValidity
        {
            get { return m_dt_LCValidity; }
            set { m_dt_LCValidity = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TRANSSHIPMENT", typeof(System.String), false, false)]
        public System.String m_str_TransHipment;

        public System.String TransHipment
        {
            get { return m_str_TransHipment; }
            set { m_str_TransHipment = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HS_CODE", typeof(System.String), false, false)]
        public System.String m_str_HSCode;

        public System.String HSCode
        {
            get { return m_str_HSCode; }
            set { m_str_HSCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_M_CODE", typeof(System.UInt64), false, false)]
        public System.UInt64 m_ui64_QuotationCode;

        public System.UInt64 QuotationCode
        {
            get { return m_ui64_QuotationCode; }
            set { m_ui64_QuotationCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BUYER_CODE", typeof(System.UInt64), false, false)]
        public System.UInt64 m_ui64_BuyerCode;

        public System.UInt64 BuyerCode
        {
            get { return m_ui64_BuyerCode; }
            set { m_ui64_BuyerCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALES_CONTRACT_DATE", typeof(System.DateTime), false, false)]
        public System.DateTime m_dt_SalesContractDate;

        public System.DateTime SalesContractDate
        {
            get { return m_dt_SalesContractDate; }
            set { m_dt_SalesContractDate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PACKING", typeof(System.String), false, false)]
        public System.String m_str_Packing;

        public System.String Packing
        {
            get { return m_str_Packing; }
            set { m_str_Packing = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TERMS_OF_PAYMENT", typeof(System.String), false, false)]
        public System.String m_str_TermsOfPayments;

        public System.String TermsOfPayments
        {
            get { return m_str_TermsOfPayments; }
            set { m_str_TermsOfPayments = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY", typeof(System.String), false, false)]
        public System.String m_str_Delivery;

        public System.String Delivery
        {
            get { return m_str_Delivery; }
            set { m_str_Delivery = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DESCRIPTION", typeof(System.String), false, false)]
        public System.String m_str_Description;

        public System.String Description
        {
            get { return m_str_Description; }
            set { m_str_Description = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COUNTRY_ORIGIN", typeof(System.String), false, false)]
        public System.String m_str_CountryOrigin;

        public System.String CountryOrigin
        {
            get { return m_str_CountryOrigin; }
            set { m_str_CountryOrigin = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PORT_OF_DESTINATION", typeof(System.String), false, false)]
        public System.String m_str_PortofDestination;

        public System.String PortofDestination
        {
            get { return m_str_PortofDestination; }
            set { m_str_PortofDestination = value; }
        }

       protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails> m_objLst_SalesContractDetails;

       public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.SalesContractDetails> SalesContractDetails
       {
           get { return m_objLst_SalesContractDetails; }
           set { m_objLst_SalesContractDetails = value; }
       }


    }
}
