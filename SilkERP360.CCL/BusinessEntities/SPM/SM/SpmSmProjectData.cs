using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SM_PROJECT_DATA", "SEQ_SPM_SM_PROJECT_DATA")]
    public class SpmSmProjectData : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PROJECT_DATA_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmProjectDateCode;
        public System.UInt64 SmProjectDateCode
        {
            get { return m_ui64_SmProjectDateCode; }
            set { this.m_ui64_SmProjectDateCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PROJECT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmProjectCode;
        public System.UInt64 SmProjectCode
        {
            get { return m_ui64_SmProjectCode; }
            set { this.m_ui64_SmProjectCode = value; }
        }
    }
}
