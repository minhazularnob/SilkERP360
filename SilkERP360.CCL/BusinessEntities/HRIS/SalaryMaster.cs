using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SALARY_MASTER", "SEQ_SALARY_MASTER")]
    public class SalaryMaster : SilkERP360.CCL.Validation.ValidationBase
    {

        public SalaryMaster()
        {
            this.m_objLst_SalaryList = new List<Salary>();
            
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_MASTER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SalaryMasterCode;
        public System.UInt64 SalaryMasterCode
        {
            get { return m_ui64_SalaryMasterCode; }
            set { this.m_ui64_SalaryMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_MONTH", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_SalaryMonth;
        public System.UInt32 SalaryMonth
        {
            get { return m_ui32_SalaryMonth; }
            set { this.m_ui32_SalaryMonth = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_YEAR", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_SalaryYear;
        public System.UInt32 SalaryYear
        {
            get { return m_ui32_SalaryYear; }
            set { this.m_ui32_SalaryYear = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_EMPLOYEE", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalEmployee;
        public System.UInt32 TotalEmployee
        {
            get { return m_ui32_TotalEmployee; }
            set { this.m_ui32_TotalEmployee = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_MANAGEMENT_APPROVED", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_IsManagementApproved;
        public System.UInt32 IsManagementApproved
        {
            get { return m_ui32_IsManagementApproved; }
            set { this.m_ui32_IsManagementApproved = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MANAGEMENT_EMP_CODE", typeof(System.UInt64), true, true)]
        protected System.UInt64 m_ui64_ManagementEmployeeCode;
        public System.UInt64 ManagementEmployeeCode
        {
            get { return m_ui64_ManagementEmployeeCode; }
            set { this.m_ui64_ManagementEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PREPARATION_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_PreparationEmployeeCode;
        public System.UInt64 PreparationEmployeeCode
        {
            get { return m_ui64_PreparationEmployeeCode; }
            set { this.m_ui64_PreparationEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SIGNATORY1_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Signatory1EmployeeCode;
        public System.UInt64 Signatory1EmployeeCode
        {
            get { return m_ui64_Signatory1EmployeeCode; }
            set { this.m_ui64_Signatory1EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SIGNATORY2_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Signatory2EmployeeCode;
        public System.UInt64 Signatory2EmployeeCode
        {
            get { return m_ui64_Signatory2EmployeeCode; }
            set { this.m_ui64_Signatory2EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SIGNATORY3_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Signatory3EmployeeCode;
        public System.UInt64 Signatory3EmployeeCode
        {
            get { return m_ui64_Signatory3EmployeeCode; }
            set { this.m_ui64_Signatory3EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PROCESS_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_ProcessDate;
        public System.DateTime ProcessDate
        {
            get { return m_dt_ProcessDate; }
            set { this.m_dt_ProcessDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("APPROVAL_PIN", typeof(System.String), true, true)]
        protected System.String m_str_ApprovalPin;
        public System.String ApprovalPin
        {
            get { return m_str_ApprovalPin; }
            set { this.m_str_ApprovalPin = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> m_objLst_SalaryList;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> SalaryList
        {
            get { return m_objLst_SalaryList; }
            set { m_objLst_SalaryList = value; }
        }

        /// <summary>
        /// Computed Field
        /// </summary>
        public System.UInt64 _TotalOvertimeMinutes;
        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalOvertimeAmount;

        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalDeductionTax;
        /// <summary>
        /// Loan Installment
        /// </summary>
        public System.Decimal _TotalDeductionAdvance;

        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalDeductionAbsent;

        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalDeductionLate;

        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalDeductionProvidentFund;
        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalDeductionOthers;
        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalAdditionAllowance;
        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalNightAllowance;
        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalAdditionOthers;

        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalGrossSalary;
        /// <summary>
        /// Computed Field
        /// </summary>
        public System.Decimal _TotalAmountPayable;

    }
}