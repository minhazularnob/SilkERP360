using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Contains List<Employee>, Department wise
    /// </summary>
    public class DepartmentEmployees : SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore
    {
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> m_obj_Employees;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> Employees
        {
            get { return this.m_obj_Employees; }
            //set { m_obj_Departments = value; }
        }

        public DepartmentEmployees()
        {
            this.m_obj_Employees = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee>();
        }

        public DepartmentEmployees(System.UInt64 IP_ui64_DepartmentCode, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> IP_obj_Employees)
        {
            this.m_ui64_DepartmentCode = IP_ui64_DepartmentCode;
            this.m_obj_Employees = IP_obj_Employees;
        }
    }
}
