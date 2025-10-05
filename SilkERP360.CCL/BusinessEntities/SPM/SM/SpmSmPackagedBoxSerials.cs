using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM.SM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_SM_PACKAGED_BOX_SERIALS", "SEQ_SM_PACKAGED_BOX_SERIALS")]
    public class SpmSmPackagedBoxSerials : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PACKAGED_BOX_SERIAL_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPackagedBoxSerialCode;
        public System.UInt64 SmPackagedBoxSerialCode
        {
            get { return m_ui64_SmPackagedBoxSerialCode; }
            set { this.m_ui64_SmPackagedBoxSerialCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PACKAGED_BOX_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SmPackagedBoxCode;
        public System.UInt64 SmPackagedBoxCode
        {
            get { return m_ui64_SmPackagedBoxCode; }
            set { this.m_ui64_SmPackagedBoxCode = value; }
        }
    }
}
