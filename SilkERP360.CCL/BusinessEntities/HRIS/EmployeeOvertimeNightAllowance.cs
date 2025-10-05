using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    /// <summary>
    /// TEMPORARY OBJECT
    /// </summary>
    public class EmployeeOvertimeNightAllowance
    {
        public System.UInt64 _EmployeeCode;
        public System.String _BankAccountNo;
        public System.String _Tin; // Tin 28-Jan-2017, SSL
        public System.String _EmployeeId;
        public System.String _EmployeeName;
        public System.String _Designation;
        public System.String _Department;
        public System.Decimal _Basic;
        public System.Decimal _HouseRent;
        public System.Decimal _Conveyence;
        public System.Decimal _Medical;
        public System.Decimal _Gross;
        public System.Decimal _OvertimeRate;
        public System.UInt32 _OvertimeMinutes;
        public System.Double _OvertimeHour;
        public System.Decimal _OvertimeAmount;
        public System.Decimal _NightAllowance;
        public System.Decimal _TotalPayable;
    }
}
