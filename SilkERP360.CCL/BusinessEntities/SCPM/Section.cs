using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class Section : SilkERP360.CCL.Validation.ValidationBase
    {
        public Section()
        {
        }

        #region ProtectedMembers
        private System.UInt64 m_ui64_SectionCode;
        private System.UInt64 m_ui64_CompanyCode;
        private System.String m_str_Name;
        private System.UInt16 m_ui16_Status;
        #endregion

        #region PublicProperties
        public System.UInt64 SectionCode
        {
            get { return this.m_ui64_SectionCode; }
            set { this.m_ui64_SectionCode = value; }
        }

        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
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
        #endregion
    }
}
