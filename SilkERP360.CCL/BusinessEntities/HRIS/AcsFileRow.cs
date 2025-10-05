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
    public class AcsFileRow :SilkERP360.CCL.BusinessEntities.HRIS.AcsFile
    {
        #region CONSTRUCTOR
        public AcsFileRow()
        {
       
        }
        #endregion

        #region VARIAVLES
        protected System.UInt64 m_ui64_AcsFileRowCode;
        private System.String m_str_CardOREmpId;
        protected System.String m_str_ReaderName;
        private SilkERP360.CCL.Enums.AccessControlTransactionType m_enm_TransactionType;
        protected System.DateTime m_Dt_TransactionDateTime;   
        protected System.UInt64 m_ui64_AcsFileCode;
      
      
        #endregion

        #region PROPERTIES
        public System.UInt64 AcsFileRowsCode
        {
            get { return this.m_ui64_AcsFileRowCode; }
            set { this.m_ui64_AcsFileRowCode = value; }
        }
        public System.String CardOREmpId
        {
            get { return this.m_str_CardOREmpId; }
            set { this.m_str_CardOREmpId = value; }
        }
        public System.String ReaderName
        {
            get { return this.m_str_ReaderName; }
            set { this.m_str_ReaderName = value; }
        }
        public SilkERP360.CCL.Enums.AccessControlTransactionType TransactionType
        {
            get { return m_enm_TransactionType; }
            set { m_enm_TransactionType = value; }
        }
        public System.DateTime TransectionDateTime
        {
            get { return this.m_Dt_TransactionDateTime; }
            set { this.m_Dt_TransactionDateTime = value; }
        }

        public System.UInt64 AcsFileCode
        {
            get { return this.m_ui64_AcsFileCode; }
            set { m_ui64_AcsFileCode = value; }
        }
    

       
        #endregion
    }
}