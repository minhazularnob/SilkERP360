using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class EmployeeAttendanceSummeryMaster
    {
        /// <summary>
        /// Number Of Days The Summery Master is Generated For
        /// </summary>
        //public System.UInt32 TotalDays;
        //public System.UInt32 TotalLate;
        //public System.UInt32 TotalLateApproved;
        //public System.UInt32 TotalAbsent;
        //public System.UInt32 TotalWorkOnHoliday;
        //public System.UInt32 TotalHoliday;
        //public System.UInt32 TotalPresent;
        //public System.UInt32 TotalWeekend;
        //public System.UInt32 TotalLeave;

        public System.DateTime DateFrom;
        public System.DateTime DateUpto;

        public System.UInt32 TotalDays;
        public System.UInt32 TotalEmployees;

        /// <summary>
        /// Total WorkHour All employees were Suppose to WorkFor
        /// </summary>
        public System.Double TotalDesignatedWorkHour;
        /// <summary>
        /// Total Work Hour All employees served combined
        /// </summary>
        public System.Double TotalWorkHour;

        public System.Double TotalOvertimeAuto;
        public System.Double TotalOvertimeManual;
        public System.Double TotalOvertime;
        public Decimal TotalNightAllowance;
        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery> m_obj_AttendanceSummeryList;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeAttendanceSummery> AttendanceSummeryList
        {
            get { return m_obj_AttendanceSummeryList; }
            set { m_obj_AttendanceSummeryList = value; }
        }

        public EmployeeAttendanceSummeryMaster()
        {
            this.m_obj_AttendanceSummeryList = new List<EmployeeAttendanceSummery>();
        }
    }
}
