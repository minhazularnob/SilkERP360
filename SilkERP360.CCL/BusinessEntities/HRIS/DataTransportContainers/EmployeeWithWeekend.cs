using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers
{
    public class EmployeeWithWeekend
    {
        private System.UInt64 m_ui64_WeekendCode;
        public System.UInt64 WeekendCode
        {
            get { return m_ui64_WeekendCode; }
            set { m_ui64_WeekendCode = value; }
        }

        private System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { m_ui64_EmployeeCode = value; }
        }

        private System.String m_str_EmployeeId;
        public System.String EmployeeId
        {
            get { return m_str_EmployeeId; }
            set { m_str_EmployeeId = value; }
        }

        private System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return m_str_EmployeeName; }
            set { m_str_EmployeeName = value; }
        }

        private System.String m_str_DepartmentName;
        public System.String DepartmentName
        {
            get { return m_str_DepartmentName; }
            set { m_str_DepartmentName = value; }
        }

        private System.String m_str_DesignationName;
        public System.String DesignationName
        {
            get { return m_str_DesignationName; }
            set { m_str_DesignationName = value; }
        }

        private System.DateTime m_dt_WeekendDate;
        public System.DateTime WeekendDate
        {
            get { return m_dt_WeekendDate; }
            set { m_dt_WeekendDate = value; }
        }
        
        private SilkERP360.CCL.Enums.WeekDay m_enm_WeekDayName;
        public SilkERP360.CCL.Enums.WeekDay WeekDayName
        {
            get { return m_enm_WeekDayName; }
            set { m_enm_WeekDayName = value; }
        }

        private System.String m_str_WeekDayName;
        public System.String WeekDayNameSTR
        {
            get { return m_str_WeekDayName; }
            set { m_str_WeekDayName = value; }
        }
    }
}
