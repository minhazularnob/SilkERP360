using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.Containers.SCPM
{
    public class SCPMSection
    {
        public System.UInt64 _SectionCode_UI64;
        public System.UInt64 _CompanyCode_UI64;
        public System.String _Name_STR;
        public SilkERP360.CCL.Enums.Status _Status_ENM;
    }

    public class SCPMProcess
    {
        public System.UInt64 _ProcessCode_UI64;
        public System.UInt64 _SectionCode_UI64;
        public System.String _Name_STR;
        public SilkERP360.CCL.Enums.Status _Status_ENM;
    }

    public class SCPMMachine
    {
        public System.UInt64 _MachineCode_UI64;
        public System.UInt64 _CompanyCode_UI64;
        public System.String _Name_STR;
        public System.String _ShortName_STR;
        public System.UInt64 _ProcessCode_UI64;
        public SilkERPDataService.Containers.SCPM.MachineMeasurementUnit _MeasurementUnit_ENM;
        public System.UInt64 _SectionCode_UI64;
        public System.UInt32 _CommittedThroughput_UI32;
        public System.UInt32 _OptimumThroughput_UI32;
        public System.UInt32 _TargetThroughput_UI32;
        /// <summary>
        /// Current Throughput
        /// </summary>
        public System.UInt32 _Throughput_UI32;
        /// <summary>
        /// If Machine is ON/OFF/ServiceIntervention
        /// </summary>
        public SilkERPDataService.Containers.SCPM.MachineOperationalStatus _OperationalStatus;

        /// <summary>
        /// If Machine is active/InActive
        /// </summary>
        public SilkERP360.CCL.Enums.Status _Status;
    }

    /// <summary>
    /// This class will contain details of Machines along with
    /// Section,Process objects
    /// </summary>
    public class SCPMMachineDetails
    {
        public System.UInt64 _MachineCode_UI64;
        public SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore _Company_OBJ;
        public System.String _Name_STR;
        public SilkERPDataService.Containers.SCPM.SCPMProcess _Process_OBJ;
        public SilkERPDataService.Containers.SCPM.MachineMeasurementUnit _MeasurementUnit_ENM;
        public SilkERPDataService.Containers.SCPM.SCPMSection _Section_OBJ;
        public System.UInt32 _CommittedThroughput_UI32;
        public System.UInt32 _OptimumThroughput_UI32;
        public System.UInt32 _TargetThroughput_UI32;
        /// <summary>
        /// Current Throughput
        /// </summary>
        public System.UInt32 _Throughput_UI32;
        /// <summary>
        /// If Machine is ON/OFF/ServiceIntervention
        /// </summary>
        public SilkERPDataService.Containers.SCPM.MachineOperationalStatus _OperationalStatus;

        /// <summary>
        /// If Machine is active/InActive
        /// </summary>
        public SilkERP360.CCL.Enums.Status _Status;
    }

    /// <summary>
    /// This class will contain details of Machines along with
    /// string representation of certain properties which will be required
    /// to be displayed to client
    /// </summary>
    public class SCPMMachineSTR
    {
        public System.UInt64 _MachineCode_UI64;
        public System.String _Name_STR;
        public System.UInt64 _CompanyCode_UI64;
        public System.String _CompanyName_STR;
        public System.UInt64 _SectionCode_UI64;
        public System.String _SectionName_STR;
        public System.UInt64 _ProcessCode_UI64;
        public System.String _ProcessName_STR;
        public SilkERPDataService.Containers.SCPM.MachineMeasurementUnit _MeasurementUnit_ENM;
        public System.String _MeasurementUnit_STR;
        public System.UInt32 _CommittedThroughput_UI32;
        public System.UInt32 _OptimumThroughput_UI32;
        public System.UInt32 _TargetThroughput_UI32;
        //public System.UInt32 _Throughput_UI32;
        /// <summary>
        /// If Machine is ON/OFF/ServiceIntervention
        /// </summary>
        public SilkERPDataService.Containers.SCPM.MachineOperationalStatus _OperationalStatus_ENM;
        public System.String _OperationalStatus_STR;
    }

    public class SCMachineThroughput
    {
        public System.UInt64 _ThroughputCode_UI64;
        public System.UInt64 _MachineCode_UI64;
        public System.UInt64 _ShiftCode_UI64;
        public System.UInt32 _TargetThroughput_UI32;
        public System.Int64 _Throughput_I64;
        public System.UInt32 _Wastage_UI32;
        public System.DateTime _ThroughputDateTime_DT;
        public System.UInt64 _EntryEmployeeCode_UI64;
        public System.String _Remarks_STR;
        public System.DateTime _EntryDateTime_DT;
        public SilkERPDataService.Containers.SCPM.DailySCPMMachineStatus _DailySCPMMachineStatus;
    }

    
}