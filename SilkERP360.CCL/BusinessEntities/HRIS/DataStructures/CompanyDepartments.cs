using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Provides List of DepartmentCore objects,Companywise
    /// </summary>
    public class CompanyDepartments : SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore
    {
        //private System.UInt64 m_ui64_CompanyCode;
        //public System.UInt64 CompanyCode
        //{
        //    get { return this.m_ui64_CompanyCode; }
        //    //set { m_ui64_CompanyCode = value; }
        //}

        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> m_obj_Departments;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> Departments
        {
            get { return this.m_obj_Departments; }
            //set { m_obj_Departments = value; }
        }

        public CompanyDepartments()
        {
            this.m_obj_Departments = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore>();
        }

        public CompanyDepartments(System.UInt64 IP_ui64_CompanyCode, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore> IP_obj_Departments)
        {
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
            this.m_obj_Departments = IP_obj_Departments;
        }
    }
}
