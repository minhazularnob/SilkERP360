using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace SilkERP360.CCL.BusinessEntities.SCPM
{
    public class ScPersoFaultCard : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_FaultyCardCode;
        protected System.UInt64 m_ui64_ScBatchCode;
        protected System.UInt64 m_ui64_MachineCode;
        protected System.UInt64 m_ui64_CardSl;
        protected System.UInt64 m_ui64_FaultType;
        protected System.String m_str_FaultType;
        protected System.DateTime m_dt_FaultDateTime;
        protected SilkERP360.CCL.Enums.YesNo m_enm_RePersoed;
        protected System.DateTime m_dt_RePersoDateTime;
        protected System.UInt64 m_ui64_RePersoEmpCode;
        protected System.UInt64 m_ui64_EntryEmpCode;
        protected System.String m_str_Remarks;

        public System.UInt64 FaultyCardCode
        {
            get { return this.m_ui64_FaultyCardCode; }
            set { this.m_ui64_FaultyCardCode = value; }
        }
        public System.UInt64 BatchCode
        {
            get { return this.m_ui64_ScBatchCode; }
            set { this.m_ui64_ScBatchCode = value; }
        }
        public System.UInt64 MachineCode
        {
            get { return this.m_ui64_MachineCode; }
            set { this.m_ui64_MachineCode = value; }
        }
        public System.UInt64 CardSl
        {
            get { return this.m_ui64_CardSl; }
            set { this.m_ui64_CardSl = value; }
        }
        public System.UInt64 FaultType
        {
            get { return this.m_ui64_FaultType; }
            set { this.m_ui64_FaultType = value; }
        }

        /// <summary>
        /// This will be used to convey the string representation of the FaultType
        /// Enumeration to the Client
        /// </summary>
        public System.String FaultTypeStr
        {
            get
            {
                return this.m_str_FaultType;
            }
            set
            {
                this.m_str_FaultType = value;
            }
        }

        public System.DateTime FaultDateTime
        {
            get { return this.m_dt_FaultDateTime; }
            set { this.m_dt_FaultDateTime = value; }
        }
        public SilkERP360.CCL.Enums.YesNo RePersoed
        {
            get { return this.m_enm_RePersoed; }
            set { this.m_enm_RePersoed = value; }
        }
        public System.DateTime RePersoDateTime
        {
            get { return this.m_dt_RePersoDateTime; }
            set { this.m_dt_RePersoDateTime = value; }
        }
        public System.UInt64 RePersoEmpCode
        {
            get { return this.m_ui64_RePersoEmpCode; }
            set { this.m_ui64_RePersoEmpCode = value; }
        }
        public System.UInt64 EntryEmpCode
        {
            get { return this.m_ui64_EntryEmpCode; }
            set { this.m_ui64_EntryEmpCode = value; }
        }
        public System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }
    }
}
