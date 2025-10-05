using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class ScJO : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_ScJOCode;
        protected System.String m_str_ScJONo;
        protected System.String m_str_Telco;
        protected System.UInt64 m_ui64_ProductionStatus;
        protected System.UInt16 m_ui16_Status;

        public System.UInt64 ScJOCode
        {
            get { return this.m_ui64_ScJOCode; }
            set { this.m_ui64_ScJOCode = value; }
        }
        public System.String ScJONo
        {
            get { return this.m_str_ScJONo; }
            set { this.m_str_ScJONo = value; }
        }
        public System.String Telco
        {
            get { return this.m_str_Telco; }
            set { this.m_str_Telco = value; }
        }
        public System.UInt64 ProductionStatus
        {
            get { return this.m_ui64_ProductionStatus; }
            set { this.m_ui64_ProductionStatus = value; }
        }
        public System.UInt16 Status
        {
            get { return this.m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }
    }
}
