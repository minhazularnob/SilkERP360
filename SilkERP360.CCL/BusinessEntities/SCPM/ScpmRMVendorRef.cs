using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SCPM_RM_VENDOR_REF", "SEQ_SCPM_RM_VENDOR_REF")]
    public class ScpmRMVendorRef : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("RM_VENDOR_REF_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_RMVendorRefCode;
        public System.UInt64 RMVendorRefCode
        {
            get { return m_ui64_RMVendorRefCode; }
            set { m_ui64_RMVendorRefCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BatchCode;
        public System.UInt64 BatchCode
        {
            get { return this.m_ui64_BatchCode; }
            set { this.m_ui64_BatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("VENDOR_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_VendorCode;
        public System.UInt64 VendorCode
        {
            get { return m_ui64_VendorCode; }
            set { m_ui64_VendorCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("RAW_MATERIAL_TYPE", typeof(SilkERP360.CCL.Enums.SCPM.SCPMRawMaterialType), false, false)]
        protected SilkERP360.CCL.Enums.SCPM.SCPMRawMaterialType m_enm_RawMaterialType;
        public SilkERP360.CCL.Enums.SCPM.SCPMRawMaterialType RawMaterialType
        {
            get { return this.m_enm_RawMaterialType; }
            set { this.m_enm_RawMaterialType = value; }
        }
    }
}
