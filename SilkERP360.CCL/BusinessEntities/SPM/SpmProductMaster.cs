using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SPM
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SPM_PRODUCT_MASTER", "SEQ_SPM_PRODUCT_MASTER")]
    public class SpmProductMaster : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SPM_PRODUCT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_SpmProductCode;
        public System.UInt64 SpmProductCode
        {
            get { return m_ui64_SpmProductCode; }
            set { this.m_ui64_SpmProductCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CUSTOMER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CustomerCode;
        public System.UInt64 CustomerCode
        {
            get { return m_ui64_CustomerCode; }
            set { this.m_ui64_CustomerCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_NAME", typeof(System.String), true, false)]
        protected System.String m_str_ProductName;
        public System.String ProductName
        {
            get { return m_str_ProductName; }
            set { this.m_str_ProductName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DESCRIPTION", typeof(System.String), true, false)]
        protected System.String m_str_Description;
        public System.String Description
        {
            get { return m_str_Description; }
            set { this.m_str_Description = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_TYPE", typeof(SilkERP360.CCL.Enums.SPM.SPMProductType), true, false)]
        protected SilkERP360.CCL.Enums.SPM.SPMProductType m_enm_ProductType;
        public SilkERP360.CCL.Enums.SPM.SPMProductType ProductType
        {
            get { return m_enm_ProductType; }
            set { this.m_enm_ProductType = value; }
        }

       

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), true, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsActive;
        public SilkERP360.CCL.Enums.YesNo IsActive
        {
            get { return m_enm_IsActive; }
            set { this.m_enm_IsActive = value; }
        }
    }
}
