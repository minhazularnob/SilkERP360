using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SC_PERSO_ISO_DATA", "SEQ_SCPM_SC_PERSO_DATA")]
    public class ScpmScPersoISOData : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PERSO_ISO_DATA_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPersoISODataCode;
        public System.UInt64 ScPersoISODataCode
        {
            get { return m_ui64_ScPersoISODataCode; }
            set { m_ui64_ScPersoISODataCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PERSO_ISO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPersoCode;
        public System.UInt64 ScPersoCode
        {
            get { return m_ui64_ScPersoCode; }
            set { m_ui64_ScPersoCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt32), true, false)]
        protected System.UInt64 m_ui32_Quantity;
        public System.UInt64 Quantity
        {
            get { return m_ui32_Quantity; }
            set { m_ui32_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_DATA_REPO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScDataRepoCode;
        public System.UInt64 ScDataRepoCode
        {
            get { return m_ui64_ScDataRepoCode; }
            set { m_ui64_ScDataRepoCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("START_SERIAL", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_StartSerial;
        public System.UInt64 StartSerial
        {
            get { return m_ui64_StartSerial; }
            set { m_ui64_StartSerial = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("END_SERIAL", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EndSerial;
        public System.UInt64 EndSerial
        {
            get { return m_ui64_EndSerial; }
            set { m_ui64_EndSerial = value; }
        }
    }
}
