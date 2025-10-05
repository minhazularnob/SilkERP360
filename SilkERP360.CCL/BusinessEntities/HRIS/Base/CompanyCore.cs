using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.Base
{
    public class CompanyCore : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }

        protected System.String m_str_Name;
        public System.String Name
        {
            get { return this.m_str_Name; }
            set { this.m_str_Name = value; }
        }

        public CompanyCore()
        {
            
        }
        public CompanyCore(System.UInt64 IP_ui64_CompanyCode, System.String IP_str_CompanyName)
        {
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
            this.m_str_Name = IP_str_CompanyName;
        }
    }
}
