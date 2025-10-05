using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_BUYER","SEQ_WPMS_BUYER")]
    public class WpmsBuyer : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BUYER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BuyerCode;
        public System.UInt64 BuyerCode
        {
            get { return m_ui64_BuyerCode; }
            set { m_ui64_BuyerCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_NAME", typeof(System.String), false, false)]
        protected System.String m_str_CompanyName;
        public System.String CompanyName
        {
            get { return m_str_CompanyName; }
            set { m_str_CompanyName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADDRESS", typeof(System.String), false, false)]
        protected System.String m_str_Address;
        public System.String Address
        {
            get { return m_str_Address; }
            set { m_str_Address = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PHONE", typeof(System.String), false, false)]
        protected System.String m_str_Phone;
        public System.String Phone
        {
            get { return m_str_Phone; }
            set { m_str_Phone = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("FAX", typeof(System.String), false, false)]
        protected System.String m_str_Fax;
        public System.String Fax    
        {
            get { return m_str_Fax; }
            set { m_str_Fax = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CONTACT_PERSON", typeof(System.String), false, false)]
        protected System.String m_str_ContactPerson;
        public System.String ContactPerson
        {
            get { return m_str_ContactPerson; }
            set { m_str_ContactPerson = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMAIL", typeof(System.String), false, false)]
        protected System.String m_str_Email;
        public System.String Email
        {
            get { return m_str_Email; }
            set { m_str_Email = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COUNTRY", typeof(System.String), false, false)]
        protected System.String m_str_Country;
        public System.String Country
        {
            get { return m_str_Country; }
            set { m_str_Country = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsActive;
        public SilkERP360.CCL.Enums.YesNo IsActive
        {
            get { return m_enm_IsActive; }
            set { m_enm_IsActive = value; }
        }
    }
}
