using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilkERP360.Reports.Classes
{
    public class AttendanceReportList

    {


        public AttendanceReportList()
        {

           
        }

        private System.Collections.Generic.List<SilkERP360.Reports.Classes.DailyAttendenceReport> m_obj_Attendance;

        public System.Collections.Generic.List<SilkERP360.Reports.Classes.DailyAttendenceReport> Attendance
        {
            get { return m_obj_Attendance; }
             set { m_obj_Attendance = value; }
        }


    }
}