using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Misc
{
    public class SilkWebMethod
    {
        private readonly System.String m_str_WebMethodCode;
        public System.String WebMethodCode
        {
            get { return this.m_str_WebMethodCode; }
        }

        private readonly System.String m_str_WebMethodName;
        public System.String WebMethodName
        {
            get { return this.m_str_WebMethodName; }
        }

        private readonly System.String m_str_PhysicalPath;
        public System.String PhysicalPath
        {
            get { return this.m_str_PhysicalPath; }
        }

        private readonly System.String m_str_VirtualPath;
        public System.String VirtualPath
        {
            get { return this.m_str_VirtualPath; }
        }

        public SilkWebMethod(System.String IP_str_WebMethodCode, System.String IP_str_WebMethodName, System.String IP_str_PhysicalPath, System.String IP_str_VirtualPath)
        {
            this.m_str_WebMethodCode = IP_str_WebMethodCode;
            this.m_str_WebMethodName = IP_str_WebMethodName;
            this.m_str_PhysicalPath = IP_str_PhysicalPath;
            this.m_str_VirtualPath = IP_str_VirtualPath;
        }
    }
}
