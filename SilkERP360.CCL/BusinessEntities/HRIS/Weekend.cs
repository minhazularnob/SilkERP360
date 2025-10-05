using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WEEKEND", "SEQ_WEEKEND")]
    public class Weekend : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WEEKEND_CODE", typeof(System.UInt64), false, false)]
        private System.UInt64 m_uint64_WeekendCode;
        public System.UInt64 WeekendCode
        {
            get { return m_uint64_WeekendCode; }
            set { this.m_uint64_WeekendCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        private System.UInt64 m_uint64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WEEKEND_DATE", typeof(System.DateTime), false, false)]
        private System.DateTime m_dt_WeekendDate;
        public System.DateTime WeekendDate
        {
            get { return m_dt_WeekendDate; }
            set { m_dt_WeekendDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WEEK_DAY", typeof(SilkERP360.CCL.Enums.WeekDay), false, false)]
        private SilkERP360.CCL.Enums.WeekDay m_enm_Weekday;
        public SilkERP360.CCL.Enums.WeekDay Weekday
        {
            get { return m_enm_Weekday; }
            set { m_enm_Weekday = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WEEK_NUMBER", typeof(System.Int32), false, false)]
        private System.Int32 m_int32_WeekNumber;
        public System.Int32 WeekNumber
        {
            get { return m_int32_WeekNumber; }
            set { m_int32_WeekNumber = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("YEAR", typeof(System.Int32), false, false)]
        private System.Int32 m_int32_Year;
        public System.Int32 Year
        {
            get { return m_int32_Year; }
            set { m_int32_Year = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        private System.UInt64 m_uint64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_uint64_EntryEmployeeCode; }
            set { m_uint64_EntryEmployeeCode = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), false, false)]
        private System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return m_dt_EntryDate; }
            set { m_dt_EntryDate = value; }
        }
    }
}
