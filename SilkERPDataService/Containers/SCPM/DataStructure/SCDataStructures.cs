using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.Containers.SCPM.DataStructure.SC
{
    /// <summary>
    /// Consolidated Machine Throughput By Day Range
    /// </summary>
    public class DayRangeMachineThroughput : SilkERPDataService.Containers.SCPM.SC.SCMachine
    {
        public System.DateTime _StartDate;
        public System.DateTime _EndDate;
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.DaywiseMachineThroughput>
            _DaywiseThroughputList;
        public DayRangeMachineThroughput(SilkERPDataService.Containers.SCPM.SC.SCMachine IP_obj_SCMachine,System.DateTime IP_dt_StartDate,System.DateTime IP_dt_EndDate):base()
        {
            this._DaywiseThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.DaywiseMachineThroughput>();
            this._StartDate = IP_dt_StartDate;
            this._EndDate = IP_dt_EndDate;
            this.m__MachineCode = IP_obj_SCMachine._MachineCode;
            this.m__ProcessCode = IP_obj_SCMachine._ProcessCode;
            this.m__SectionCode = IP_obj_SCMachine._SectionCode;
            this.m__Name = IP_obj_SCMachine._Name;
            this.m__ShortName = IP_obj_SCMachine._ShortName;
            this.m__CompanyCode = IP_obj_SCMachine._CompanyCode;

            this.m__MeasurementUnit = IP_obj_SCMachine._MeasurementUnit;

            this.m__CommittedThroughput = IP_obj_SCMachine._CommittedThroughput;
            this.m__OptimumThroughput = IP_obj_SCMachine._OptimumThroughput;
            this.m__TargetThroughput = IP_obj_SCMachine._TargetThroughput;
            this.m__Throughput = IP_obj_SCMachine._Throughput;
            /// If Machine is ON/OFF/ServiceIntervention
            this.m__OperationalStatus = IP_obj_SCMachine._OperationalStatus;
            //Inactive Sections will not come in the result set
            this.m__Status = IP_obj_SCMachine._Status;
            this.m__AdditionalData = IP_obj_SCMachine._AdditionalData;
            
        }
    }
    /// <summary>
    /// Contains Daywise Machine Throughput.
    /// The Combined Throughput of a day both DayShift and NightShift
    /// </summary>
    public class DaywiseMachineThroughput
    {
        public System.UInt64 _MachineCode;
        public System.DateTime _Date;
        public System.UInt32 _TargetThroughput;
        public System.Int32 _Throughput;
        public System.UInt32 _Wastage;
        public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData = new Dictionary<string, object>();
    }

    /// <summary>
    /// Throughput of all Processes that belongs to a section
    /// </summary>
    public class SectionwiseThroughput : SilkERPDataService.Containers.SCPM.SC.SCSection
    {
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput> _ProcesswiseMachineThroughputList;
        public SectionwiseThroughput(SilkERPDataService.Containers.SCPM.SC.SCSection IP_obj_SCSection)
        {
            this._SectionCode = IP_obj_SCSection._SectionCode;
            this._CompanyCode = IP_obj_SCSection._CompanyCode;
            this._Name = IP_obj_SCSection._Name;
            this._Status = IP_obj_SCSection._Status;
            this._AdditionalData = IP_obj_SCSection._AdditionalData;
            this._ProcesswiseMachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.ProcesswiseMachineThroughput>();
        }
    }

    /// <summary>
    /// Lists Throughput of all machines that belongs
    /// to the process
    /// </summary>
    public class ProcesswiseMachineThroughput : SilkERPDataService.Containers.SCPM.SC.SCProcess
    {
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput> _MachinewiseThroughputList;
        public ProcesswiseMachineThroughput(SilkERPDataService.Containers.SCPM.SC.SCProcess IP_obj_SCProcess)
        {
            this.m__ProcessCode = IP_obj_SCProcess._ProcessCode;
            this.m__SectionCode = IP_obj_SCProcess._SectionCode;
            this.m__Name = IP_obj_SCProcess._Name;
            this.m__Status = IP_obj_SCProcess._Status;
            this.m__AdditionalData = IP_obj_SCProcess._AdditionalData;

            this._MachinewiseThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.DataStructure.SC.MachinewiseThroughput>();
        }
    }

    public class MachinewiseThroughput : SilkERPDataService.Containers.SCPM.SC.SCMachine
    {
        public System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput> _MachineThroughputList;
        public MachinewiseThroughput(SilkERPDataService.Containers.SCPM.SC.SCMachine IP_obj_SCMachine)
        {
            this.m__MachineCode = IP_obj_SCMachine._MachineCode;
            this.m__ProcessCode = IP_obj_SCMachine._ProcessCode;
            this.m__SectionCode = IP_obj_SCMachine._SectionCode;
            this.m__Name = IP_obj_SCMachine._Name;
            this.m__ShortName = IP_obj_SCMachine._ShortName;
            this.m__CompanyCode = IP_obj_SCMachine._CompanyCode;

            this.m__MeasurementUnit = IP_obj_SCMachine._MeasurementUnit;

            this.m__CommittedThroughput = IP_obj_SCMachine._CommittedThroughput;
            this.m__OptimumThroughput = IP_obj_SCMachine._OptimumThroughput;
            this.m__TargetThroughput = IP_obj_SCMachine._TargetThroughput;
            this.m__Throughput = IP_obj_SCMachine._Throughput;
            /// If Machine is ON/OFF/ServiceIntervention
            this.m__OperationalStatus = IP_obj_SCMachine._OperationalStatus;
            //Inactive Sections will not come in the result set
            this.m__Status = IP_obj_SCMachine._Status;
            this.m__AdditionalData = IP_obj_SCMachine._AdditionalData;
            this._MachineThroughputList = new System.Collections.Generic.List<SilkERPDataService.Containers.SCPM.SC.SCMachineThroughput>();
        }
    }

    public class SectionThroughputByDateRange
    {
    }
}