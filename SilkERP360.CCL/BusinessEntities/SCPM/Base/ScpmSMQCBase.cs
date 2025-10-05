using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM.Base
{
    public abstract class ScpmSMQCBase : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_QC_MASTER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_SMQCMasterCode;
        public System.UInt64 SMQCMasterCode
        {
            get { return m_ui64_SMQCMasterCode; }
            set { m_ui64_SMQCMasterCode = value; }
        }

        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SEQUENCE", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Sequence;
        /// <summary>
        /// Card/Sheet Sequence
        /// </summary>
        public System.UInt32 Sequence
        {
            get { return m_ui32_Sequence; }
            set { m_ui32_Sequence = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("TEST_DATE_TIME", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_TestDateTime;
        public System.DateTime TestDateTime
        {
            get { return m_dt_TestDateTime; }
            set { m_dt_TestDateTime = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(SilkERP360.CCL.Enums.SCPM.QCTestResult), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.QCTestResult m_enm_Status;
        public SilkERP360.CCL.Enums.SCPM.QCTestResult Status
        {
            get { return m_enm_Status; }
            set { m_enm_Status = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("POSSIBLE_GLITCH", typeof(System.String), false, false)]
        protected System.String m_str_PossibleGlitch;
        public System.String PossibleGlitch
        {
            get { return m_str_PossibleGlitch; }
            set { m_str_PossibleGlitch = value; }
        }
    }
}
