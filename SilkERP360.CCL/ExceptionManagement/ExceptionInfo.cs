using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement
{
    public class ExceptionInfo
    {
        private  System.Int32 m_i32_EventSourceCode;
        /// <summary>
        /// The HRESULT (HEX INTEGER) Value of System.Exception Class
        /// </summary>
        public  System.Int32 EventSourceCode
        {
            get { return this.m_i32_EventSourceCode; }
            set { this.m_i32_EventSourceCode = value; }
        }

        private System.String m_str_ErrorID;
        public System.String ErrorID
        {
            get { return this.m_str_ErrorID; }
            set { this.m_str_ErrorID = value.ToUpper(); }
        }


        private System.UInt64 m_ui64_ModuleCode;
        /// <summary>
        /// which module was operating when the error occured
        /// </summary>
        public System.UInt64 ModuleCode
        {
            get { return this.m_ui64_ModuleCode; }
            set { this.m_ui64_ModuleCode = value; }
        }

        private System.String m_str_UserName;
        public System.String UserName
        {
            get { return this.m_str_UserName; }
            set { this.m_str_UserName = value; }
        }

        /// <summary>
        /// Client IP where the request came from
        /// </summary>
        private System.String m_str_HostIP;
        public System.String HostIP
        {
            get { return this.m_str_HostIP; }
            set { this.m_str_HostIP = value; }
        }

        private SilkERP360.CCL.Enums.ExceptionOriginatorLayer m_enm_ExceptionOriginatorLayer;
        public SilkERP360.CCL.Enums.ExceptionOriginatorLayer ExceptionOriginatorLayer
        {
            get { return this.m_enm_ExceptionOriginatorLayer; }
            set { this.m_enm_ExceptionOriginatorLayer = value; }
        }

        private SilkERP360.CCL.Enums.ExceptionType m_enm_ExceptionType;
        public SilkERP360.CCL.Enums.ExceptionType ExceptionType
        {
            get { return this.m_enm_ExceptionType; }
            set { this.m_enm_ExceptionType = value; }
        }

        private  System.DateTime m_dt_ErrorDateTime;
        public  System.DateTime ErrorDateTime
        {
            get { return this.m_dt_ErrorDateTime; }
            set { this.m_dt_ErrorDateTime = value; }
        }

        private  System.String m_str_ErrorDesc;
        public  System.String ErrorDescription
        {
            get { return this.m_str_ErrorDesc; }
            set { this.m_str_ErrorDesc = value; }
        }

        private  System.String m_str_Source;
        /// <summary>
        /// Application/Object that generated the error
        /// </summary>
        public  System.String Source
        {
            get { return this.m_str_Source; }
            set { this.m_str_Source = value; }
        }

        private  System.String m_str_Trace;
        public  System.String Trace
        {
            get { return this.m_str_Trace; }
            set { this.m_str_Trace = value; }
        }

        private System.Reflection.MethodBase m_obj_TargetSite;
        /// <summary>
        /// Method that generated the error
        /// </summary>
        public  System.Reflection.MethodBase TargetSite
        {
            get { return this.m_obj_TargetSite; }
            set { this.m_obj_TargetSite = value; }
        }

        private  System.String m_str_Remarks;
        public  System.String Remarks
        {
            get { return this.m_str_Remarks; }
            set { this.m_str_Remarks = value; }
        }
    }
}
