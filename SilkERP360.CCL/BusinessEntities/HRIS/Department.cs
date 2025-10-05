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
    public class Department : SilkERP360.CCL.Validation.ValidationBase
    {
        #region CONSTRUCTOR
        public Department()
        {
        }
        #endregion

        #region VALIDATION
    [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "DeptName", Message = "Dept Name Entry")]
    #endregion

        #region protected VARIABLES

        protected System.UInt64 m_ui64_DepartmentCode;
        protected System.String m_str_DeptName;
        protected System.String m_str_ShortName;
        protected System.UInt64 m_ui64_CompanyCode;
        protected System.String m_str_HeadEmployeeId;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_Status;
        #endregion


        #region PUBLIC PROPERTIES
        public System.UInt64 DepartmentCode
        {
            get { return this.m_ui64_DepartmentCode; }
            set { this.m_ui64_DepartmentCode = value; }
        }
        public System.String DeptName
        {
            get { return this.m_str_DeptName; }
            set { this.m_str_DeptName = value; }
        }
        public System.String ShortName
        {
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }
        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }
        public System.String HeadEmployeeId
        {
            get { return this.m_str_HeadEmployeeId; }
            set { this.m_str_HeadEmployeeId = value; }
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