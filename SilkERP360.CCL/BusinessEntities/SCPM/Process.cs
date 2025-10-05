using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class Process : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_ProcessCode;
        protected System.UInt64 m_ui64_SectionCode;
        protected System.String m_str_Name;
        protected System.UInt16 m_ui16_Status;

        public System.UInt64 ProcessCode
        {
            get { return this.m_ui64_ProcessCode; }
            set { this.m_ui64_ProcessCode = value; }
        }
        public System.UInt64 SectionCode
        {
            get { return this.m_ui64_SectionCode; }
            set { this.m_ui64_SectionCode = value; }
        }
        public System.String Name
        {
            get { return this.m_str_Name; }
            set { this.m_str_Name = value; }
        }
        public System.UInt16 Status
        {
            get { return this.m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }
    }
}
