using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    
    public enum ServiceLogType
    {
        AttendanceProcessor = 1, 
        BiometricDataUploader = 2, 
        EmployeeStatusSunchronizer = 3, 
        LeaveAccountSynchronizer = 4,
        TaxProcessor = 5,
        MonthlyAllowanceProcessor = 6
    }
}