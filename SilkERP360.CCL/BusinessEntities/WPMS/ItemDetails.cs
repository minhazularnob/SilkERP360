using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_ITEM_DETAILS", "SEQ_WPMS_ITEM_DETAILS")]
    public class ItemDetails : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_D_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_str_ItemDCode;

        public System.UInt64 ItemDCode
        {
            get { return m_str_ItemDCode; }
            set { m_str_ItemDCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_str_ItemCode;

        public System.UInt64 ItemCode
        {
            get { return m_str_ItemCode; }
            set { m_str_ItemCode = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_NAME", typeof(System.String), false, false)]
        protected System.String m_str_ItemName;

        public System.String ItemName
        {
            get { return m_str_ItemName; }
            set { m_str_ItemName = value; }
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


        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IP_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        //public System.UInt64 m_ui64_IPEmployeeCode;

        //public System.UInt64 IPEmployeeCode
        //{
        //    get { return m_ui64_IPEmployeeCode; }
        //    set { m_ui64_IPEmployeeCode = value; }
        //}
        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IP_DATE", typeof(System.DateTime), false, false)]
        //public System.DateTime m_dt_IPDate;

        //public System.DateTime IPDate
        //{
        //    get { return m_dt_IPDate; }
        //    set { m_dt_IPDate = value; }
        //}


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_REF_CODE", typeof(System.UInt64), false, false)]
        public System.UInt64 m_ui64_ItemRefCode;

        public System.UInt64 ItemRefCode
        {
            get { return m_ui64_ItemRefCode; }
            set { m_ui64_ItemRefCode = value; }
        }

       
    }
}
