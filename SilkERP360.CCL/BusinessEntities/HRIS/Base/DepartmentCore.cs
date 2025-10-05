using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.Base
{
    public class DepartmentCore : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_DepartmentCode;
        public System.UInt64 DepartmentCode
        {
            get { return this.m_ui64_DepartmentCode; }
            //set { m_ui64_CompanyCode = value; }
        }

        protected System.String m_str_Name;
        public System.String Name
        {
            get { return this.m_str_Name; }
            //set { m_str_Name = value; }
        }

        public DepartmentCore()
        {
            
        }
        public DepartmentCore(System.UInt64 IP_ui64_DepartmentCode, System.String IP_str_DepartmentName)
        {
            this.m_ui64_DepartmentCode = IP_ui64_DepartmentCode;
            this.m_str_Name = IP_str_DepartmentName;
        }
    }
}
