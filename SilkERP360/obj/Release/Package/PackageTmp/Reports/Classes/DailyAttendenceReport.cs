using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilkERP360.Reports.Classes
{
    public class DailyAttendenceReport
    {
        #region protected VARIABLES
        private UInt64 m_ui64_EmployeeCode;
        private System.String m_str_EmployeeID;
        private System.String m_str_EmployeeName;
        private System.String m_str_Designation;
        private System.String m_str_PunchDate;
        private System.String m_str_InTime;
        private System.String m_str_OutTime;
        private UInt16 m_ui16_OT;
        private System.String m_str_LateTime;
        private System.String m_str_Status;
        //private System.Collections.Generic.List<SilkERP360.Reports.Classes.DailyAttendenceReport> m_obj_Attendance;

        //public System.Collections.Generic.List<SilkERP360.Reports.Classes.DailyAttendenceReport> Attendance
        //{
        //    get { return m_obj_Attendance; }
        //   // set { m_obj_Attendance = value; }
        //}
        #endregion

        #region PUBLIC PROPERTIES
        public UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set {m_ui64_EmployeeCode = value; }
        }
        public String EmployeeID
        {
            get { return m_str_EmployeeID; }
            set { m_str_EmployeeID = value; }
        }
        public String EmployeeName
        {
            get { return m_str_EmployeeName; }
            set { m_str_EmployeeName = value; }
        }
        public String Designation
        {
            get { return m_str_Designation; }
            set { m_str_Designation = value; }
        }
        public String PunchDate
        {
            get { return m_str_PunchDate; }
            set { m_str_PunchDate = value; }
        }
        public String InTime
        {
            get { return m_str_InTime; }
            set { m_str_InTime = value; }
        }
        public String OutTime
        {
            get { return m_str_OutTime; }
            set { m_str_OutTime = value; }
        }
        public UInt16 OT
        {
            get { return m_ui16_OT; }
            set { m_ui16_OT = value; }
        }
        public String LateTime
        {
            get { return m_str_LateTime; }
            set { m_str_LateTime = value; }
        }
        public String Status
        {
            get { return m_str_Status; }
            set { m_str_Status = value; }
        }

        #endregion
    }
}