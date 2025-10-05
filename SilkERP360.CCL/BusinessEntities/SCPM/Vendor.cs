using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class Vendor : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_VendorCode;
        public System.UInt64 VendorCode
        {
            get { return m_ui64_VendorCode; }
            set { m_ui64_VendorCode = value; }
        }

        protected System.String m_str_Name;
        public System.String Name
        {
            get { return m_str_Name; }
            set { m_str_Name = value; }
        }

        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
        }

        protected SilkERP360.CCL.Enums.Status m_enm_Status;
        public SilkERP360.CCL.Enums.Status Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }
    }
}
