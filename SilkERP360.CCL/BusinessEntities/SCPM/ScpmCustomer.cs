using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("CUSTOMER", "SEQ_CUSTOMER")]
    public class ScpmCustomer : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CustomerCode;
        public System.UInt64 CustomerCode
        {
            get { return m_ui64_CustomerCode; }
            set { m_ui64_CustomerCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_COMPANY_NAME", typeof(System.String), true, false)]
        protected System.String m_str_CustomerCompanyName;
        public System.String CustomerCompanyName
        {
            get { return m_str_CustomerCompanyName; }
            set { m_str_CustomerCompanyName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADDRESS", typeof(System.String), true, false)]
        protected System.String m_str_Address;
        public System.String Address
        {
            get { return m_str_Address; }
            set { m_str_Address = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_enm_IsActive;
        public CCL.Enums.YesNo IsActive
        {
            get { return m_enm_IsActive; }
            set { m_enm_IsActive = value; }
        }
    }
}
