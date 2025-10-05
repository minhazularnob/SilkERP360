using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.Containers.SCPM.DataStructure
{
    public class SCPMSectionExt : SilkERPDataService.Containers.SCPM.SCPMSection
    {
        /// <summary>
        /// Processes that belongs to this section
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMProcessExt> _SCPMProcesses = null;

        public SCPMSectionExt()
            : base()
        {
            this._SCPMProcesses = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMProcessExt>();
        }
    }

    /// <summary>
    /// Contains Average Throughput
    /// </summary>
    public class SCPMAvgSectionExt : SilkERPDataService.Containers.SCPM.SCPMSection
    {
        /// <summary>
        /// Processes that belongs to this section
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgProcessExt> _SCPMProcesses = null;

        public SCPMAvgSectionExt(SilkERPDataService.Containers.SCPM.SCPMSection IP_obj_Section)
            : base()
        {
            this._SectionCode_UI64 = IP_obj_Section._SectionCode_UI64;
            this._CompanyCode_UI64 = IP_obj_Section._CompanyCode_UI64;
            this._Name_STR = IP_obj_Section._Name_STR;
            this._SCPMProcesses = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgProcessExt>();
        }
    }

    public class SCPMProcessExt : SilkERPDataService.Containers.SCPM.SCPMProcess
    {
        /// <summary>
        /// Machines that belongs to this process
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt> _SCPMProductionMachines = null;

        public SCPMProcessExt()
            : base()
        {
            this._SCPMProductionMachines = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt>();
        }

        public SCPMProcessExt(SilkERPDataService.Containers.SCPM.SCPMProcess IP_obj_SCPMProcess)
            : base()
        {
            this._ProcessCode_UI64 = IP_obj_SCPMProcess._ProcessCode_UI64;
            this._SectionCode_UI64 = IP_obj_SCPMProcess._SectionCode_UI64;
            this._Name_STR = IP_obj_SCPMProcess._Name_STR;
            this._Status_ENM = IP_obj_SCPMProcess._Status_ENM;

            this._SCPMProductionMachines = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMMachineExt>();
        }
    }

    public class SCPMAvgProcessExt : SilkERPDataService.Containers.SCPM.SCPMProcess
    {
        /// <summary>
        /// Machines that belongs to this process
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgMachineThroughput> _SCPMAvgMachineThroughputList = null;

        public SCPMAvgProcessExt()
            : base()
        {
            this._SCPMAvgMachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgMachineThroughput>();
        }

        public SCPMAvgProcessExt(SilkERPDataService.Containers.SCPM.SCPMProcess IP_obj_SCPMProcess)
            : base()
        {
            this._ProcessCode_UI64 = IP_obj_SCPMProcess._ProcessCode_UI64;
            this._SectionCode_UI64 = IP_obj_SCPMProcess._SectionCode_UI64;
            this._Name_STR = IP_obj_SCPMProcess._Name_STR;
            this._Status_ENM = IP_obj_SCPMProcess._Status_ENM;

            this._SCPMAvgMachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SCPMAvgMachineThroughput>();
        }
    }

    public class SCPMMachineExt : SilkERPDataService.Containers.SCPM.SCPMMachine
    {
        /// <summary>
        /// Throughput of this Machine
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> _SCPMMachineThroughput = null;

        public SCPMMachineExt()
            : base()
        {
            this._SCPMMachineThroughput = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
        }

        public SCPMMachineExt(SilkERPDataService.Containers.SCPM.SCPMMachine IP_obj_Machine)
            : base()
        {
            this._MachineCode_UI64 = IP_obj_Machine._MachineCode_UI64;
            this._CompanyCode_UI64 = IP_obj_Machine._CompanyCode_UI64;
            this._ProcessCode_UI64 = IP_obj_Machine._ProcessCode_UI64;
            this._SectionCode_UI64 = IP_obj_Machine._MachineCode_UI64;
            this._MeasurementUnit_ENM = IP_obj_Machine._MeasurementUnit_ENM;
            this._CommittedThroughput_UI32 = IP_obj_Machine._CommittedThroughput_UI32;
            this._Name_STR = IP_obj_Machine._Name_STR;
            this._OperationalStatus = IP_obj_Machine._OperationalStatus;
            this._OptimumThroughput_UI32 = IP_obj_Machine._OptimumThroughput_UI32;
            this._Status = IP_obj_Machine._Status;
            this._TargetThroughput_UI32 = IP_obj_Machine._TargetThroughput_UI32;
            this._Throughput_UI32 = IP_obj_Machine._Throughput_UI32;

            this._SCPMMachineThroughput = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
        }
    }

    public class SCPMMachineSTRExt : SilkERPDataService.Containers.SCPM.SCPMMachineSTR
    {
        /// <summary>
        /// Throughput of this Machine
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> _SCPMMachineThroughput = null;

        public SCPMMachineSTRExt()
            : base()
        {
            this._SCPMMachineThroughput = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
        }

        public SCPMMachineSTRExt(SilkERPDataService.Containers.SCPM.SCPMMachineSTR IP_obj_MachineSTR)
            : base()
        {
            this._MachineCode_UI64 = IP_obj_MachineSTR._MachineCode_UI64;
            this._CompanyCode_UI64 = IP_obj_MachineSTR._CompanyCode_UI64;
            this._ProcessCode_UI64 = IP_obj_MachineSTR._ProcessCode_UI64;
            this._SectionCode_UI64 = IP_obj_MachineSTR._MachineCode_UI64;
            this._MeasurementUnit_ENM = IP_obj_MachineSTR._MeasurementUnit_ENM;
            this._MeasurementUnit_STR = IP_obj_MachineSTR._MeasurementUnit_ENM.ToString();
            this._CommittedThroughput_UI32 = IP_obj_MachineSTR._CommittedThroughput_UI32;
            this._Name_STR = IP_obj_MachineSTR._Name_STR;
            this._OperationalStatus_ENM = IP_obj_MachineSTR._OperationalStatus_ENM;
            this._OperationalStatus_STR = IP_obj_MachineSTR._OperationalStatus_STR;
            this._OptimumThroughput_UI32 = IP_obj_MachineSTR._OptimumThroughput_UI32;
            //this. = IP_obj_MachineSTR._Status;
            this._TargetThroughput_UI32 = IP_obj_MachineSTR._TargetThroughput_UI32;
            //this._Throughput_UI32 = IP_obj_MachineSTR._Throughput_UI32;

            this._SCPMMachineThroughput = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
        }
    }

    public class SCPMAvgMachineExt : SilkERPDataService.Containers.SCPM.SCPMMachine
    {
        public System.UInt32 _AvgTargetThroughput;
        public System.UInt32 _AvgThroughput;
        /// <summary>
        /// Throughput of this Machine
        /// </summary>
        
        public SCPMAvgMachineExt()
            : base()
        {
            
        }

        public SCPMAvgMachineExt(SilkERPDataService.Containers.SCPM.SCPMMachine IP_obj_Machine)
            : base()
        {
            this._MachineCode_UI64 = IP_obj_Machine._MachineCode_UI64;
            this._CompanyCode_UI64 = IP_obj_Machine._CompanyCode_UI64;
            this._ProcessCode_UI64 = IP_obj_Machine._ProcessCode_UI64;
            this._SectionCode_UI64 = IP_obj_Machine._MachineCode_UI64;
            this._MeasurementUnit_ENM = IP_obj_Machine._MeasurementUnit_ENM;
            this._CommittedThroughput_UI32 = IP_obj_Machine._CommittedThroughput_UI32;
            this._Name_STR = IP_obj_Machine._Name_STR;
            this._OperationalStatus = IP_obj_Machine._OperationalStatus;
            this._OptimumThroughput_UI32 = IP_obj_Machine._OptimumThroughput_UI32;
            this._Status = IP_obj_Machine._Status;
            //this._TargetThroughput_UI32 = IP_obj_Machine._TargetThroughput_UI32;
            //this._Throughput_UI32 = IP_obj_Machine._Throughput_UI32;

            //this._SCPMMachineThroughput = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
        }
    }

    public class SCPMAvgMachineThroughput : SilkERPDataService.Containers.SCPM.SCPMMachine
    {

        public System.Int64 _AvgTargetThroughput;
        public System.Int64 _AvgThroughput;

        /// <summary>
        /// In detail Machine throughput list from which the avg is calculated
        /// </summary>
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput> _SCMachineThroughputDetailList;
        /// <summary>
        /// Throughput of this Machine
        /// </summary>
        

        public SCPMAvgMachineThroughput()
            : base()
        {
            
        }

        public SCPMAvgMachineThroughput(SilkERPDataService.Containers.SCPM.SCPMMachine IP_obj_Machine)
            : base()
        {
            this._MachineCode_UI64 = IP_obj_Machine._MachineCode_UI64;
            this._CompanyCode_UI64 = IP_obj_Machine._CompanyCode_UI64;
            this._ProcessCode_UI64 = IP_obj_Machine._ProcessCode_UI64;
            this._SectionCode_UI64 = IP_obj_Machine._MachineCode_UI64;
            this._MeasurementUnit_ENM = IP_obj_Machine._MeasurementUnit_ENM;
            this._CommittedThroughput_UI32 = IP_obj_Machine._CommittedThroughput_UI32;
            this._Name_STR = IP_obj_Machine._Name_STR;
            this._OperationalStatus = IP_obj_Machine._OperationalStatus;
            this._OptimumThroughput_UI32 = IP_obj_Machine._OptimumThroughput_UI32;
            this._Status = IP_obj_Machine._Status;
            this._TargetThroughput_UI32 = IP_obj_Machine._TargetThroughput_UI32;
            this._Throughput_UI32 = IP_obj_Machine._Throughput_UI32;

            _SCMachineThroughputDetailList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SCMachineThroughput>();
        }
    }
}