using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// 
    /// </summary>
    public class CompanyEmployees : SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore
    {
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> m_obj_Employees;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> Employees
        {
            get { return this.m_obj_Employees; }
            //set { m_obj_Departments = value; }
        }

        public CompanyEmployees()
        {
            this.m_obj_Employees = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee>();
        }

        public CompanyEmployees(System.UInt64 IP_ui64_CompanyCode, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Employee> IP_obj_Employees)
        {
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
            this.m_obj_Employees = IP_obj_Employees;
        }
    }
}
