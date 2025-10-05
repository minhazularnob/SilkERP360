using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class Module : SilkERP360.CCL.Validation.ValidationBase
    {
        #region public CONSTRUCTOR
        public Module()
        {
        }

        #endregion


        #region public VARIABLES

        protected System.UInt64 m_ui64_ModuleCode;
        protected System.String m_str_ModuleName;
        protected System.String m_str_Shortname;
        protected System.String m_str_HomeLink;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_Status;

         #endregion

        #region public PROPERTIES

        public System.UInt64 ModuleCode
        {
            get { return m_ui64_ModuleCode; }
            set { this.m_ui64_ModuleCode = value; }
        }
        

        public System.String ModuleName
        {
            get { return m_str_ModuleName; }
            set { this.m_str_ModuleName = value; }
        }
        

        public System.String Shortname
        {
            get { return m_str_Shortname; }
            set { this.m_str_Shortname = value; }
        }
        

        public System.String HomeLink
        {
            get { return m_str_HomeLink; }
            set { this.m_str_HomeLink = value; }
        }
        public System.UInt16 IsDeleted
        {
            get { return this.m_ui16_IsDeleted; }
            set { this.m_ui16_IsDeleted = value; }
        }
        public System.UInt16 Status
        {
            get { return this.m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }

        #endregion


    }
}
