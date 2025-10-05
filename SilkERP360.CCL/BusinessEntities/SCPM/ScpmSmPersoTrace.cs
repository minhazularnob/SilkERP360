using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SM_PERSO_TRACE", "SEQ_SCPM_SM_PERSO_TRACE")]
    public class ScpmSmPersoTrace : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SM_PERSO_TRACE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_PersoTraceCode;
        public System.UInt64 PersoTraceCode
        {
            get { return this.m_ui64_PersoTraceCode; }
            set { this.m_ui64_PersoTraceCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BatchCode;
        public System.UInt64 BatchCode
        {
            get { return this.m_ui64_BatchCode; }
            set { this.m_ui64_BatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("START_ICCID", typeof(System.Numerics.BigInteger), false, false)]
        protected System.Numerics.BigInteger m_bi_StartICCID;
        public System.Numerics.BigInteger StartICCID
        {
            get { return this.m_bi_StartICCID; }
            set { this.m_bi_StartICCID = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("END_ICCID", typeof(System.Numerics.BigInteger), false, false)]
        protected System.Numerics.BigInteger m_bi_EndICCID;
        public System.Numerics.BigInteger EndICCID
        {
            get { return this.m_bi_EndICCID; }
            set { this.m_bi_EndICCID = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("START_SL", typeof(System.Numerics.BigInteger), false, false)]
        protected System.Numerics.BigInteger m_bi_StartSL;
        public System.Numerics.BigInteger StartSerial
        {
            get { return this.m_bi_StartSL; }
            set { this.m_bi_StartSL = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("END_SL", typeof(System.Numerics.BigInteger), false, false)]
        protected System.Numerics.BigInteger m_bi_EndSL;
        public System.Numerics.BigInteger EndSerial
        {
            get { return this.m_bi_EndSL; }
            set { this.m_bi_EndSL = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("START_BARCODE", typeof(System.String), false, false)]
        protected System.String m_str_StartBarcode;
        public System.String StartBarcode
        {
            get { return this.m_str_StartBarcode; }
            set { this.m_str_StartBarcode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("END_BARCODE", typeof(System.String), false, false)]
        protected System.String m_str_EndBarcode;
        public System.String EndBarcode
        {
            get { return this.m_str_EndBarcode; }
            set { this.m_str_EndBarcode = value; }
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
