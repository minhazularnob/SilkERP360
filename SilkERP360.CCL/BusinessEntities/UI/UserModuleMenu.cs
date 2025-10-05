using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    /// <summary>
    /// This class represents the USER_MODULE_MENUS table which contains the menus that
    /// a user is permitted to access
    /// </summary>
    public class UserModuleMenu : SilkERP360.CCL.BusinessEntities.UI.UserModule
    {
        [SilkERP360.CCL.Validation.Attributes.NonZeroInteger(FieldName = "MenuCode", Message = "MenuCode Cannot Be Blank or Null or 0!!!")]
        protected System.UInt64 m_ui64_MenuCode;
        public System.UInt64 MenuCode
        {
            get { return m_ui64_MenuCode; }
        //    //set { m_ui64_MenuCode = value; }
        }
        
        public UserModuleMenu(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode,System.UInt64 IP_ui64_MenuCode)
            : base(IP_ui64_UserCode, IP_ui64_ModuleCode)
        {
            this.m_ui64_UserCode = IP_ui64_UserCode;
            this.m_ui64_ModuleCode = IP_ui64_ModuleCode;
            this.m_ui64_MenuCode = IP_ui64_MenuCode;
        }

    }
}
