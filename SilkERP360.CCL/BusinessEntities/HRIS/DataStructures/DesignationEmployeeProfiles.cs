using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Contains List<> of EmployeeProfile object, Designationwise
    /// </summary>
    public class DesignationEmployeeProfiles : SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore
    {
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> m_obj_EmployeeProfiles;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> EmployeeProfiles
        {
            get { return this.m_obj_EmployeeProfiles; }
            //set { m_obj_Departments = value; }
        }

        public DesignationEmployeeProfiles()
        {
            this.m_obj_EmployeeProfiles = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile>();
        }

        public DesignationEmployeeProfiles(System.UInt64 IP_ui64_DesignationCode, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProfile> IP_obj_EmployeeProfiles)
        {
            this.m_ui64_DesignationCode = IP_ui64_DesignationCode;
            this.m_obj_EmployeeProfiles = IP_obj_EmployeeProfiles;
        }
    }
}
