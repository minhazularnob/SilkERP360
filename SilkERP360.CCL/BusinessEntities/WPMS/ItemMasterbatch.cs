using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_ITEM_MASTERBATCH", "SEQ_MASTERBATCH")]
    public class ItemMasterbatch : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MASTERBATCH_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_MasterBatchCode;
        public System.UInt64 MasterBatchCode
        {
            get { return m_ui64_MasterBatchCode; }
            set { this.m_ui64_MasterBatchCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ITEM_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_ItemCode;
        public System.UInt64 ItemCode
        {
            get { return m_ui64_ItemCode; }
            set { this.m_ui64_ItemCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PANTONE_COLOR_NAME", typeof(System.String), false, false)]
        protected System.String m_str_PantoneColorName;
        public System.String PantoneColorName
        {
            get { return m_str_PantoneColorName; }
            set { m_str_PantoneColorName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PANTONE_COLOR", typeof(System.String), false, false)]
        protected System.String m_str_PantoneColor;
        public System.String PantoneColor
        {
            get { return m_str_PantoneColor; }
            set { m_str_PantoneColor = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COLOR_HEX", typeof(System.String), false, false)]
        protected System.String m_str_ColorHex;
        public System.String ColorHex
        {
            get { return m_str_ColorHex; }
            set { m_str_ColorHex = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PERCENTAGE", typeof(System.Decimal), false, false)]
        protected System.Decimal m_ui64_Percentage;
        public System.Decimal Percentage
        {
            get { return m_ui64_Percentage; }
            set { this.m_ui64_Percentage = value; }
        }
    }
}
