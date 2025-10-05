using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    /// <summary>
    /// No corresponding DB Entity. Initialized from file
    /// </summary>
    public class Color
    {
        protected System.String m_str_Name;
        public System.String Name
        {
            get { return m_str_Name; }
            set { m_str_Name = value; }
        }

        protected System.String m_str_PantoneCode;
        public System.String PantoneCode
        {
            get { return m_str_PantoneCode; }
            set { m_str_PantoneCode = value; }
        }

        protected System.String m_str_Hex;
        public System.String Hex
        {
            get { return m_str_Hex; }
            set { m_str_Hex = value; }
        }
    }
}
