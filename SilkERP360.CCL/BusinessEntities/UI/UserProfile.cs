using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    public class UserProfile : SilkERP360.CCL.BusinessEntities.UI.User
    {
        

        private System.String m_str_EmployeeID;
        public System.String EmployeeID
        {
            get { return this.m_str_EmployeeID; }
            set { this.m_str_EmployeeID = value; }
        }

        private System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return this.m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }

        private SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore m_obj_Company;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore Company
        {
            get { return this.m_obj_Company; }
            set { this.m_obj_Company = value; }
        }

        private SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore m_obj_Designation;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore Designation
        {
            get { return this.m_obj_Designation; }
            set { this.m_obj_Designation = value; }
        }

        private SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore m_obj_Department;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore Department
        {
            get { return this.m_obj_Department; }
            set { this.m_obj_Department = value; }
        }

        private SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage m_obj_Image;

        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeImage Image
        {
            get { return this.m_obj_Image; }
            set { this.m_obj_Image = value; }
        }

        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany> m_objLst_ModuleMenusCompanies;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.UI.ModuleMenuCompany> ModuleMenusCompanies
        {
            get { return this.m_objLst_ModuleMenusCompanies; }
            set { this.m_objLst_ModuleMenusCompanies = value; }
        }

        public UserProfile()
            : base()
        {
            this.m_objLst_ModuleMenusCompanies = new System.Collections.Generic.List<ModuleMenuCompany>();
        }
    }
}
