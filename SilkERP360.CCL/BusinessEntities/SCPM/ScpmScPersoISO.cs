using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SC_PERSO_ISO", "SEQ_SCPM_SC_PERSO_ISO")]
    public class ScpmScPersoISO : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PERSO_ISO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScPersoCode;
        public System.UInt64 ScPersoCode
        {
            get { return m_ui64_ScPersoCode; }
            set { m_ui64_ScPersoCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MACHINE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_MachineCode;
        public System.UInt64 MachineCode
        {
            get { return m_ui64_MachineCode; }
            set { m_ui64_MachineCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BOX_SERIAL", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_BoxSerial;
        public System.UInt32 BoxSerial
        {
            get { return m_ui32_BoxSerial; }
            set { m_ui32_BoxSerial = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ProductCode;
        public System.UInt64 ProductCode
        {
            get { return m_ui64_ProductCode; }
            set { m_ui64_ProductCode = value; }
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

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_DATA_REPO_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScDataRepoCode;
        public System.UInt64 ScDataRepoCode
        {
            get { return m_ui64_ScDataRepoCode; }
            set { m_ui64_ScDataRepoCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("QUANTITY", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_Quantity;
        public System.UInt64 Quantity
        {
            get { return m_ui64_Quantity; }
            set { m_ui64_Quantity = value; }
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

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_CARDS_PACKAGED", typeof(CCL.Enums.YesNo), true, false)]
        protected CCL.Enums.YesNo m_enm_IsCardsPackaged;
        public CCL.Enums.YesNo IsCardsPackaged
        {
            get { return m_enm_IsCardsPackaged; }
            set { m_enm_IsCardsPackaged = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DELIVERY_STATUS", typeof(SilkERP360.CCL.Enums.SPM.DeliveryStatus), true, false)]
        protected SilkERP360.CCL.Enums.SPM.DeliveryStatus m_enm_DeliveryStatus;
        public SilkERP360.CCL.Enums.SPM.DeliveryStatus DeliveryStatus
        {
            get { return m_enm_DeliveryStatus; }
            set { m_enm_DeliveryStatus = value; }
        }
    }
}
