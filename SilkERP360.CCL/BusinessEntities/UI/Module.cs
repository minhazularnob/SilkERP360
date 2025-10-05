using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    public class Module : SilkERP360.CCL.Validation.ValidationBase
    {

        protected System.UInt64 m_ui64_ModuleCode;
        public System.UInt64 ModuleCode
        {
            get { return this.m_ui64_ModuleCode; }
            set { this.m_ui64_ModuleCode = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.Required(FieldName="ModuleName",Message="ModuleName Cannot Be Empty!!!")]
        protected System.String m_str_ModuleName;
        public System.String ModuleName
        {
            get { return this.m_str_ModuleName; }
            set { this.m_str_ModuleName = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "ShortName", Message = "ShortName Cannot Be Empty!!!")]
        protected System.String m_str_ShortName;
        public System.String ShortName
        {
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }

        /// <summary>
        /// URL to the Home page of the module
        /// </summary>
        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "HomeLink", Message = "Homelink Cannot Be Empty!!!")]
        protected System.String m_str_HomeLink;
        public System.String HomeLink
        {
            get { return this.m_str_HomeLink; }
            set { this.m_str_HomeLink = value; }
        }

        /// <summary>
        /// Active/Inactive Status of the Module
        /// </summary>
        protected SilkERP360.CCL.Enums.Status m_enm_Status;
        public SilkERP360.CCL.Enums.Status Status
        {
            get { return this.m_enm_Status; }
            set { this.m_enm_Status = value; }
        }

        
    }
}
