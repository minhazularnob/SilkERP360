using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("ATTENDANCE_MASTER", "SEQ_ATTN_MASTER")]
    public class AttendanceMaster : SilkERP360.CCL.Validation.ValidationBase
    {
        public AttendanceMaster()
        {
            this.m_objLst_AttendanceList = new List<Attendance>();
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ATTENDANCE_MASTER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_AttnMasterCode;
        public System.UInt64 AttnMasterCode
        {
            get { return m_ui64_AttnMasterCode; }
            set { this.m_ui64_AttnMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ATTENDANCE_DATE", typeof(System.DateTime), true, false)]
        protected System.DateTime m_dt_AttendaneDate;

        public System.DateTime AttendaneDate
        {
            get { return m_dt_AttendaneDate; }
            set { this.m_dt_AttendaneDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_PROCESSED", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalProcessed;

        public System.UInt32 TotalProcessed
        {
            get { return m_ui32_TotalProcessed; }
            set { this.m_ui32_TotalProcessed = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_LEAVE", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalLeave;

        public System.UInt32 TotalLeave
        {
            get { return m_ui32_TotalLeave; }
            set { this.m_ui32_TotalLeave = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_HOLIDAY", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalHoliday;

        public System.UInt32 TotalHoliday
        {
            get { return m_ui32_TotalHoliday; }
            set { this.m_ui32_TotalHoliday = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_PRESENT", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalPresent;

        public System.UInt32 TotalPresent
        {
            get { return m_ui32_TotalPresent; }
            set { this.m_ui32_TotalPresent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_LATE", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalLate;
        public System.UInt32 TotalLate
        {
            get { return m_ui32_TotalLate; }
            set { this.m_ui32_TotalLate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_ABSENT", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalAbsent;
        public System.UInt32 TotalAbsent
        {
            get { return m_ui32_TotalAbsent; }
            set { this.m_ui32_TotalAbsent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { this.m_ui64_EntryEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_SALARY_PROCESSED", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsSalaryProcessed;
        /// <summary>
        /// Signifies, if Salary processed for this Attendance Master
        /// If SalaryProcessed == YES -> Attendance not editable
        /// </summary>
        public SilkERP360.CCL.Enums.YesNo IsSalaryProcessed
        {
            get { return m_enm_IsSalaryProcessed; }
            set { m_enm_IsSalaryProcessed = value; }
        }

        /// <summary>
        /// Unit: Hour
        ///
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_MANHOUR_EXPECTED_OT", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalExpectedManhourOT;
        /// <summary>
        /// Unit: Hour
        ///Total Expected Man Hour for OT Eligible Employees
        /// </summary>
        public System.UInt32 TotalExpectedManhourOT
        {
            get { return m_ui32_TotalExpectedManhourOT; }
            set { this.m_ui32_TotalExpectedManhourOT = value; }
        }

        /// <summary>
        /// Unit: Hour
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_MANHOUR_SERVED_OT", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalManHourServedOT;
        /// <summary>
        /// Unit: Hour
        ///Total Served Man Hour for OT Eligible Employees
        /// </summary>
        public System.UInt32 TotalManHourServedOT
        {
            get { return m_ui32_TotalManHourServedOT; }
            set { this.m_ui32_TotalManHourServedOT = value; }
        }

        /// <summary>
        /// Unit: Minute
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_OVERTIME", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalOvertime;
        public System.UInt32 TotalOvertime
        {
            get { return m_ui32_TotalOvertime; }
            set { this.m_ui32_TotalOvertime = value; }
        }

        protected System.Decimal m_dcm_TotalOvertimeAmount;
        public System.Decimal TotalOvertimeAmount
        {
            get { return m_dcm_TotalOvertimeAmount; }
            set { m_dcm_TotalOvertimeAmount = value; }
        }

        protected System.Decimal m_dcm_AverageCostOfOvertimePerHour;
        public System.Decimal AverageCostOfOvertimePerHour
        {
            get { return m_dcm_AverageCostOfOvertimePerHour; }
            set { m_dcm_AverageCostOfOvertimePerHour = value; }
        }

        /// <summary>
        /// Unit: Hour
        ///
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_MANHOUR_EXPECTED_OFF", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalExpectedManhourOff;
        /// <summary>
        /// Unit: Hour
        ///Total Expected Man Hour for Non OT Employees
        /// </summary>
        public System.UInt32 TotalExpectedManhourOff
        {
            get { return m_ui32_TotalExpectedManhourOff; }
            set { this.m_ui32_TotalExpectedManhourOff = value; }
        }

        /// <summary>
        /// Unit: Hour
        /// </summary>
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TOTAL_MANHOUR_SERVED_OFF", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_TotalManHourServedOff;
        /// <summary>
        /// Unit: Hour
        ///Total Served Man Hour for Non OT Employees
        /// </summary>
        public System.UInt32 TotalManHourServedOff
        {
            get { return m_ui32_TotalManHourServedOff; }
            set { this.m_ui32_TotalManHourServedOff = value; }
        }


       

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Attendance> m_objLst_AttendanceList;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Attendance> AttendanceList
        {
            get { return m_objLst_AttendanceList; }
            set { m_objLst_AttendanceList = value; }
        }



    }
}
