using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.Base
{
    public class DesignationCore : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_DesignationCode;
        public System.UInt64 DesignationCode
        {
            get { return this.m_ui64_DesignationCode; }
            //set { m_ui64_CompanyCode = value; }
        }

        protected System.String m_str_Name;
        public System.String Name
        {
            get { return this.m_str_Name; }
            //set { m_str_Name = value; }
        }

        public DesignationCore()
        {
            
        }
        public DesignationCore(System.UInt64 IP_ui64_DesignationCode, System.String IP_str_DesignationName)
        {
            this.m_ui64_DesignationCode = IP_ui64_DesignationCode;
            this.m_str_Name = IP_str_DesignationName;
        }
    }
}
