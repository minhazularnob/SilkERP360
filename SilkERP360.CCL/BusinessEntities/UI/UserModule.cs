using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    /// <summary>
    /// This Class Represents the USER_MODULES table which contains the Modules
    /// that a User is Permitted to access
    /// </summary>
    public class UserModule : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.Validation.Attributes.NonZeroInteger(FieldName = "UserCode", Message = "UserCode Cannot Be Blank or Null or 0!!!")]
        protected System.UInt64 m_ui64_UserCode;
        public System.UInt64 UserCode
        {
            get { return this.m_ui64_UserCode; }
            //set { m_ui64_UserCode = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.NonZeroInteger(FieldName = "ModuleCode", Message = "ModuleCode Cannot Be Blank or Null or 0!!!")]
        protected System.UInt64 m_ui64_ModuleCode;
        public System.UInt64 ModuleCode
        {
            get { return this.m_ui64_ModuleCode; }
            //set { m_ui64_ModuleCode = value; }
        }

        public UserModule(System.UInt64 IP_ui64_UserCode, System.UInt64 IP_ui64_ModuleCode)
        {
            this.m_ui64_UserCode = IP_ui64_UserCode;
            this.m_ui64_ModuleCode = IP_ui64_ModuleCode;
        }
    }
}
