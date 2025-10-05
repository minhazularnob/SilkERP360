using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Repository
{
    public class AuthenticUserContext
    {
        /// <summary>
        /// It will contain the module code of the Module that the user
        /// is working on.It will be set in respective modules home page's page_load method
        /// </summary>
        private System.UInt64 m_ui64_ActiveModuleCode;
        /// <summary>
        /// It will contain the module code of the Module that the user
        /// is working on.It will be set in respective modules home page's page_load method
        /// </summary>
        public System.UInt64 ActiveModuleCode
        {
            get { return this.m_ui64_ActiveModuleCode; }
            set { this.m_ui64_ActiveModuleCode = value; }
        }
        private readonly System.String m_str_SessionID;
        public System.String SessionID
        {
            get { return this.m_str_SessionID; }
        }

        private readonly System.String m_str_SecurityToken;
        public System.String SecurityToken
        {
            get { return this.m_str_SecurityToken; }
        }
        private readonly System.String m_str_IPAddress;
        public System.String IPAddress
        {
            get { return this.m_str_IPAddress; }
        }

        private readonly SilkERP360.CCL.BusinessEntities.UI.UserProfile m_obj_UserProfile;
        public SilkERP360.CCL.BusinessEntities.UI.UserProfile UserProfile
        {
            get { return this.m_obj_UserProfile; }
        }


        public AuthenticUserContext(System.String IP_str_SessionID, System.String IP_str_SecurityToken,System.String IP_str_IPAddress, SilkERP360.CCL.BusinessEntities.UI.UserProfile IP_obj_UserProfile)
        {
            this.m_str_SessionID = IP_str_SessionID;
            this.m_str_SecurityToken = IP_str_SecurityToken;
            this.m_str_IPAddress = IP_str_IPAddress;
            this.m_obj_UserProfile = IP_obj_UserProfile;
        }

    }
}
