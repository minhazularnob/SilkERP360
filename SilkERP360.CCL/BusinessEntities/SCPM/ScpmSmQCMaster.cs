using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SM_QC_MASTER","SEQ_SM_QC_MASTER")]
    public class ScpmSmQCMaster : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_QC_MASTER_CODE",typeof(System.UInt64),true,false)]
        protected System.UInt64 m_ui64_SMQCMasterCode;
        public System.UInt64 SMQCMasterCode
        {
            get { return this.m_ui64_SMQCMasterCode; }
            set { this.m_ui64_SMQCMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BatchCode;
        public System.UInt64 BatchCode
        {
            get { return this.m_ui64_BatchCode; }
            set { this.m_ui64_BatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QC_ENGINEER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_QCEngineerCode;
        public System.UInt64 QCEngineerCode
        {
            get { return this.m_ui64_QCEngineerCode; }
            set { this.m_ui64_QCEngineerCode = value; }
        }

        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_QC_TEST_TYPE", typeof(SilkERP360.CCL.Enums.SCPM.SMQCTestTypes), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.SMQCTestTypes m_enm_SMQCTestType;
        public SilkERP360.CCL.Enums.SCPM.SMQCTestTypes SMQCTestType
        {
            get { return this.m_enm_SMQCTestType; }
            set { this.m_enm_SMQCTestType = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QC_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_QCDate;
        public System.DateTime QCDate
        {
            get { return this.m_dt_QCDate; }
            set { this.m_dt_QCDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.SCPM.SMQCMasterStatus), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.SMQCMasterStatus m_enm_Status;
        public SilkERP360.CCL.Enums.SCPM.SMQCMasterStatus Status
        {
            get { return this.m_enm_Status; }
            set { this.m_enm_Status = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QC_ENGINEER_CODE", typeof(System.UInt64), false, false)]
        //protected System.UInt64 m_ui64_SMQCEngineerCode;
        //public System.UInt64 SMQCEngineerCode
        //{
        //    get { return m_ui64_SMQCEngineerCode; }
        //    set { m_ui64_SMQCEngineerCode = value; }
        //}
        
        /// <summary>
        /// This field will contain List of any one type of QC test at any point of time.
        /// This field contains System.Object which will be converted to corresponding
        /// QCTest based on SMQCTestTypes field
        /// Key For The Dictionary Objects
        /// ["SM_PEEL_OFF"] = <PEEL OFF TEST OBJECTS>
        /// </summary>
        //protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Base.ScpmSMQCBase> m_objLst_ScpmSmQCTests;
        //public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.Base.ScpmSMQCBase> ScpmSmQCTestsList
        //{
        //    get { return this.m_objLst_ScpmSmQCTests; }
        //    set { this.m_objLst_ScpmSmQCTests = value; }
        //}

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> m_objLst_PeelOffTests;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.SCPM.ScpmSmPeelOffQC> PeelOffTests
        {
            get { return this.m_objLst_PeelOffTests; }
            set { this.m_objLst_PeelOffTests = value; }
        }
    }
}
