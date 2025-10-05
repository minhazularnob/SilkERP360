using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class EmployeeProfile : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {

        public EmployeeProfile()
        {
        }
        
        public EmployeeProfile(System.UInt64 IP_ui64_EmployeeCode)
        {
            this.m_ui64_EmployeeCode = IP_ui64_EmployeeCode;
        }

        protected System.String m_str_BankAccountNo;

        public System.String BankAccountNo
        {
            get { return m_str_BankAccountNo; }
            set { m_str_BankAccountNo = value; }
        }

        protected System.String m_str_Tin;

        public System.String Tin
        {
            get { return this.m_str_Tin; }
            set { this.m_str_Tin = value; }
        }

        protected System.String m_str_EmployeeID;
        public System.String EmployeeID
        {
            get { return this.m_str_EmployeeID; }
            set { this.m_str_EmployeeID = value; }
        }
        //protected System.UInt16 m_ui16_IsRooster;
        //public System.UInt16 IsRooster
        //{
        //    get { return this.m_ui16_IsRooster; }
        //    set { this.m_ui16_IsRooster = value; }
        //}

        protected SilkERP360.CCL.Enums.YesNo m_enm_IsPFEligible;
        public SilkERP360.CCL.Enums.YesNo IsPFEligible
        {
            get { return this.m_enm_IsPFEligible; }
            set { this.m_enm_IsPFEligible = value; }
        }

        protected SilkERP360.CCL.Enums.YesNo m_enm_IsRooster;
        public SilkERP360.CCL.Enums.YesNo IsRooster
        {
            get { return this.m_enm_IsRooster; }
            set { this.m_enm_IsRooster = value; }
        }

        protected SilkERP360.CCL.Enums.YesNo m_enm_IsOTEligible;
        public SilkERP360.CCL.Enums.YesNo IsOTEligible
        {
            get { return this.m_enm_IsOTEligible; }
            set { this.m_enm_IsOTEligible = value; }
        }

        protected SilkERP360.CCL.Enums.YesNo m_enm_NightBillEligible;
        public SilkERP360.CCL.Enums.YesNo NightBillEligible
        {
            get { return m_enm_NightBillEligible; }
            set { this.m_enm_NightBillEligible = value; }
        }

        protected SilkERP360.CCL.Enums.YesNo m_enm_IsUniformEligible;
        public SilkERP360.CCL.Enums.YesNo IsUniformEligible
        {
            get { return m_enm_IsUniformEligible; }
            set { this.m_enm_IsUniformEligible = value; }
        }

        protected System.Decimal m_dcm_Salary;

        public System.Decimal Salary
        {
            get { return m_dcm_Salary; }
            set { this.m_dcm_Salary = value; }
        }


        protected System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return this.m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }

        protected System.DateTime m_dt_JoiningDate;
        public System.DateTime JoiningDate
        {
            get { return this.m_dt_JoiningDate; }
            set { this.m_dt_JoiningDate = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore m_obj_Company;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore Company
        {
            get { return this.m_obj_Company; }
            set { this.m_obj_Company = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore m_obj_Department;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.DepartmentCore Department
        {
            get { return this.m_obj_Department; }
            set { this.m_obj_Department = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore m_obj_Designation;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore Designation
        {
            get { return this.m_obj_Designation; }
            set { this.m_obj_Designation = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeImageCore m_obj_Image;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeImageCore Image
        {
            get { return this.m_obj_Image; }
            set { this.m_obj_Image = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure m_obj_SalaryStructure;
        public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeSalaryStructure SalaryStructure
        {
            get { return m_obj_SalaryStructure; }
            set { m_obj_SalaryStructure = value; }
        }
    }
}
