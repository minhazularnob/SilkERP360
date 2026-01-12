using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilkERP360.Reports.Classes
{
	public class AttendanceReport
	{
       

        #region protected VARIABLES
        private UInt64 m_ui64_EmployeeCode;
        private System.String m_str_EmployeeID;
        //protected System.String m_str_EmployeeName;
        //protected System.String m_str_Designation;
        //protected System.String m_str_PunchDate;
        //protected System.String m_str_InTime;
        //protected System.String m_str_OutTime;
        //protected UInt16 m_ui16_OT;
        //protected System.String m_str_LateTime;
        //protected System.String m_str_Status;
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
        //public String EmployeeName
        //{
        //    get { return m_str_EmployeeName; }
        //    set { this.m_str_EmployeeName = value; }
        //}
        //public String Designation
        //{
        //    get { return m_str_Designation; }
        //    set { this.m_str_Designation = value; }
        //}
        //public String PunchDate
        //{
        //    get { return m_str_PunchDate; }
        //    set { this.m_str_PunchDate = value; }
        //}
        //public String InTime
        //{
        //    get { return m_str_InTime; }
        //    set { m_str_InTime = value; }
        //}
        //public String OutTime
        //{
        //    get { return m_str_OutTime; }
        //    set { this.m_str_OutTime = value; }
        //}
        //public UInt16 OT
        //{
        //    get { return m_ui16_OT; }
        //    set { this.m_ui16_OT = value; }
        //}
        //public String LateTime
        //{
        //    get { return m_str_LateTime; }
        //    set { this.m_str_LateTime = value; }
        //}
        //public String Status
        //{
        //    get { return m_str_Status; }
        //    set { this.m_str_Status = value; }
        //}

        #endregion
	}
}