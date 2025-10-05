using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    /// <summary>
    /// This class will contain details of a Leave that an employee is entitled along with Balance...Number of days
    /// remaining for the Leave
    /// </summary>
    public class LeaveBalance : SilkERP360.CCL.BusinessEntities.HRIS.Leave
    {
        protected System.UInt16 m_ui16_Balance;
        public System.UInt16 Balance
        {
            get { return this.m_ui16_Balance; }
            set { this.m_ui16_Balance = value; }
        }

        
        public LeaveBalance(System.UInt64 IP_ui64_LeaveCode, UInt64 IP_ui64_CompanyCode, System.String IP_str_LeaveName, System.String IP_str_ShortName, System.UInt32 IP_ui32_NoOfDays, System.UInt16 IP_ui16_IsCarryForwarded, System.UInt16 IP_ui16_LeaveBalance)
            :base(IP_ui64_LeaveCode,IP_ui64_CompanyCode,IP_str_LeaveName,IP_str_ShortName,IP_ui32_NoOfDays,IP_ui16_IsCarryForwarded)
        {
            this.m_ui16_Balance = IP_ui16_LeaveBalance;
                            
        }
    }
}
