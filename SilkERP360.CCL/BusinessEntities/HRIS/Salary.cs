using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SALARY", "SEQ_SALARY")]
    public class Salary : CCL.Validation.ValidationBase
    {

        public Salary()
        {
            this.m_objLst_SalaryAdditionDeductionList = new List<SalaryAdditionDeduction>();
        }

        public System.String _EmployeeID;
        public System.String _EmployeeName;
        public System.String _Department;
        public System.String _Designation;
        
        /// <summary>
        /// /If Emp is eligible, will contain Fixed Allowance in SilkERP.MonthlyAllowance
        /// While Saving Salary, an ADDITION.ALLOWANCE entry will be made
        /// </summary>
        //public System.Decimal _MonthlyFixedAllowance;

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SalaryCode;
        public System.UInt64 SalaryCode
        {
            get { return m_ui64_SalaryCode; }
            set { this.m_ui64_SalaryCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_MASTER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SalaryMasterCode;
        public System.UInt64 SalaryMasterCode
        {
            get { return m_ui64_SalaryMasterCode; }
            set { this.m_ui64_SalaryMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BANK_ACCOUNT_NO", typeof(System.String), true, false)]
        protected System.String m_str_BankAccountNo;
        public System.String BankAccountNo
        {
            get { return m_str_BankAccountNo; }
            set { this.m_str_BankAccountNo = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NOTES", typeof(System.String), true, false)]
        protected System.String m_str_Notes;
        public System.String Notes
        {
            get { return m_str_Notes; }
            set { this.m_str_Notes = value; }
        }


        /// <summary>
        ///  TIN 28-Jan-2017, SSL
        /// </summary>

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TIN", typeof(System.String), true, false)]
        protected System.String m_str_Tin;
        public System.String Tin
        {
            get { return m_str_Tin; }
            set { this.m_str_Tin = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_ARREAR", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionArrear;
        public System.Decimal AdditionArrear
        {
            get { return m_dbl_AdditionArrear; }
            set { this.m_dbl_AdditionArrear = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_BONUS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionBonus;
        public System.Decimal AdditionBonus
        {
            get { return m_dbl_AdditionBonus; }
            set { this.m_dbl_AdditionBonus = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_PHONE_BILL", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionPhoneBill;
        public System.Decimal AdditionPhoneBill
        {
            get { return m_dbl_AdditionPhoneBill; }
            set { this.m_dbl_AdditionPhoneBill = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_INCENTIVE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionIncentive;
        public System.Decimal AdditionIncentive
        {
            get { return m_dbl_AdditionIncentive; }
            set { this.m_dbl_AdditionIncentive = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_ALLOWANCE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionAllowance;
        public System.Decimal AdditionAllowance
        {
            get { return m_dbl_AdditionAllowance; }
            set { this.m_dbl_AdditionAllowance = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_OTHERS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionOthers;
        public System.Decimal AdditionOthers
        {
            get { return m_dbl_AdditionOthers; }
            set { this.m_dbl_AdditionOthers = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("A_NIGHT_ALLOWANCE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_AdditionNightAllowance;
        public System.Decimal AdditionNightAllowance
        {
            get { return m_dbl_AdditionNightAllowance; }
            set { this.m_dbl_AdditionNightAllowance = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_ADVANCE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionAdvance;
        public System.Decimal DeductionAdvance
        {
            get { return m_dbl_DeductionAdvance; }
            set { this.m_dbl_DeductionAdvance = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_PENALTY", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionPenalty;
        public System.Decimal DeductionPenalty
        {
            get { return m_dbl_DeductionPenalty; }
            set { this.m_dbl_DeductionPenalty = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_INCOME_TAX", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionIncomeTax;
        public System.Decimal DeductionIncomeTax
        {
            get { return m_dbl_DeductionIncomeTax; }
            set { this.m_dbl_DeductionIncomeTax = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_LATE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionLate;
        public System.Decimal DeductionLate
        {
            get { return m_dbl_DeductionLate; }
            set { this.m_dbl_DeductionLate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_UNPAID_LEAVE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionUnpaidLeave;
        public System.Decimal DeductionUnpaidLeave
        {
            get { return m_dbl_DeductionUnpaidLeave; }
            set { this.m_dbl_DeductionUnpaidLeave = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_ABSENT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionAbsent;
        public System.Decimal DeductionAbsent
        {
            get { return m_dbl_DeductionAbsent; }
            set { this.m_dbl_DeductionAbsent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_OTHERS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionOthers;
        public System.Decimal DeductionOthers
        {
            get { return m_dbl_DeductionOthers; }
            set { this.m_dbl_DeductionOthers = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("D_PROVIDENT_FUND", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_DeductionProvidentFund;
        public System.Decimal DeductionProvidentFund
        {
            get { return m_dbl_DeductionProvidentFund; }
            set { this.m_dbl_DeductionProvidentFund = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BASIC", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_Basic;
        public System.Decimal Basic
        {
            get { return m_dbl_Basic; }
            set { this.m_dbl_Basic = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HOUSE_RENT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_HouseRent;
        public System.Decimal HouseRent
        {
            get { return m_dbl_HouseRent; }
            set { this.m_dbl_HouseRent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MEDICAL", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_Medical;
        public System.Decimal Medical
        {
            get { return m_dbl_Medical; }
            set { this.m_dbl_Medical = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CONVEYENCE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_Conveyence;
        public System.Decimal Conveyence
        {
            get { return m_dbl_Conveyence; }
            set { this.m_dbl_Conveyence = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTERTAINMENT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_Entertainment;
        public System.Decimal Entertainment
        {
            get { return m_dbl_Entertainment; }
            set { this.m_dbl_Entertainment = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("GROSS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_Gross;
        public System.Decimal Gross
        {
            get { return m_dbl_Gross; }
            set { this.m_dbl_Gross = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_MINUTES", typeof(System.Double), true, false)]
        protected System.Double m_dbl_OverTimeMinutes;
        public System.Double OverTimeMinutes
        {
            get { return m_dbl_OverTimeMinutes; }
            set { this.m_dbl_OverTimeMinutes = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_AMOUNT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_OverTimeAmount;
        public System.Decimal OverTimeAmount
        {
            get { return m_dbl_OverTimeAmount; }
            set { this.m_dbl_OverTimeAmount = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("GRAND_TOTAL", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dbl_GrandTotal;
        public System.Decimal GrandTotal
        {
            get { return m_dbl_GrandTotal; }
            set { this.m_dbl_GrandTotal = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_STATUS", typeof(System.UInt16), true, false)]
        //protected System.UInt16 m_ui16_SalaryStatus;
        //public System.UInt16 SalaryStatus
        //{
        //    get { return m_ui16_SalaryStatus; }
        //    set { this.m_ui16_SalaryStatus = value; }
        //}

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SALARY_STATUS", typeof(SilkERP360.CCL.Enums.SalaryStatus), false, false)]
        protected SilkERP360.CCL.Enums.SalaryStatus m_enm_SalaryStatus;
        public SilkERP360.CCL.Enums.SalaryStatus SalaryStatus
        {
            get { return m_enm_SalaryStatus; }
            set { this.m_enm_SalaryStatus = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ABSENT_DEDUCTION_WAIVED", typeof(CCL.Enums.YesNo), true, false)]
        private CCL.Enums.YesNo m_enm_IsAbsentDeductionWaived;
        public CCL.Enums.YesNo IsAbsentDeductionWaived
        {
            get { return m_enm_IsAbsentDeductionWaived; }
            set { m_enm_IsAbsentDeductionWaived = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_LATE_DEDUCTION_WAIVED", typeof(CCL.Enums.YesNo), true, false)]
        private CCL.Enums.YesNo m_enm_IsLateDeductionWaived;
        public CCL.Enums.YesNo IsLateDeductionWaived
        {
            get { return m_enm_IsLateDeductionWaived; }
            set { m_enm_IsLateDeductionWaived = value; }
        }

        /// <summary>
        /// To Be filled up while generating Salary.
        /// To be saved while Saving salary;
        /// </summary>
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> m_objLst_SalaryAdditionDeductionList;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.SalaryAdditionDeduction> SalaryAdditionDeductionList
        {
            get { return this.m_objLst_SalaryAdditionDeductionList; }
            set { this.m_objLst_SalaryAdditionDeductionList = value; }
        }

    }
}
