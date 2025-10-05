using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SC_DATA_REPOSITORY", "SEQ_SCPM_SC_DATA_REPO")]
    public class ScpmScDataRepository : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_DATA_REPO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScDataRepoCode;
        public System.UInt64 ScDataRepoCode
        {
            get { return m_ui64_ScDataRepoCode; }
            set { m_ui64_ScDataRepoCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SCPM_PO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScpmPOCode;
        public System.UInt64 ScpmPOCode
        {
            get { return m_ui64_ScpmPOCode; }
            set { m_ui64_ScpmPOCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SCPM_PO_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScpmPOItemCode;
        public System.UInt64 ScpmPOItemCode
        {
            get { return m_ui64_ScpmPOItemCode; }
            set { m_ui64_ScpmPOItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJOCode;
        public System.UInt64 ScJOCode
        {
            get { return m_ui64_ScJOCode; }
            set { m_ui64_ScJOCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_JO_ITEM_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScJOItemCode;
        public System.UInt64 ScJOItemCode
        {
            get { return m_ui64_ScJOItemCode; }
            set { m_ui64_ScJOItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_NO", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_BatchNo;
        public System.UInt32 BatchNo
        {
            get { return m_ui32_BatchNo; }
            set { m_ui32_BatchNo = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_NAME", typeof(System.String), true, false)]
        protected System.String m_str_BatchName;
        public System.String BatchName
        {
            get { return m_str_BatchName; }
            set { m_str_BatchName = value; }
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

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Quantity;
        public System.UInt64 Quantity
        {
            get { return m_ui64_Quantity; }
            set { m_ui64_Quantity = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LAST_PERSO_SERIAL", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_LastPersoSerial;
        public System.UInt64 LastPersoSerial
        {
            get { return m_ui64_LastPersoSerial; }
            set { m_ui64_LastPersoSerial = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NEXT_PERSO_SERIAL", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_NextPersoSerial;
        public System.UInt64 NextPersoSerial
        {
            get { return m_ui64_NextPersoSerial; }
            set { m_ui64_NextPersoSerial = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY_PERSONALIZED", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_QuantityPersonalized;
        public System.UInt64 QuantityPersonalized
        {
            get { return m_ui64_QuantityPersonalized; }
            set { m_ui64_QuantityPersonalized = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PERSO_COMPLETED", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_ui64_IsPersoCompleted;
        public CCL.Enums.YesNo IsPersoCompleted
        {
            get { return m_ui64_IsPersoCompleted; }
            set { m_ui64_IsPersoCompleted = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PACKAGED_BOX_SL_START", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui64_PackagedBoxSerialStart;
        public System.UInt32 PackagedBoxSerialStart
        {
            get { return m_ui64_PackagedBoxSerialStart; }
            set { m_ui64_PackagedBoxSerialStart = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PACKAGED_BOX_SL_END", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui64_PackagedBoxSerialEnd;
        public System.UInt32 PackagedBoxSerialEnd
        {
            get { return m_ui64_PackagedBoxSerialEnd; }
            set { m_ui64_PackagedBoxSerialEnd = value; }
        }
    }
}
