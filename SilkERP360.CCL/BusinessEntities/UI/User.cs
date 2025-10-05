using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    public class User : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        protected System.UInt64 m_ui64_UserCode;

        public System.UInt64 UserCode
        {
            get { return this.m_ui64_UserCode; }
            set { this.m_ui64_UserCode = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.StringLength(FieldName="UserName",Length=32,Message="Username Cannot Be More Than 32 Characters in Length!")]
        protected System.String m_str_UserName;
        public System.String UserName
        {
            get { return this.m_str_UserName; }
            set { this.m_str_UserName = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.StringLength(FieldName = "Password", Length = 16, Message = "Password Cannot Be More Than 16 Characters in Length!")]
        protected System.String m_str_Password;
        public System.String Password
        {
            get { return this.m_str_Password; }
            set { this.m_str_Password = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.Required(FieldName="SecretWord",Message="Secret Word will be used to reset forgotten Password!Mandatory!")]
        public System.String m_str_SecretWordHash;

        protected System.String SecretWordHash
        {
            get { return this.m_str_SecretWordHash; }
            set { this.m_str_SecretWordHash = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.IntegerRange(FieldName="AccessLevel",Min=1,Max=5,Message="AccessLevel Must Be Between 1 and 5!!!")]
        private System.UInt16 m_ui16_AccessLevel;
        public System.UInt16 AccessLevel
        {
            get { return this.m_ui16_AccessLevel; }
            set { this.m_ui16_AccessLevel = value; }
        }
       
    }
}
