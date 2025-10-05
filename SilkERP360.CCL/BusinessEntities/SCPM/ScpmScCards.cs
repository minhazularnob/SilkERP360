using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
     [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_SC_CARDS", "SEQ_SCPM_SC_CARDS")]
    public class ScpmScCards : SilkERP360.CCL.Validation.ValidationBase
    {
         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_CARD_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_ScCardCode; 
         public System.UInt64 ScCardCode
         {
             get { return m_ui64_ScCardCode; }
             set { m_ui64_ScCardCode = value; }
         }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_CODE", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_ProductCode;
         public System.UInt64 ProductCode
         {
             get { return m_ui64_ProductCode; }
             set { m_ui64_ProductCode = value; }
         }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DENOMINATION", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_Denomination;
         public System.UInt64 Denomination
         {
             get { return m_ui64_Denomination; }
             set { m_ui64_Denomination = value; }
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

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CARD_SERIAL", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_CardSerial;
         public System.UInt64 CardSerial
         {
             get { return m_ui64_CardSerial; }
             set { m_ui64_CardSerial = value; }
         }

         //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PERSO_COMPLETE", typeof(CCL.Enums.YesNo), true, false)]
         //protected CCL.Enums.YesNo m_enm_IsPersoComplete;
         //public CCL.Enums.YesNo IsPersoComplete
         //{
         //    get { return m_enm_IsPersoComplete; }
         //    set { m_enm_IsPersoComplete = value; }
         //}

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PERSO_ISO_CODE", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_ScPersoCode;
         public System.UInt64 ScPersoCode
         {
             get { return m_ui64_ScPersoCode; }
             set { m_ui64_ScPersoCode = value; }
         }
         

         //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PACKING_COMPLETE", typeof(CCL.Enums.YesNo), true, false)]
         //protected CCL.Enums.YesNo m_enm_IsPackingComplete;
         //public CCL.Enums.YesNo IsPackingComplete
         //{
         //    get { return m_enm_IsPackingComplete; }
         //    set { m_enm_IsPackingComplete = value; }
         //}


         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PKGED_BOX_CODE", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_ScPackagedBoxCode;
         public System.UInt64 ScPackagedBoxCode
         {
             get { return m_ui64_ScPackagedBoxCode; }
             set { m_ui64_ScPackagedBoxCode = value; }
         }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_PACKING_ISO_CODE", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_ScPackingISOCode;
         public System.UInt64 ScPackingISOCode
         {
             get { return m_ui64_ScPackingISOCode; }
             set { m_ui64_ScPackingISOCode = value; }
         }

         //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_DELIVERED", typeof(CCL.Enums.YesNo), true, false)]
         //protected CCL.Enums.YesNo m_enm_IsDelivered;
         //public CCL.Enums.YesNo IsDelivered
         //{
         //    get { return m_enm_IsDelivered; }
         //    set { m_enm_IsDelivered = value; }
         //}

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SC_DELIVERY_ISO_CODE", typeof(System.UInt64), true, false)]
         protected System.UInt64 m_ui64_ScDeliveryISOCode;
         public System.UInt64 ScDeliveryISOCode
         {
             get { return m_ui64_ScDeliveryISOCode; }
             set { m_ui64_ScDeliveryISOCode = value; }
         }

         [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CARD_STATUS", typeof(CCL.Enums.SPM.SCCardStatus), true, false)]
         protected CCL.Enums.SPM.SCCardStatus m_enm_CardStatus;
         public CCL.Enums.SPM.SCCardStatus CardStatus
         {
             get { return m_enm_CardStatus; }
             set { m_enm_CardStatus = value; }
         }
    }
}
