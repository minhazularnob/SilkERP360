using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    /// <summary>
    /// Inherits Following Field from ScpmSMQCBase abstract class:
    /// 1.SMQCMasterCode
    /// 2.Sequence (Card/Sheet Sequence)
    /// 3.DateTime
    /// 4.Status
    /// </summary>
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SM_PEEL_OFF_QC", "SEQ_SM_PEEL_OFF_QC")]
    public class ScpmSmPeelOffQC : SilkERP360.CCL.BusinessEntities.SCPM.Base.ScpmSMQCBase
    {
        public const System.UInt16 S_TEST_PERCENTAGE = 1;
        public const System.Double S_VALUE_RANGE_FROM = 30;
        public const System.Double S_VALUE_RANGE_TO = 60;

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PEEL_OFF_CODE",typeof(System.UInt64),true,false)]
        protected System.UInt64 m_ui64_SMPeelOffCode;
        public System.UInt64 SMPeelOffCode
        {
            get { return m_ui64_SMPeelOffCode; }
            set { m_ui64_SMPeelOffCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PEEL_OFF_PERCENTAGE", typeof(System.Double), false, false)]
        protected System.Double m_dbl_PeelOffPercentage;
        public System.Double PeelOffPercentage
        {
            get { return m_dbl_PeelOffPercentage; }
            set { m_dbl_PeelOffPercentage = value; }
        }

    }
}
