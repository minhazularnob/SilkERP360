using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilkERP360.UI.Base
{
    /// <summary>
    /// Summary description for ContentsResponse
    /// </summary>
    public class ContentsResponse
    {
        private System.String m_str_HTML;
        public System.String HTML
        {
            get { return m_str_HTML; }
            set { m_str_HTML = value; }
        }

        private System.String m_str_Script;
        public System.String Script
        {
            get { return m_str_Script; }
            set { m_str_Script = value; }
        }

        private System.String m_str_CustomStyle;
        public System.String CustomStyle
        {
            get { return m_str_CustomStyle; }
            set { m_str_CustomStyle = value; }
        }

        public ContentsResponse(System.String IP_str_HTML, System.String IP_str_Script, System.String IP__str_CustomStyle)
        {
            this.m_str_HTML = IP_str_HTML;
            this.m_str_Script = IP_str_Script;
            this.m_str_CustomStyle = IP__str_CustomStyle;
        }

        public static ContentsResponse Empty
        {
            get
            {
                return new ContentsResponse(System.String.Empty, System.String.Empty, System.String.Empty);
            }
        }
    }
}