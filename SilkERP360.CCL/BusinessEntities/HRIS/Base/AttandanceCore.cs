using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Microsoft.Practices.Unity;

namespace SilkERP360.CCL.BusinessEntities.HRIS.Base
{
    public class AttandanceCore
    {

       #region CONSTRUCTOR
        public AttandanceCore()
        {
        }
        #endregion

        #region protected VARIABLES
        protected System.UInt64 m_uint64_CompanyCode;
        protected System.DateTime m_date_ProcessDate;
        protected System.UInt64 m_uint64_ShiftCode;       
        #endregion
        #region PUBLIC PROPERTIES
        public System.UInt64 CompanyCode
        {
            get { return m_uint64_CompanyCode; }
            set { m_uint64_CompanyCode = value; }
        }

        public System.DateTime ProcessDate
        {
            get { return m_date_ProcessDate; }
            set { m_date_ProcessDate = value; }
        }

        public System.UInt64 ShiftCode
        {
            get { return m_uint64_ShiftCode; }
            set { m_uint64_ShiftCode = value; }
        }
        #endregion
    }
    
}
