using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Attendance Summery for Single Employee Based on Date Range
    /// </summary>
    public class EmployeeAttendanceSummery
    {
        public System.UInt64 EmployeeCode;
        public System.String EmployeeId;
        public System.String EmployeeName;
        public System.String Designation;
        public System.String Department;

        /// <summary>
        /// Number Of Days The Summery is Generated For
        /// </summary>
        public System.UInt32 TotalDays;
        public System.UInt32 TotalLate;
        public System.UInt32 TotalLateApproved;
        public System.UInt32 TotalAbsent;
        public System.UInt32 TotalWorkOnHoliday;
        public System.UInt32 TotalHoliday;
        public System.UInt32 TotalPresent;
        public System.UInt32 TotalWeekend;
        public System.UInt32 TotalLeave;
        

        /// <summary>
        /// Total WorkHour the Employee Was Suppose to WorkFor
        /// </summary>
        public System.Double TotalDesignatedWorkHour;
        /// <summary>
        /// Total Work Hour The Employee Served
        /// </summary>
        public System.Double TotalWorkHour;

        public System.Double TotalOvertimeAuto;
        public System.Double TotalOvertimeManual;
        public System.Double TotalOvertime;

        public System.Decimal TotalNightAllowance;
    }
}
