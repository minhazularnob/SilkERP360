using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.General
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("VENDOR", "SEQ_VENDOR")]
    public class Vendor
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("VENDOR_CODE",typeof(System.UInt64),true,false)]
        protected System.UInt64 m_ui64_VendorCode;
        public System.UInt64 VendorCode
        {
            get { return m_ui64_VendorCode; }
            set { m_ui64_VendorCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NAME", typeof(System.String), false, false)]
        protected System.String m_str_Name;
        public System.String Name
        {
            get { return m_str_Name; }
            set { m_str_Name = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.Status), false, false)]
        protected SilkERP360.CCL.Enums.Status m_enm_Status;
        public SilkERP360.CCL.Enums.Status Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }
        
    }
}
