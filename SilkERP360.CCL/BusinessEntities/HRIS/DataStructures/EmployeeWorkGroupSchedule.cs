using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{

    public class EmployeeWorkGroupSchedule
    {
        public System.UInt64 EmployeeCode;
        public System.String EmployeeId;
        public System.String EmployeeName;
        public System.String Designation;
        public System.String Department;
        public System.String WorkGroupName;
        public System.UInt64 WorkGroupOperationMasterCode;
        public System.DateTime DutyScheduleFrom;
        public System.DateTime DutyScheduleUpto;

    }
}
