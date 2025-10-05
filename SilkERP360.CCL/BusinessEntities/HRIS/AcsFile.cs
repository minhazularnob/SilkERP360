using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
   public class AcsFile : SilkERP360.CCL.Validation.ValidationBase
    {

        #region CONSTRUCTOR

        public AcsFile()
        {
            this.m_obj_AcsFileRows = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AcsFileRow>();
        }

        #endregion

        #region VARIABLES
        protected System.UInt64 m_ui64_AcsFileCode;
        protected System.DateTime m_Dt_UploadDate;
        protected System.String m_str_FileHash;
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AcsFileRow> m_obj_AcsFileRows;


        //private System.String m_str_InputType;


        #endregion

        #region PROPERTIES
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.AcsFileRow> AcsFileRows
        {
            get { return this.m_obj_AcsFileRows; }
            //set { m_obj_AcsFileRows = value; }
        }

        public System.UInt64 AcsFileCode
        {
            get { return this.m_ui64_AcsFileCode; }
            set { this.m_ui64_AcsFileCode = value; }
        }
        public System.DateTime UploadDate
        {
            get { return this.m_Dt_UploadDate; }
            set { this.m_Dt_UploadDate = value; }
        }
        public System.String FileHash
        {
            get { return this.m_str_FileHash; }
            set { this.m_str_FileHash = value; }
        }
        #endregion
    }
}