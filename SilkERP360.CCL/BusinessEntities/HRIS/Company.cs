using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class Company : SilkERP360.CCL.BusinessEntities.HRIS.Base.CompanyCore
    {
        #region public CONSTRUCTOR
        public Company()
        {
        }
        #endregion
        #region VALIDATION
        //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Name", Message = "Name Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Address", Message = "Address Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "PhoneNo", Message = "Phone No Entry")]
#endregion

        #region protected VARIABLES

       // protected System.UInt64 m_Int_CompanyCode;
       // protected System.String m_str_Name;
        protected System.String m_str_Address;
        protected System.String m_str_PhoneNo;
        protected System.String m_str_FaxNo;
        protected System.String m_str_Email;
        protected System.String m_str_WebSite;
        protected System.String m_str_CompanyShortName;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_Status;
        #endregion

        #region PUBLIC PROPERTIES
        //public System.UInt64 CompanyCode
        //{
        //    get { return this.m_Int_CompanyCode; }
        //    set { this.m_Int_CompanyCode = value; }
        //}
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
        public System.String PhoneNo
        {
            get { return this.m_str_PhoneNo; }
            set { this.m_str_PhoneNo = value; }
        }
        public System.String FaxNo
        {
            get { return this.m_str_FaxNo; }
            set { this.m_str_FaxNo = value; }
        }
        public System.String Email
        {
            get { return this.m_str_Email; }
            set { this.m_str_Email = value; }
        }
        public System.String WebSite
        {
            get { return this.m_str_WebSite; }
            set { this.m_str_WebSite = value; }
        }
        public System.String CompanyShortName
        {
            get { return m_str_CompanyShortName; }
            set { m_str_CompanyShortName = value; }
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
