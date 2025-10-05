using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_CUSTOMER", "SEQ_SPM_CUSTOMER")]
    public class SpmCustomer : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CustomerCode;
        public System.UInt64 CustomerCode
        {
            get { return m_ui64_CustomerCode; }
            set { this.m_ui64_CustomerCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_NAME", typeof(System.String), true, false)]
        protected System.String m_str_CompanyName;
        public System.String CompanyName
        {
            get { return m_str_CompanyName; }
            set { this.m_str_CompanyName = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADDRESS", typeof(System.String), true, false)]
        protected System.String m_str_Address;
        public System.String Address
        {
            get { return m_str_Address; }
            set { this.m_str_Address = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_ADDRESS", typeof(System.String), true, false)]
        protected System.String m_str_DeliveryAddress;
        public System.String DeliveryAddress
        {
            get { return m_str_DeliveryAddress; }
            set { this.m_str_DeliveryAddress = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CONTACT_PERSON", typeof(System.String), true, false)]
        protected System.String m_str_ContactPerson;
        public System.String ContactPerson
        {
            get { return m_str_ContactPerson; }
            set { this.m_str_ContactPerson = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PHONE", typeof(System.String), true, false)]
        protected System.String m_str_Phone;
        public System.String Phone
        {
            get { return m_str_Phone; }
            set { this.m_str_Phone = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MOBILE", typeof(System.String), true, false)]
        protected System.String m_str_Mobile;
        public System.String Mobile
        {
            get { return m_str_Mobile; }
            set { this.m_str_Mobile = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SHORT_NAME", typeof(System.String), true, false)]
        protected System.String m_str_ShortName;
        public System.String ShortName
        {
            get { return m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JOB_ORDER_SEED", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJobOrderSeed;
        public System.UInt64 ScJobOrderSeed
        {
            get { return m_ui64_ScJobOrderSeed; }
            set { this.m_ui64_ScJobOrderSeed = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_JOB_ORDER_SEED", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmJobOrderSeed;
        public System.UInt64 SmJobOrderSeed
        {
            get { return m_ui64_SmJobOrderSeed; }
            set { this.m_ui64_SmJobOrderSeed = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), true, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsActive;
        public SilkERP360.CCL.Enums.YesNo IsActive
        {
            get { return m_enm_IsActive; }
            set { this.m_enm_IsActive = value; }
        }
        
    }
}
