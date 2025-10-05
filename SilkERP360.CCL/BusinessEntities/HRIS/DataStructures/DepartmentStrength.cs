using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class DepartmentStrength : SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore
    {
        private System.UInt32 m_ui32_EmployeeStrength;

        public System.UInt32 EmployeeStrength
        {
            get  
            { 
                return this.m_ui32_EmployeeStrength; 
            }
            set 
            { 
                m_ui32_EmployeeStrength = value; 
            }
        }

        public DepartmentStrength(System.UInt64 IP_ui64_DepartmentCode, System.String IP_str_DepartmentName, System.UInt32 IP_ui32_DepartmentStrength)
        {
            this.m_ui64_DepartmentCode = IP_ui64_DepartmentCode;
            this.m_str_Name = IP_str_DepartmentName;
            this.m_ui32_EmployeeStrength = IP_ui32_DepartmentStrength;
        }
    }
}
