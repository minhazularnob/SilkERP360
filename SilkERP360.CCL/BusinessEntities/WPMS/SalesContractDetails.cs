using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_SALES_CONTRACT_DEATILS", "SEQ_WPMS_SALES_CONTRACT_DETAIL")]
    public class SalesContractDetails : SilkERP360.CCL.Validation.ValidationBase
    {
        public SalesContractDetails()
        { 
        
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALES_CONTRACT_DETAILS_CODE", typeof(System.UInt64), false, false)]
        public System.UInt64 m_uint64_SalesContractDetailsCode;

        public System.UInt64 SalesContractDetailsCode
        {
            get { return m_uint64_SalesContractDetailsCode; }
            set { m_uint64_SalesContractDetailsCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALES_CONTRACT_CODE", typeof(System.UInt64), false, false)]
        public System.UInt64 m_uint64_SalesContractCode;

        public System.UInt64 SalesContractCode
        {
            get { return m_uint64_SalesContractCode; }
            set { m_uint64_SalesContractCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUOTATION_DETAIL_CODE", typeof(System.UInt64), false, false)]
        public System.UInt64 m_ui64_QuotationDetailsCode;

        public System.UInt64 QuotationDetailsCode
        {
            get { return m_ui64_QuotationDetailsCode; }
            set { m_ui64_QuotationDetailsCode = value; }
        }
        
    }
}
