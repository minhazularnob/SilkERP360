using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_PANTONE_COLORS", "SEQ_PANTONE_COLOR")]
    public class PantoneColor : SilkERP360.CCL.Validation.ValidationBase
    {
        public PantoneColor()
        {
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PANTONE_COLOR_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_PantoneColorCode;
        public System.UInt64 PantoneColorCode
        {
            get { return m_ui64_PantoneColorCode; }
            set { m_ui64_PantoneColorCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PANTONE_COLOR_NAME", typeof(System.String), false, false)]
        protected System.String m_str_PantoneColorName;
        public System.String PantoneColorName
        {
            get { return m_str_PantoneColorName; }
            set { m_str_PantoneColorName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PANTONE_COLOR", typeof(System.String), false, false)]
        protected System.String m_str_Pantone;
        public System.String Pantone
        {
            get { return m_str_Pantone; }
            set { m_str_Pantone = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HEX", typeof(System.String), false, false)]
        protected System.String m_str_Hex;
        public System.String Hex
        {
            get { return m_str_Hex; }
            set { m_str_Hex = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("RGB", typeof(System.String), false, false)]
        protected System.String m_str_RGB;
        public System.String RGB
        {
            get { return m_str_RGB; }
            set { m_str_RGB = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { m_ui64_EntryEmployeeCode = value; }
        }
        
    }
}
