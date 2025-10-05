using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class EmployeeReference : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public EmployeeReference()
        {
        }
        #endregion
          
        #region protected VARIABLES
        protected System.Decimal m_dcm_ReferenceCode;
        protected System.String m_str_Name;
        protected System.String m_str_Address;
        protected System.String m_str_ContactNo;
        protected System.String m_str_Designation;
        protected System.String m_str_CompanyOrganization;
        protected System.UInt64 m_uint64_EmployeeCode;
        protected System.Int16 m_int16_IsDeleted;
        protected System.Int16 m_int16_Status;
        #endregion

        #region PUBLIC PROPERTIES
        public System.Decimal ReferenceCode
        {
            get { return this.m_dcm_ReferenceCode; }
            set { this.m_dcm_ReferenceCode = value; }
        }
        public System.String Name
        {
            get { return this.m_str_Name; }
            set { this.m_str_Name = value; }
        }
        public System.String Address
        {
            get { return this.m_str_Address; }
            set { this.m_str_Address = value; }
        }
        public System.String ContactNo
        {
            get { return this.m_str_ContactNo; }
            set { this.m_str_ContactNo = value; }
        }
        public System.String Designation
        {
            get { return this.m_str_Designation; }
            set { this.m_str_Designation = value; }
        }
        public System.String CompanyOrganization
        {
            get { return this.m_str_CompanyOrganization; }
            set { this.m_str_CompanyOrganization = value; }
        }
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
        }
        public System.Int16 IsDeleted
        {
            get { return this.m_int16_IsDeleted; }
            set { this.m_int16_IsDeleted = value; }
        }
        public System.Int16 Status
        {
            get { return this.m_int16_Status; }
            set { this.m_int16_Status = value; }
        }
        #endregion
    }
}
