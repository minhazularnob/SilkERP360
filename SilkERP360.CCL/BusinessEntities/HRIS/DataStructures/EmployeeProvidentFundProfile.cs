using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class EmployeeProvidentFundProfile
    {
        public EmployeeProvidentFundProfile()
        {
            this.m_objLst_EmployeePFAccountTransactionList = new List<PFAccountTransaction>();
        }

        protected System.UInt64 m_ui64_PFAccountNumber;
        public System.UInt64 PFAccountNumber
        {
            get { return m_ui64_PFAccountNumber; }
            set { m_ui64_PFAccountNumber = value; }
        }

        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { m_ui64_EmployeeCode = value; }
        }

        protected System.String m_str_EmployeeID;
        public System.String EmployeeID
        {
            get { return this.m_str_EmployeeID; }
            set { this.m_str_EmployeeID = value; }
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

        protected SilkERP360.CCL.Enums.EmployeeStatus m_enm_EmployeeStatus;
        public SilkERP360.CCL.Enums.EmployeeStatus EmployeeStatus
        {
            get { return m_enm_EmployeeStatus; }
            set { m_enm_EmployeeStatus = value; }
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

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> m_objLst_EmployeePFAccountTransactionList;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction> EmployeePFAccountTransactionList
        {
            get { return this.m_objLst_EmployeePFAccountTransactionList; }
            set { this.m_objLst_EmployeePFAccountTransactionList = value; }
        }

        protected SilkERP360.CCL.Enums.ProvidentFundAccountStatus lcl_enm_PFAccountStatus;
        public SilkERP360.CCL.Enums.ProvidentFundAccountStatus PFAccountStatus
        {
            get { return lcl_enm_PFAccountStatus; }
            set { lcl_enm_PFAccountStatus = value; }
        }

        protected SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeImageCore m_obj_EmployeeImage;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeImageCore EmployeeImage
        {
            get { return m_obj_EmployeeImage; }
            set { m_obj_EmployeeImage = value; }
        }

        //protected SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount m_obj_LeaveAccount;
        //public SilkERP360.CCL.BusinessEntities.HRIS.EmployeeLeaveAccount LeaveAccount
        //{
        //    get { return m_obj_LeaveAccount; }
        //    set { m_obj_LeaveAccount = value; }
        //}
    }
}
