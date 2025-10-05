using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Misc
{
    /// <summary>
    /// Every Web Service Will Return an Object of this type
    /// </summary>
    [Serializable]
    public sealed class WSResponse
    {
        public WSResponse()
        {
        }
        public WSResponse(SilkERP360.CCL.Enums.WebServiceExecutionStatus IP_enm_WSExecutionStatus,System.Int32 IP_i32_ResponseCode,System.String IP_str_Message,System.Boolean IP_b_BResponse,System.Object IP_obj_Data)
        {
            this.m_enm_WebServiceExecutionStatus = IP_enm_WSExecutionStatus;
            this.m_i32_ResponseCode = IP_i32_ResponseCode;
            this.m_str_Message = IP_str_Message;
            this.m_b_BResponse = IP_b_BResponse;
            this.m_obj_Data = IP_obj_Data;
        }
        private SilkERP360.CCL.Enums.WebServiceExecutionStatus m_enm_WebServiceExecutionStatus;
        public SilkERP360.CCL.Enums.WebServiceExecutionStatus WebServiceExecutionStatus
        {
            get { return this.m_enm_WebServiceExecutionStatus; }
            set { m_enm_WebServiceExecutionStatus = value; }
        }

        //Standard HTTP Response Codes
        private System.Int32 m_i32_ResponseCode;
        /// <summary>
        /// Standard HTTP Response Codes
        /// </summary>
        public System.Int32 ResponseCode
        {
            get { return this.m_i32_ResponseCode; }
            set { m_i32_ResponseCode = value; }
        }

        //If Error Occurs, A message can be passed through this member
        private System.String m_str_Message;
        /// <summary>
        /// If Error Occurs, A message can be passed through this member
        /// </summary>
        public System.String Message
        {
            get { return this.m_str_Message; }
            set { m_str_Message = value; }
        }


        private System.Boolean m_b_BResponse;
        /// <summary>
        /// If any webservice returns boolean, than it will be returned through this property.
        /// If the webservice doesnot return Boolean value, this property will always be set to false.
        /// Only when WebServiceExecution status is Success, this value will be considered if the WS expected to return Boolean
        /// </summary>
        public System.Boolean BResponse
        {
            get { return m_b_BResponse; }
            set { m_b_BResponse = value; }
        }

        //data that is to be returned
        private System.Object m_obj_Data;
        /// <summary>
        /// data that is to be returned
        /// </summary>
        public System.Object Data
        {
            get { return this.m_obj_Data; }
            set { m_obj_Data = value; }
        }
    }
}
