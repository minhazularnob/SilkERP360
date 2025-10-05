using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_MACHINE","SEQ_SCPM_MACHINE")]
    public class SCPMMachine : SilkERP360.CCL.Validation.ValidationBase
    {
        #region ProtectedMembers
        [CCL.DatabaseMapping.DatabaseColumnMapping("MACHINE_CODE", typeof(System.UInt64), true,false)]
        protected System.UInt64 m_ui64_MachineCode;
        [CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false,false)]
        protected System.UInt64 m_ui64_CompanyCode;
        [CCL.DatabaseMapping.DatabaseColumnMapping("SECTION_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_SectionCode;
        [CCL.DatabaseMapping.DatabaseColumnMapping("NAME", typeof(System.String), false, false)]
        protected System.String m_str_Name;
        [CCL.DatabaseMapping.DatabaseColumnMapping("PROCESS_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ProcessCode;
        [CCL.DatabaseMapping.DatabaseColumnMapping("THROUGHPUT_HR", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Throughput_Hr;
        [CCL.DatabaseMapping.DatabaseColumnMapping("COMMITTED_THROUGHPUT", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_CommittedThroughput;
        [CCL.DatabaseMapping.DatabaseColumnMapping("OPTIMUM_THROUGHPUT", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_OptimumThroughput;
        [CCL.DatabaseMapping.DatabaseColumnMapping("TARGET_THROUGHPUT", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_TargetThroughput;
        [CCL.DatabaseMapping.DatabaseColumnMapping("MEASUREMENT_UNIT", typeof(SilkERP360.CCL.Enums.SCPM.MachineOutputMeasurementUnit), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.MachineOutputMeasurementUnit m_enm_MeasurementUnit;
        [CCL.DatabaseMapping.DatabaseColumnMapping("OPERATIONAL_STATUS", typeof(SilkERP360.CCL.Enums.SCPM.MachineOperationalStatus), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.MachineOperationalStatus m_enm_OperationalStatus;

        
        [CCL.DatabaseMapping.DatabaseColumnMapping("SHORT_NAME", typeof(System.String), false, false)]
        protected System.String m_str_ShortName;
        [CCL.DatabaseMapping.DatabaseColumnMapping("IDENTIFIER", typeof(System.String), false, false)]
        protected System.UInt32 m_ui32_Identifier;
        [CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.Status), false, false)]
        protected SilkERP360.CCL.Enums.Status m_enm_Status;
        #endregion


        public System.UInt64 SectionCode
        {
            get { return this.m_ui64_SectionCode; }
            set { this.m_ui64_SectionCode = value; }
        }

        /// <summary>
        /// Four Digit Unique Number. To be Used to Generate BatchNo of Production
        /// </summary>
        public System.UInt32 Identifier
        {
            
            get { return m_ui32_Identifier; }
            set { m_ui32_Identifier = value; }
        }
        public System.UInt64 MachineCode
        {
            
            get { return this.m_ui64_MachineCode; }
            set { this.m_ui64_MachineCode = value; }
        }
        public System.UInt64 CompanyCode
        {
            
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }
        public System.String Name
        {
            
            get { return this.m_str_Name; }
            set { this.m_str_Name = value; }
        }

        public System.String ShortName
        {
            
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }
        public System.UInt64 ProcessCode
        {
            
            get { return this.m_ui64_ProcessCode; }
            set { this.m_ui64_ProcessCode = value; }
        }

        public System.UInt32 Throughput_Hr
        {
            
            get { return this.m_ui32_Throughput_Hr; }
            set { this.m_ui32_Throughput_Hr = value; }
        }
        public System.UInt32 CommittedThroughput
        {

            get { return this.m_ui32_CommittedThroughput; }
            set { this.m_ui32_CommittedThroughput = value; }
        }
        public System.UInt32 OptimumThroughput
        {

            get { return this.m_ui32_OptimumThroughput; }
            set { this.m_ui32_OptimumThroughput = value; }
        }
        public SilkERP360.CCL.Enums.SCPM.MachineOutputMeasurementUnit MeasurementUnit
        {
            
            get { return this.m_enm_MeasurementUnit; }
            set { this.m_enm_MeasurementUnit = value; }
        }
        public SilkERP360.CCL.Enums.Status Status
        {
            
            get { return this.m_enm_Status; }
            set { this.m_enm_Status = value; }
        }

        public SilkERP360.CCL.Enums.SCPM.MachineOperationalStatus OperationalStatus
        {
            get { return this.m_enm_OperationalStatus; }
            set { this.m_enm_OperationalStatus = value; }
        }
    }
}
