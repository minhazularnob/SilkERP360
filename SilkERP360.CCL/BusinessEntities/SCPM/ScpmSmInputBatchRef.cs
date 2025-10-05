using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class ScpmSmInputBatchRef : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IBF_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_IBFCode;
        public System.UInt64 IBFCode
        {
            get { return m_ui64_IBFCode; }
            set { m_ui64_IBFCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BatchCode;
        public System.UInt64 BatchCode
        {
            get { return this.m_ui64_BatchCode; }
            set { this.m_ui64_BatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REF_BATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_RefBatchCode;
        public System.UInt64 RefBatchCode
        {
            get { return this.m_ui64_RefBatchCode; }
            set { this.m_ui64_RefBatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_Quantity;
        public System.UInt32 Quantity
        {
            get { return this.m_ui32_Quantity; }
            set { this.m_ui32_Quantity = value; }
        }
    }
}
