using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("MONTHLY_ALLOWANCE", "SEQ_MONTHLY_ALLOWANCE")]
    public class MonthlyAllowance : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("M_ALLOWANCE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_MonthlyAllowanceCode;
        public System.UInt64 MonthlyAllowanceCode
        {
            get { return m_ui64_MonthlyAllowanceCode; }
            set { this.m_ui64_MonthlyAllowanceCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("M_ALLOWANCE_TYPE", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_MonthlyAllowanceType;
        public System.UInt32 MonthlyAllowanceType
        {
            get { return m_ui32_MonthlyAllowanceType; }
            set { this.m_ui32_MonthlyAllowanceType = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("AMOUNT", typeof(System.Double), true, false)]
        protected System.Double m_dbl_Amount;
        public System.Double Amount
        {
            get { return m_dbl_Amount; }
            set { this.m_dbl_Amount = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_MONTH_FROM", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_EffectiveMonthFrom;
        public System.UInt32 EffectiveMonthFrom
        {
            get { return m_ui32_EffectiveMonthFrom; }
            set { this.m_ui32_EffectiveMonthFrom = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_YEAR_FROM", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_EffectiveYearFrom;
        public System.UInt32 EffectiveYearFrom
        {
            get { return m_ui32_EffectiveYearFrom; }
            set { this.m_ui32_EffectiveYearFrom = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_MONTH_UPTO", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_EffectiveMonthUpto;
        public System.UInt32 EffectiveMonthUpto
        {
            get { return m_ui32_EffectiveMonthUpto; }
            set { this.m_ui32_EffectiveMonthUpto = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_YEAR_UPTO", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_EffectiveYearUpto;
        public System.UInt32 EffectiveYearUpto
        {
            get { return m_ui32_EffectiveYearUpto; }
            set { this.m_ui32_EffectiveYearUpto = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        protected System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return m_dt_EntryDate; }
            set { this.m_dt_EntryDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { this.m_ui64_EntryEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_enm_Status;
        public CCL.Enums.YesNo Status
        {
            get { return m_enm_Status; }
            set { this.m_enm_Status = value; }
        }
    }
}
