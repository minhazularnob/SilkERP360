using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.UI
{
    public class Menu : SilkERP360.CCL.Validation.ValidationBase
    {
        protected System.UInt64 m_ui64_MenuCode;
        public System.UInt64 MenuCode
        {
            get { return this.m_ui64_MenuCode; }
            set { this.m_ui64_MenuCode = value; }
        }

        /// <summary>
        /// Code of the module that this menu belongs to
        /// </summary>
        protected System.UInt64 m_ui64_ModuleCode;
        public System.UInt64 ModuleCode
        {
            get { return this.m_ui64_ModuleCode; }
            set { this.m_ui64_ModuleCode = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "MenuName", Message = "MenuName Cannot Be Empty!!!")]
        protected System.String m_str_MenuName;
        public System.String MenuName
        {
            get { return this.m_str_MenuName; }
            set { this.m_str_MenuName = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "ShortName", Message = "ShortName Cannot Be Empty!!!")]
        protected System.String m_str_ShortName;
        public System.String ShortName
        {
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }

        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "MenuLable", Message = "MenuLabel Cannot Be Empty!!!")]
        protected System.String m_str_MenuLabel;
        public System.String MenuLabel
        {
            get { return this.m_str_MenuLabel; }
            set { this.m_str_MenuLabel = value; }
        }

        /// <summary>
        /// URL to the Home page of the module
        /// </summary>
        [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Link", Message = "Link Cannot Be Empty!!!")]
        protected System.String m_str_Link;
        public System.String Link
        {
            get { return this.m_str_Link; }
            set { this.m_str_Link = value; }
        }

        protected SilkERP360.CCL.Enums.Status m_enm_Status;
        public SilkERP360.CCL.Enums.Status Status
        {
            get { return this.m_enm_Status; }
            set { this.m_enm_Status = value; }
        }

        protected SilkERP360.CCL.Enums.YesNo m_enm_IsDeleted;
        /// <summary>
        /// Is Deleted Flag
        /// </summary>
        public SilkERP360.CCL.Enums.YesNo IsDeleted
        {
            get { return this.m_enm_IsDeleted; }
            set { this.m_enm_IsDeleted = value; }
        }

        /// <summary>
        /// ParentMenuCode is Nullable. Cause, some menu will have null in ParentMenuCode
        /// </summary>
        protected System.Nullable<System.UInt64> m_ui64_ParentMenuCode;
        /// <summary>
        /// ParentMenuCode is Nullable. Cause, some menu will have null in ParentMenuCode
        /// </summary>
        public System.Nullable<System.UInt64> ParentMenuCode
        {
            get { return this.m_ui64_ParentMenuCode; }
            set { this.m_ui64_ParentMenuCode = value; }
        }
    }
}
