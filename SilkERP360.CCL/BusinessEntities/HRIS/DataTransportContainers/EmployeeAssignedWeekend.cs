using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataTransportContainers
{
    /// <summary>
    /// Used while Assigning Weenend to employees
    /// </summary>
    public class EmployeeAssignedWeekend
    {
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

        private SilkERP360.CCL.Enums.WeekDay m_enm_WeekDayName;
        public SilkERP360.CCL.Enums.WeekDay WeekDayName
        {
            get { return m_enm_WeekDayName; }
            set { m_enm_WeekDayName = value; }
        }
    }
}
