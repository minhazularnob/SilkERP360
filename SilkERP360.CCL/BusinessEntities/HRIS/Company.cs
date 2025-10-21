using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("company", "SEQ_COMPANY")]
    public class Company : CompanyCore
    {
        public Company()
        {
            IsDeleted =1;
            Status = (Int16)SilkERP360.CCL.Enums.Status.Active;
        }

        [SilkERP360.CCL.Validation.Attributes.Required]
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), true, false)]
        protected UInt64 m_companyCode;
        public UInt64 CompanyCode
        {
            get { return m_companyCode; }
            set { m_companyCode = value; }
        }

        
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("NAME", typeof(System.String), false, false)]
        protected string m_name;
        [Required(ErrorMessage = "Company Name is required.")]
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ADDRESS", typeof(System.String), false, false)]
        protected string m_address;
        [Required(ErrorMessage = "Address is required.")]
        public string Address
        {
            get { return m_address; }
            set { m_address = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PHONE_NO", typeof(System.String), false, false)]
        protected string m_phoneNo;
        [Required(ErrorMessage = "Phone Number is required.")]
        [CustomValidationAttributes.Phone(ErrorMessage = "Invalid phone number format.")]
        public string PhoneNo
        {
            get { return m_phoneNo; }
            set { m_phoneNo = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("FAX_NO", typeof(System.String), false, true)]
        protected string m_faxNo;
        [CustomValidationAttributes.Fax(ErrorMessage = "Invalid fax number format.")]
        public string FaxNo
        {
            get { return m_faxNo; }
            set { m_faxNo = value; }
        }

        
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMAIL", typeof(System.String), false, true)]
        protected string m_email;
        [CustomValidationAttributes.Email(ErrorMessage = "Invalid email format.")]
        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("WEB_SITE", typeof(System.String), false, true)]
        protected string m_webSite;
        public string WebSite
        {
            get { return m_webSite; }
            set { m_webSite = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_DELETED", typeof(System.UInt64), false, false)]
        protected Int16 m_isDeleted;
        public Int16 IsDeleted
        {
            get { return m_isDeleted; }
            set { m_isDeleted = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(System.UInt64), false, true)]
        protected Int16 m_status;
        public Int16 Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_SHORT_NAME", typeof(System.String), false, true)]
        protected string m_companyShortName;
        public string CompanyShortName
        {
            get { return m_companyShortName; }
            set { m_companyShortName = value; }
        }
    }
}


