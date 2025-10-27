using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class Employee : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR

        public Employee()
        {

        }

        #endregion

        #region VALIDATION
        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "EmployeeName", Message = "Employee Name Entry")]
        #endregion

        #region  protected VARIABLE

        protected System.UInt64 m_ui64_EmployeeCode;
        protected System.String m_str_EmployeeId;
        protected System.String m_str_EmployeeAcsCode;
        protected System.String m_str_EmployeeName;
        protected System.UInt64 m_ui64_DesignationCode;
        protected System.String m_str_DesignationName;
        protected System.UInt64 m_ui64_DepartmentCode;
        protected System.String m_str_DepartmentName;
        protected System.UInt64 m_ui64_CompanyCode;
        protected System.UInt64 m_ui64_RefEmployeeCode;
        protected System.UInt64 m_ui64_SupervisorCode;
        protected System.DateTime m_dt_JoiningDate;
        protected System.DateTime m_dt_ConfirmationDate;
        protected System.DateTime m_dt_RetirementDate;
        protected System.DateTime m_dt_SettlementDate;
        protected System.String m_str_OfficialFileNo;
        protected System.String m_str_Tin;
        protected System.String m_str_Remarks;
        protected System.UInt16 m_ui16_IsPfEligible;
        protected System.UInt64 m_ui64_PfCode;
        protected System.UInt16 m_ui16_IsOtEligible;
        protected System.UInt16 m_ui16_SalaryPayableAtBank;
        protected System.String m_str_BankAccNo;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_EmployeeStatus;
        protected System.UInt16 m_ui16_IsOnRoster;
        protected System.UInt64 m_ui64_ShiftCode;
        protected System.String m_str_BankName;
        protected System.UInt16 m_ui16_NightBillEligible;
        protected System.String m_str_JobLocation;
        protected System.UInt16 m_ui16_ComUniformEligible;
        protected System.String m_str_BondRefference;
        protected System.DateTime m_dt_BondIssueDate;
        protected System.DateTime m_dt_BondValidityDate;
        protected System.UInt32 m_ui32_BondYear;
        protected System.UInt16 m_ui16_eTinEligible;

        #endregion

        #region PUBLIC PROPERTIES


        public System.UInt64 EmployeeCode
        {
            get { return this.m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }
        public System.String EmployeeId
        {
            get { return this.m_str_EmployeeId; }
            set { this.m_str_EmployeeId = value; }
        }
        public System.String EmployeeACSCode
        {
            get { return this.m_str_EmployeeAcsCode; }
            set { this.m_str_EmployeeAcsCode = value; }
        }
        public System.String EmployeeName
        {
            get { return this.m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }
        public System.UInt64 DesignationCode
        {
            get { return this.m_ui64_DesignationCode; }
            set { this.m_ui64_DesignationCode = value; }
        }
        public System.String DesignationName
        {
            get { return m_str_DesignationName; }
            set { this.m_str_DesignationName = value; }
        }
        public System.UInt64 DepartmentCode
        {
            get { return this.m_ui64_DepartmentCode; }
            set { this.m_ui64_DepartmentCode = value; }
        }
        public System.String DepartmentName
        {
            get { return m_str_DepartmentName; }
            set { this.m_str_DepartmentName = value; }
        }
        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }
        public System.UInt64 RefEmployeeCode
        {
            get { return this.m_ui64_RefEmployeeCode; }
            set { this.m_ui64_RefEmployeeCode = value; }
        }
        public System.UInt64 SupervisorCode
        {
            get { return this.m_ui64_SupervisorCode; }
            set { this.m_ui64_SupervisorCode = value; }
        }
        public System.DateTime JoiningDate
        {
            get { return this.m_dt_JoiningDate; }
            set { this.m_dt_JoiningDate = value; }
        }
        public System.DateTime ConfirmationDate
        {
            get { return this.m_dt_ConfirmationDate; }
            set { this.m_dt_ConfirmationDate = value; }
        }
        public System.DateTime RetirementDate
        {
            get { return this.m_dt_RetirementDate; }
            set { this.m_dt_RetirementDate = value; }
        }
        public System.DateTime SettlementDate
        {
            get { return this.m_dt_SettlementDate; }
            set { this.m_dt_SettlementDate = value; }
        }
        public System.String OfficialFileNo
        {
            get { return this.m_str_OfficialFileNo; }
            set { this.m_str_OfficialFileNo = value; }
        }
        public System.String Tin
        {
            get { return this.m_str_Tin; }
            set { this.m_str_Tin = value; }
        }
        public System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }
        public System.UInt16 IsPfEligible
        {
            get { return this.m_ui16_IsPfEligible; }
            set { this.m_ui16_IsPfEligible = value; }
        }
        public System.UInt64 PfCode
        {
            get { return this.m_ui64_PfCode; }
            set { this.m_ui64_PfCode = value; }
        }
        public System.UInt16 IsOtEligible
        {
            get { return this.m_ui16_IsOtEligible; }
            set { this.m_ui16_IsOtEligible = value; }
        }
        public System.UInt16 SalaryPayableAtBank
        {
            get { return this.m_ui16_SalaryPayableAtBank; }
            set { this.m_ui16_SalaryPayableAtBank = value; }
        }
        public System.String BankAccNo
        {
            get { return m_str_BankAccNo; }
            set { this.m_str_BankAccNo = value; }
        }
        public System.UInt16 IsDeleted
        {
            get { return this.m_ui16_IsDeleted; }
            set { this.m_ui16_IsDeleted = value; }
        }
        public System.UInt16 EmployeeStatus
        {
            get { return this.m_ui16_EmployeeStatus; }
            set { this.m_ui16_EmployeeStatus = value; }
        }
        public System.UInt16 IsOnRoster
        {
            get { return this.m_ui16_IsOnRoster; }
            set { this.m_ui16_IsOnRoster = value; }
        }
        public System.UInt64 ShiftCode
        {
            get { return this.m_ui64_ShiftCode; }
            set { this.m_ui64_ShiftCode = value; }
        }
        public System.String BankName
        {
            get { return m_str_BankName; }
            set { this.m_str_BankName = value; }
        }

        public System.UInt16 NightBillEligible
        {
            get { return m_ui16_NightBillEligible; }
            set { this.m_ui16_NightBillEligible = value; }
        }        

        public System.String JobLocation
        {
            get { return m_str_JobLocation; }
            set { this.m_str_JobLocation = value; }
        }
        
        public System.UInt16 ComUniformEligible
        {
            get { return m_ui16_ComUniformEligible; }
            set { this.m_ui16_ComUniformEligible = value; }
        }

        public System.DateTime BondValidityDate
        {
            get { return m_dt_BondValidityDate; }
            set { this.m_dt_BondValidityDate = value; }
        }
        public System.String BondRefference
        {
            get { return m_str_BondRefference; }
            set { this.m_str_BondRefference = value; }
        }

        public System.DateTime BondIssueDate
        {
            get { return m_dt_BondIssueDate; }
            set { this.m_dt_BondIssueDate = value; }
        }

        public System.UInt32 BondYear
        {
            get { return m_ui32_BondYear; }
            set { this.m_ui32_BondYear = value; }
        }
        public System.UInt16 eTinEligible
        {
            get { return m_ui16_eTinEligible; }
            set { this.m_ui16_eTinEligible = value; }
        }
        #endregion
    }
}
