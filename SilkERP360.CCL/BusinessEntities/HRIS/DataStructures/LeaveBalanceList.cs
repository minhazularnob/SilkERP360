using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// This class contains a list of LeaveBalance of all the leave types that en employee is entitled.
    /// </summary>
    public class LeaveBalanceList
    {
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return this.m_ui64_EmployeeCode; }
            //set { this.m_ui64_EmployeeCode = value; }
        }

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> m_objLst_LeaveBalances;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> LeaveBalances
        {
            get { return this.m_objLst_LeaveBalances; }
            //set { this.m_objLst_LeaveBalances = value; }
        }

        public LeaveBalanceList(System.UInt64 IP_ui64_EmployeeCode, System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.LeaveBalance> IP_objLst_LeaveBalances)
        {
            this.m_ui64_EmployeeCode = IP_ui64_EmployeeCode;
            this.m_objLst_LeaveBalances = IP_objLst_LeaveBalances;
        }
    }
}
