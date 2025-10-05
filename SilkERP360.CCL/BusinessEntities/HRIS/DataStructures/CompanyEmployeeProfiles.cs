using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Contains List of EmployeeProfiles, CompanyCode wise
    /// </summary>
    public class CompanyEmployeeProfiles : SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore
    {
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> m_obj_EmployeeProfiles;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> EmployeeProfiles
        {
            get { return this.m_obj_EmployeeProfiles; }
            //set { m_obj_Departments = value; }
        }

        public CompanyEmployeeProfiles()
        {
            this.m_obj_EmployeeProfiles = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
        }

        public CompanyEmployeeProfiles(System.UInt64 IP_ui64_CompanyCode, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> IP_obj_EmployeeProfiles)
        {
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
            this.m_obj_EmployeeProfiles = IP_obj_EmployeeProfiles;
        }
    }
}
