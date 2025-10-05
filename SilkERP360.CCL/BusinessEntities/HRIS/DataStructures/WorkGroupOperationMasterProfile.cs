using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS.DataStructures
{
    public class WorkGroupOperationMasterProfile
    {
        public System.UInt64 WorkGroupCode;
        public System.String WorkGroupName;
        public System.UInt64 WorkGroupOperationMasterCode;
        public System.UInt32 WorkerStrength;
        public System.DateTime WorkDate;
        public System.String DutyFrom;
        public System.UInt32 DutyHour;
        public System.UInt32 OvertimeLimit;
        public SilkERP360.CCL.Enums.WorkGroupOperationalStatus OperationalStatus;
        public SilkERP360.CCL.Enums.YesNo IsAttendanceProcessed;
    }
}
