using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPSync
{
    /// <summary>
    /// Every Service Provider class will contain this
    /// </summary>
    public enum ServiceExecutionFrequency
    {
        Hourly = 1,
        Daily = 2,
        Weekly = 3,
        Monthly = 4,
        Yearly = 5
    }

    

    public enum ServiceLogType
    {
        AttendanceProcessor = 1, BiometricDataUploader = 2, EmployeeStatusSunchronizer = 3, LeaveAccountSynchronizer = 4,SystemErrorLog = 5
    }
}