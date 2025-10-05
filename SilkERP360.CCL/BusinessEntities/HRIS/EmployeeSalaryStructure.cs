using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
   public class EmployeeSalaryStructure : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public EmployeeSalaryStructure()
        {
        }
        #endregion

        #region VALIDATION
    [SilkERP360.CCL.Validation.Attributes.Required(FieldName = "Basic", Message = "Basic Entry")]
    #endregion
       
       #region protected VARIABLES
        protected System.UInt64 m_uint64_SalaryStructureCode;
        protected System.UInt64 m_uint64_EmployeeCode;
        protected System.Decimal m_dcm_Basic;
        protected System.Decimal m_dcm_HouseRent;
        protected System.Decimal m_dcm_Medical;
        protected System.Decimal m_dcm_Entertainment;
        protected System.Decimal m_dcm_Conveyence;
        protected System.Decimal m_dcm_PhoneBill;
        protected System.Decimal m_dcm_Others;
        protected System.Decimal m_dcm_Gross;
        protected System.DateTime m_Dat_EffectiveFrom;
        protected System.DateTime m_Dat_EffectiveUpto;
        protected System.Int16 m_int16_IsDeleted;
        protected System.Int16 m_int16_Status;

        #endregion

        #region PUBLIC PROPERTIES

        public System.UInt64 SalaryStructureCode
        {
            get { return this.m_uint64_SalaryStructureCode; }
            set { this.m_uint64_SalaryStructureCode = value; }
        }
        public System.UInt64 EmployeeCode
        {
            get { return this.m_uint64_EmployeeCode; }
            set { this.m_uint64_EmployeeCode = value; }
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
            get { return this.m_Dat_EffectiveFrom; }
            set { this.m_Dat_EffectiveFrom = value; }
        }
        public System.DateTime EffectiveUpto
        {
            get { return this.m_Dat_EffectiveUpto; }
            set { this.m_Dat_EffectiveUpto = value; }
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
