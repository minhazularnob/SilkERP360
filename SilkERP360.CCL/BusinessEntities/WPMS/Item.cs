using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_ITEMS", "SEQ_WPMS_ITEM")]
   public class Item : SilkERP360.CCL.Validation.ValidationBase
   {
       #region        

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ProductCode;
        public System.UInt64 ProductCode
        {
            get { return m_ui64_ProductCode; }
            set { m_ui64_ProductCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_CATAGORY_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ItemCatagoryCode;
        public System.UInt64 ItemCatagoryCode
        {
            get { return m_ui64_ItemCatagoryCode; }
            set { m_ui64_ItemCatagoryCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BUYER_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_BuyerCode;
        public System.UInt64 BuyerCode
        {
            get { return m_ui64_BuyerCode; }
            set { m_ui64_BuyerCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WIDTH", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_Width;
        public System.Decimal Width
        {
            get { return m_str_Width; }
            set { m_str_Width = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("GUSSET", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_Gusset;
        public System.Decimal Gusset
        {
            get { return m_str_Gusset; }
            set { m_str_Gusset = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LENGTH", typeof(System.Decimal), false, false)]
        protected System.Decimal m_i16_Length;
        public System.Decimal Length
        {
            get { return m_i16_Length; }
            set { m_i16_Length = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("THICKNESS", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_Thickness;
        public System.Decimal Thickness
        {
            get { return m_str_Thickness; }
            set { m_str_Thickness = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PROCESSING_COST", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_ProcessingCost;
        public System.Decimal ProcessingCost
        {
            get { return m_str_ProcessingCost; }
            set { m_str_ProcessingCost = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRINTING_CHARGE", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_PrintingCharge;
        public System.Decimal PrintingCharge
        {
            get { return m_str_PrintingCharge; }
            set { m_str_PrintingCharge = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PUNCHOUT", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_Punchout;
        public System.Decimal Punchout
        {
            get { return m_str_Punchout; }
            set { m_str_Punchout = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DENSITY", typeof(System.Decimal), false, false)]
        protected System.Decimal m_str_Density;
        public System.Decimal Density
        {
            get { return m_str_Density; }
            set { m_str_Density = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_ui16_IsActive;
        public SilkERP360.CCL.Enums.YesNo IsActive
        {
            get { return m_ui16_IsActive; }
            set { m_ui16_IsActive = value; }
        }
        
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PRODUCT_NAME", typeof(System.Decimal), false, false)]
        protected System.String m_str_ProductName;
        public System.String ProductName
        {
            get { return m_str_ProductName; }
            set { m_str_ProductName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IP_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_IPEmployeeCode;
        public System.UInt64 IPEmployeeCode
        {
            get { return m_ui64_IPEmployeeCode; }
            set { m_ui64_IPEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IP_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_IPDate;
        public System.DateTime IPDate
        {
            get { return m_dt_IPDate; }
            set { m_dt_IPDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_REF_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ProductRefCode;
        public System.UInt64 ProductRefCode
        {
            get { return m_ui64_ProductRefCode; }
            set { m_ui64_ProductRefCode = value; }
        }

       #endregion

           }
}
