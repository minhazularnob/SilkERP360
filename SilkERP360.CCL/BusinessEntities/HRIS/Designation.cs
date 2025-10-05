using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class Designation : SilkERP360.CCL.BusinessEntities.HRIS.Base.DesignationCore
    {
        #region CONSTRUCTOR
        public Designation()
        {
        }

        #endregion

        #region VALIDATION
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "DegnName", Message = "Degn Name Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Gross", Message = "Gross Entry")]
  
    #endregion


        #region protected VARIABLES
        protected System.UInt64 m_ui64_DesignationCode;
        protected System.String m_str_DegnName;
        protected System.String m_str_ShortName;
        protected System.UInt64 m_ui64_CompanyCode;
        protected System.Decimal m_dcm_Basic;
        protected System.Decimal m_dcm_HouseRent;
        protected System.Decimal m_dcm_Medical;
        protected System.Decimal m_dcm_Entertainment;
        protected System.Decimal m_dcm_Conveyence;
        protected System.Decimal m_dcm_PhoneBill;
        protected System.Decimal m_dcm_Others;
        protected System.Decimal m_dcm_Gross;
        protected System.DateTime m_dt_EffectiveFrom;
        protected System.UInt16 m_ui16_IsOtEligible;
        protected System.UInt16 m_ui16_IsDeleted;
        protected System.UInt16 m_ui16_Status;
        #endregion


        #region PUBLIC PROPERTIES
        public System.UInt64 DesignationCode
        {
            get { return this.m_ui64_DesignationCode; }
            set { this.m_ui64_DesignationCode = value; }
        }
        public System.String DegnName
        {
            get { return this.m_str_DegnName; }
            set { this.m_str_DegnName = value; }
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
        public System.Decimal Basic
        {
            get { return this.m_dcm_Basic; }
            set { this.m_dcm_Basic = value; }
        }
        public System.Decimal HouseRent
        {
            get { return this.m_dcm_HouseRent; }
            set { this.m_dcm_HouseRent = value; }
        }
        public System.Decimal Medical
        {
            get { return this.m_dcm_Medical; }
            set { this.m_dcm_Medical = value; }
        }
        public System.Decimal Entertainment
        {
            get { return this.m_dcm_Entertainment; }
            set { this.m_dcm_Entertainment = value; }
        }
        public System.Decimal Conveyence
        {
            get { return this.m_dcm_Conveyence; }
            set { this.m_dcm_Conveyence = value; }
        }
        public System.Decimal PhoneBill
        {
            get { return this.m_dcm_PhoneBill; }
            set { this.m_dcm_PhoneBill = value; }
        }
        public System.Decimal Others
        {
            get { return this.m_dcm_Others; }
            set { this.m_dcm_Others = value; }
        }
        public System.Decimal Gross
        {
            get { return this.m_dcm_Gross; }
            set { this.m_dcm_Gross = value; }
        }
        public System.DateTime EffectiveFrom
        {
            get { return this.m_dt_EffectiveFrom; }
            set { this.m_dt_EffectiveFrom = value; }
        }
        public System.UInt16 IsOtEligible
        {
            get { return this.m_ui16_IsOtEligible; }
            set { this.m_ui16_IsOtEligible = value; }
        }
        public System.UInt16 IsDeleted
        {
            get { return m_ui16_IsDeleted; }
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
