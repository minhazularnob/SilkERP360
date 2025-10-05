using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Contains List<> of EmployeeProfile objects, Department Wise
    /// </summary>
    public class DepartmentEmployeeProfiles : SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore
    {
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> m_obj_EmployeeProfiles;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> EmployeeProfiles
        {
            get { return this.m_obj_EmployeeProfiles; }
            //set { m_obj_Departments = value; }
        }

        public DepartmentEmployeeProfiles()
        {
            this.m_obj_EmployeeProfiles = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
        }

        public DepartmentEmployeeProfiles(System.UInt64 IP_ui64_DepartmentCode, System.String IP_str_DepartmentName, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> IP_obj_EmployeeProfiles)
        {
            this.m_ui64_DepartmentCode = IP_ui64_DepartmentCode;
            this.m_str_Name = IP_str_DepartmentName;
            this.m_obj_EmployeeProfiles = IP_obj_EmployeeProfiles;
        }
    }
}
