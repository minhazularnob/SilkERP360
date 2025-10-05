using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Security
{
    /// <summary>
    /// This class contains details for all incoming request to the server from the client.
    /// Goal:
    /// 1. To ward off brute force attack which generates consecutive request to the server.
    /// </summary>
    public class ClientRequest
    {
        /// <summary>
        /// IP Address of the client
        /// </summary>
        private readonly System.String m_str_ClientIP;
        /// <summary>
        /// IP Address of the client
        /// </summary>
        public System.String ClientIP
        {
            get { return this.m_str_ClientIP; }
            //set { m_str_ClientIP = value; }
        }

        /// <summary>
        /// The DateTime of the Incoming client request
        /// </summary>
        private readonly System.DateTime m_dt_RequestDateTime;
        /// <summary>
        /// The DateTime of the Incoming client request
        /// </summary>
        public System.DateTime RequestDateTime
        {
            get { return this.m_dt_RequestDateTime; }
            //set { m_dt_RequestDateTime = value; }
        }

        /// <summary>
        /// The server resource requested by the client
        /// </summary>
        private readonly System.String m_str_RequestedResourceUrl;
        /// <summary>
        /// The server resource requested by the client
        /// </summary>
        public System.String RequestedResourceUrl
        {
            get { return this.m_str_RequestedResourceUrl; }
            //set { m_str_RequestedResource = value; }
        }

        #region Constructor
        public ClientRequest(System.String IP_str_ClientIP, System.DateTime IP_dt_RequestDateTime, System.String IP_str_RequestedResource)
        {
            this.m_str_ClientIP = IP_str_ClientIP;
            this.m_dt_RequestDateTime = IP_dt_RequestDateTime;
            this.m_str_RequestedResourceUrl = IP_str_RequestedResource;
        }
        #endregion
    }
}
