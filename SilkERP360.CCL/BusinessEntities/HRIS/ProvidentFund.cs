using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class ProvidentFund : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        #region CONSTRUCTOR
        public ProvidentFund()
        {
        }
        #endregion

        #region VALIDATION
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "PfAccountNo", Message = "Pf Account No Entry")]
    //[SilkERP360.CCL.Validation.Attributes.Required(FieldName = "PfPercentage", Message = "Pf Percentage Entry")]
    //[SilkERP360.CCL.Validation.Attributes.IntegerRange(FieldName = "PfPercentage", Message = "Pf Percentage Entry")]
    #endregion

        #region protected VARIABLES
        protected System.UInt64 m_uint64_PfCode;
        protected System.String m_str_PfAccountNo;
        protected System.Decimal m_dcm_PfPercentage;
        protected System.DateTime m_Dat_PfStartDate;
        protected System.Int16 m_int16_IsDeleted;
        protected System.Int16 m_int16_Status;

        #endregion

        #region PUBLIC PROPERTIES


        public System.UInt64 PfCode
        {
            get { return this.m_uint64_PfCode; }
            set { this.m_uint64_PfCode = value; }
        }
        public System.String PfAccountNo
        {
            get { return this.m_str_PfAccountNo; }
            set { this.m_str_PfAccountNo = value; }
        }
        public System.Decimal PfPercentage
        {
            get { return this.m_dcm_PfPercentage; }
            set { this.m_dcm_PfPercentage = value; }
        }
        public System.DateTime PfStartDate
        {
            get { return this.m_Dat_PfStartDate; }
            set { this.m_Dat_PfStartDate = value; }
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
