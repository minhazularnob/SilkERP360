using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// Carrier Class. No Corresponding DB Entity
    /// </summary>
    public class EmployeewiseAttendanceByDateRange
    {
        public EmployeewiseAttendanceByDateRange()
        {
            this.DaysAttendanceList = new List<DaysAttendance>();
        }
        public System.String EmployeeId;
        public System.String Name;
        public System.String Company;
        public System.String Department;
        public System.String Designation;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeImageCore EmployeeImage;

        /// <summary>
        /// Format : dd/MMMM/yyyy(FromDate) TO dd/MMMM/yyyy
        /// </summary>
        public System.String ReportDateRange;

        public System.Int32 TotalAttendanceDays;
        public System.UInt32 TotalPresent;
        public System.UInt32 TotalAbsent;
        public System.Double TotalAbsentPercentage;
        public System.UInt32 TotalLate;
        public System.Double TotalLatePercentage;
        public System.UInt32 TotalWorkOnHoliday;
        public System.UInt32 TotalHoliday;
        public System.UInt32 TotalWeekend;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String TotalWorkHourExpected;
        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String TotalWorkHourServed;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String TotalOvertimeAuto;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String TotalOvertimeManual;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String TotalOvertime;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String TotalNightAllowance;

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.DaysAttendance> DaysAttendanceList;
    }

    public class DaysAttendance
    {
        /// <summary>
        /// Format: dd/MM/yyyy
        /// </summary>
        public System.String AttendanceDate;

        /// <summary>
        /// Format: dd/MM/yyyy hh:mi:ss AM/PM TO dd/MM/yyyy hh:mi:ss AM/PM
        /// </summary>
        public System.String DutyScheduleDateTime;

        /// <summary>
        /// Format: dd/MM/yyyy hh:mi:ss AM/PM TO dd/MM/yyyy hh:mi:ss AM/PM
        /// </summary>
        public System.String DutyDateTime;

        /// <summary>
        /// Format: HH:MM
        /// </summary>
        public System.String DutyHour;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String OvertimeAuto;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String OvertimeManual;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String Overtime;

        /// <summary>
        /// Format : HH:MM 
        /// </summary>
        public System.String NightAllowance;

        /// <summary>
        /// </summary>
        public System.String AttendanceStatus;

        /// <summary>
        /// </summary>
        public System.String Remarks;
    }
}