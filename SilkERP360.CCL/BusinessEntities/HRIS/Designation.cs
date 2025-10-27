using SilkERP360.CCL.BusinessEntities.HRIS.Base;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("DESIGNATION", "SEQ_DESIGNATION")]
    public class Designation : DesignationCore
    {

        public Designation()
        {
            IsDeleted = 1;
            Status = (ushort)SilkERP360.CCL.Enums.Status.Active;
            IsOtEligible = 1;
            Rank = 10;
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DESIGNATION_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_DesignationCode;
        public System.UInt64 DesignationCode
        {
            get { return this.m_ui64_DesignationCode; }
            set { this.m_ui64_DesignationCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("DEGN_NAME", typeof(System.String), false, false)]
        protected System.String m_str_DegnName;
        [Required(ErrorMessage = "Designation Name is required.")]
        [CustomValidationAttributes.NoSpecialCharacters(ErrorMessage = "Remove special characters from designation name.")]
        public System.String DegnName
        {
            get { return this.m_str_DegnName; }
            set { this.m_str_DegnName = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SHORT_NAME", typeof(System.String), false, true)]
        protected System.String m_str_ShortName;
        public System.String ShortName
        {
            get { return this.m_str_ShortName; }
            set { this.m_str_ShortName = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), false, true)]
        protected System.UInt64 m_ui64_CompanyCode;
        [Required(ErrorMessage = "Company Code is required.")]
        public System.UInt64 CompanyCode
        {
            get { return this.m_ui64_CompanyCode; }
            set { this.m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BASIC", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_Basic;
        [Required(ErrorMessage = "Basic is required.")]
        public System.Decimal Basic
        {
            get { return this.m_dcm_Basic; }
            set { this.m_dcm_Basic = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HOUSE_RENT", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_HouseRent;
        [Required(ErrorMessage = "House Rent is required.")]
        public System.Decimal HouseRent
        {
            get { return this.m_dcm_HouseRent; }
            set { this.m_dcm_HouseRent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MEDICAL", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_Medical;
        [Required(ErrorMessage = "Medical is required.")]
        public System.Decimal Medical
        {
            get { return this.m_dcm_Medical; }
            set { this.m_dcm_Medical = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTERTAINMENT", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_Entertainment;
        [Required(ErrorMessage = "Entertainment is required.")]
        public System.Decimal Entertainment
        {
            get { return this.m_dcm_Entertainment; }
            set { this.m_dcm_Entertainment = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CONVEYENCE", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_Conveyence;
        [Required(ErrorMessage = "Conveyence is required.")]
        public System.Decimal Conveyence
        {
            get { return this.m_dcm_Conveyence; }
            set { this.m_dcm_Conveyence = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PHONE_BILL", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_PhoneBill;
        [Required(ErrorMessage = "Phone Bill is required.")]
        public System.Decimal PhoneBill
        {
            get { return this.m_dcm_PhoneBill; }
            set { this.m_dcm_PhoneBill = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OTHERS", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_Others;
        [Required(ErrorMessage = "Others is required.")]
        public System.Decimal Others
        {
            get { return this.m_dcm_Others; }
            set { this.m_dcm_Others = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("GROSS", typeof(System.Decimal), false, false)]
        protected System.Decimal m_dcm_Gross;
        [Required(ErrorMessage = "Gross is required.")]
        public System.Decimal Gross
        {
            get { return this.m_dcm_Gross; }
            set { this.m_dcm_Gross = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_FROM", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_EffectiveFrom;
        [Required(ErrorMessage = "Effective From is required.")]
        public System.DateTime EffectiveFrom
        {
            get { return this.m_dt_EffectiveFrom; }
            set { this.m_dt_EffectiveFrom = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_DELETED", typeof(System.UInt64), false, false)]
        protected System.UInt16 m_ui16_IsDeleted;
        public System.UInt16 IsDeleted
        {
            get { return m_ui16_IsDeleted; }
            set { this.m_ui16_IsDeleted = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_Status;
        public System.UInt16 Status
        {
            get { return this.m_ui16_Status; }
            set { this.m_ui16_Status = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_OT_ELIGABLE", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_IsOtEligible;
        public System.UInt16 IsOtEligible
        {
            get { return this.m_ui16_IsOtEligible; }
            set { this.m_ui16_IsOtEligible = value; }
        }


        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("RANK", typeof(System.UInt16), false, false)]
        protected System.UInt16 m_ui16_Rank;
        public System.UInt16 Rank
        {
            get { return this.m_ui16_Rank; }
            set { this.m_ui16_Rank = value; }
        }
    }
}
