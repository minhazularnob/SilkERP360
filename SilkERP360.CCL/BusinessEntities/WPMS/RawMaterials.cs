using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_RAW_MATERIAL", "SEQ_WPMS_RAWMATARIAL")]
  
    public class RawMaterials : SilkERP360.CCL.Validation.ValidationBase
    {
      public RawMaterials()
      {

      }
        #region Protected Variables
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("RM_CODE", typeof(System.UInt64), false, false)]
      protected System.UInt64 m_ui64_RMCode;

        public System.UInt64 RMCode
        {
            get { return m_ui64_RMCode; }
            set { m_ui64_RMCode = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_UPDATE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ProductUpdateCode;

        public System.UInt64 ProductUpdateCode
        {
            get { return m_ui64_ProductUpdateCode; }
            set { m_ui64_ProductUpdateCode = value; }
        }
        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MONTH", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_Month;

        public System.DateTime Month
        {
            get { return m_dt_Month; }
            set { m_dt_Month = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRICE_M_TON", typeof(System.Decimal), false, false)]
        protected System.Decimal m_ui16_PriceMTon;

        public System.Decimal PriceMTon
        {
            get { return m_ui16_PriceMTon; }
            set { m_ui16_PriceMTon = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_ui16_IsActive;

        public SilkERP360.CCL.Enums.YesNo IsActive
        {
            get { return m_ui16_IsActive; }
            set { m_ui16_IsActive = value; }
        }
       

      protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.WPMS.RawLIST> m_lcl_obj_RawSubList = new List<RawLIST>();
      protected SilkERP360.CCL.BusinessEntities.WPMS.RawProduct m_lcl_RawProductList = new RawProduct();

      public SilkERP360.CCL.BusinessEntities.WPMS.RawProduct lcl_RawProductList
      {
          get { return m_lcl_RawProductList; }
          set { m_lcl_RawProductList = value; }
      }

        #endregion
    }
}
