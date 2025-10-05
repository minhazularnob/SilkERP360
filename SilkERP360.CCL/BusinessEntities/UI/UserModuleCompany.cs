using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    /// <summary>
    /// This class represents the USER_MODULE_COMPANY table which contains data about the Companies data
    /// that a user is permitted to access in the given module
    /// </summary>
    public class UserModuleCompany : SilkERP360.CCL.BusinessEntities.UI.UserModule
    {
        private System.UInt64 m_ui64_CompanyCode;

        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            //set { m_ui64_CompanyCodes = value; }
        }

                
        public UserModuleCompany(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode,System.UInt64 IP_ui64_CompanyCode)
            : base(IP_ui64_UserCode, IP_ui64_ModuleCode)
        {
            this.m_ui64_CompanyCode = IP_ui64_CompanyCode;
        }
    }
}
