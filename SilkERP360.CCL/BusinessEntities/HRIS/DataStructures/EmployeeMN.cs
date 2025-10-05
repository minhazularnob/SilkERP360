using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class EmployeeMN : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        private System.String m_str_EmployeeID;
        public System.String EmployeeID
        {
            get { return this.m_str_EmployeeID; }
            set { this.m_str_EmployeeID = value; }
        }

        private System.String m_str_EmployeeName;
        public System.String EmployeeName
        {
            get { return this.m_str_EmployeeName; }
            set { this.m_str_EmployeeName = value; }
        }

        public EmployeeMN(System.UInt64 IP_ui64_EmployeeCode, System.String IP_str_EmployeeID, System.String IP_str_EmployeeName)
        {
            this.m_ui64_EmployeeCode = IP_ui64_EmployeeCode;
            this.m_str_EmployeeID = IP_str_EmployeeID;
            this.m_str_EmployeeName = IP_str_EmployeeName;
        }
    }
}
