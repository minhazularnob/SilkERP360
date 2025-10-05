using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERPDataService.Containers.SCPM.SC
{

    public class SCSection
    {
        protected System.UInt64 m__SectionCode;
        public System.UInt64 _SectionCode
        {
            get { return m__SectionCode; }
            set { m__SectionCode = value; }
        }

        protected System.UInt64 m__CompanyCode;
        public System.UInt64 _CompanyCode
        {
            get { return m__CompanyCode; }
            set { m__CompanyCode = value; }
        }

        protected System.String m__Name;
        public System.String _Name
        {
            get { return m__Name; }
            set { m__Name = value; }
        }

        protected SilkERP360.CCL.Enums.Status m__Status;
        public SilkERP360.CCL.Enums.Status _Status
        {
            get { return m__Status; }
            set { m__Status = value; }
        }

         /// <summary>
        /// Will contain data to be used by Clients or Charts
        /// </summary>
        protected System.Collections.Generic.Dictionary<System.String, System.Object> m__AdditionalData;
        public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData
        {
            get { return m__AdditionalData; }
            set { m__AdditionalData = value; }
        }

        public SCSection()
        {
            this.m__AdditionalData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
    }

    public class SCProcess
    {
        protected System.UInt64 m__ProcessCode;
        public System.UInt64 _ProcessCode
        {
            get { return m__ProcessCode; }
            set { m__ProcessCode = value; }
        }
        protected System.String m__Name;
        public System.String _Name
        {
            get { return m__Name; }
            set { m__Name = value; }
        }

        protected System.UInt64 m__SectionCode;
        public System.UInt64 _SectionCode
        {
            get { return m__SectionCode; }
            set { m__SectionCode = value; }
        }
  
        protected SilkERP360.CCL.Enums.Status m__Status;
        public SilkERP360.CCL.Enums.Status _Status
        {
            get { return m__Status; }
            set { m__Status = value; }
        }

         /// <summary>
        /// Will contain data to be used by Clients or Charts
        /// </summary>
        protected System.Collections.Generic.Dictionary<System.String, System.Object> m__AdditionalData;
        public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData
        {
            get { return m__AdditionalData; }
            set { m__AdditionalData = value; }
        }

        public SCProcess()
        {
            this.m__AdditionalData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        
    }

    public class SCMachine
    {
        protected System.UInt64 m__MachineCode;
        public System.UInt64 _MachineCode
        {
            get { return m__MachineCode; }
            set { m__MachineCode = value; }
        }

        protected System.UInt64 m__CompanyCode;
        public System.UInt64 _CompanyCode
        {
            get { return m__CompanyCode; }
            set { m__CompanyCode = value; }
        }

        protected System.String m__Name;
        public System.String _Name
        {
            get { return m__Name; }
            set { m__Name = value; }
        }

        protected System.String m__ShortName;
        public System.String _ShortName
        {
            get { return m__ShortName; }
            set { m__ShortName = value; }
        }

        protected System.UInt64 m__ProcessCode;
        public System.UInt64 _ProcessCode
        {
            get { return m__ProcessCode; }
            set { m__ProcessCode = value; }
        }

        protected SilkERPDataService.Containers.SCPM.MachineMeasurementUnit m__MeasurementUnit;
        public SilkERPDataService.Containers.SCPM.MachineMeasurementUnit _MeasurementUnit
        {
            get { return m__MeasurementUnit; }
            set { m__MeasurementUnit = value; }
        }

        protected System.UInt64 m__SectionCode;
        public System.UInt64 _SectionCode
        {
            get { return m__SectionCode; }
            set { m__SectionCode = value; }
        }

        protected System.UInt32 m__CommittedThroughput;
        public System.UInt32 _CommittedThroughput
        {
            get { return m__CommittedThroughput; }
            set { m__CommittedThroughput = value; }
        }

        protected System.UInt32 m__OptimumThroughput;
        public System.UInt32 _OptimumThroughput
        {
            get { return m__OptimumThroughput; }
            set { m__OptimumThroughput = value; }
        }

        protected System.UInt32 m__TargetThroughput;
        public System.UInt32 _TargetThroughput
        {
            get { return m__TargetThroughput; }
            set { m__TargetThroughput = value; }
        }
        /// <summary>
        /// Current Throughput
        /// </summary>
        protected System.UInt32 m__Throughput;
        public System.UInt32 _Throughput
        {
            get { return m__Throughput; }
            set { m__Throughput = value; }
        }
        /// <summary>
        /// If Machine is ON/OFF/ServiceIntervention
        /// </summary>
        protected SilkERPDataService.Containers.SCPM.MachineOperationalStatus m__OperationalStatus;
        public SilkERPDataService.Containers.SCPM.MachineOperationalStatus _OperationalStatus
        {
            get { return m__OperationalStatus; }
            set { m__OperationalStatus = value; }
        }

        /// <summary>
        /// If Machine is active/InActive
        /// </summary>
        protected SilkERP360.CCL.Enums.Status m__Status;
        public SilkERP360.CCL.Enums.Status _Status
        {
            get { return m__Status; }
            set { m__Status = value; }
        }

        /// <summary>
        /// Will contain data to be used by Clients or Charts
        /// </summary>
        protected System.Collections.Generic.Dictionary<System.String, System.Object> m__AdditionalData;
        public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData
        {
            get { return m__AdditionalData; }
            set { m__AdditionalData = value; }
        }

        public SCMachine()
        {
            this.m__AdditionalData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
    }

    public class SCMachineThroughput
    {
        protected System.UInt64 m__ThroughputCode;
        public System.UInt64 _ThroughputCode
        {
            get { return m__ThroughputCode; }
            set { m__ThroughputCode = value; }
        }

        protected System.UInt64 m__MachineCode;
        public System.UInt64 _MachineCode
        {
            get { return m__MachineCode; }
            set { m__MachineCode = value; }
        }

        protected System.UInt64 m__ShiftCode;
        public System.UInt64 _ShiftCode
        {
            get { return m__ShiftCode; }
            set { m__ShiftCode = value; }
        }

        protected System.UInt32 m__TargetThroughput;
        public System.UInt32 _TargetThroughput
        {
            get { return m__TargetThroughput; }
            set { m__TargetThroughput = value; }
        }

        protected System.Int64 m__Throughput;
        public System.Int64 _Throughput
        {
            get { return m__Throughput; }
            set { m__Throughput = value; }
        }

        protected System.UInt32 m__Wastage;
        public System.UInt32 _Wastage
        {
            get { return m__Wastage; }
            set { m__Wastage = value; }
        }

        protected System.DateTime m__ThroughputDateTime;
        public System.DateTime _ThroughputDateTime
        {
            get { return m__ThroughputDateTime; }
            set { m__ThroughputDateTime = value; }
        }

        protected System.UInt64 m__EntryEmployeeCode;
        public System.UInt64 _EntryEmployeeCode
        {
            get { return m__EntryEmployeeCode; }
            set { m__EntryEmployeeCode = value; }
        }

        protected System.String m__Remarks;
        public System.String _Remarks
        {
            get { return m__Remarks; }
            set { m__Remarks = value; }
        }

        protected System.DateTime m__EntryDateTime;
        public System.DateTime _EntryDateTime
        {
            get { return m__EntryDateTime; }
            set { m__EntryDateTime = value; }
        }

        protected SilkERPDataService.Containers.SCPM.DailySCPMMachineStatus m__DailySCPMMachineStatus;
        public SilkERPDataService.Containers.SCPM.DailySCPMMachineStatus _DailySCPMMachineStatus
        {
            get { return m__DailySCPMMachineStatus; }
            set { m__DailySCPMMachineStatus = value; }
        }

        /// <summary>
        /// Will contain data to be used by Clients or Charts
        /// </summary>
        protected System.Collections.Generic.Dictionary<System.String, System.Object> m__AdditionalData;
        public System.Collections.Generic.Dictionary<System.String, System.Object> _AdditionalData
        {
            get { return m__AdditionalData; }
            set { m__AdditionalData = value; }
        }

        public SCMachineThroughput()
        {
            this.m__AdditionalData = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
    }
}