using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("SALARY_INCREMENT", "SEQ_INCREMENT")]
    public class Increment : SilkERP360.CCL.Validation.ValidationBase
    {

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INCREMENT_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_IncrementCode;
        public System.UInt64 IncrementCode
        {
            get { return m_ui64_IncrementCode; }
            set { m_ui64_IncrementCode = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INCREMENT_MASTER_CODE", typeof(System.UInt64), true, false)]
        //protected System.UInt64 m_ui64_IncrementMasterCode;
        //public System.UInt64 IncrementMasterCode
        //{
        //    get { return m_ui64_IncrementMasterCode; }
        //    set { m_ui64_IncrementMasterCode = value; }
        //}
        
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INCREMENT_DATE", typeof(System.DateTime), true, false)]
        //protected System.DateTime m_dt_IncrementDate;
        //public System.DateTime IncrementDate
        //{
        //    get { return m_dt_IncrementDate; }
        //    set { m_dt_IncrementDate = value; }
        //}

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("PREVIOUS_GROSS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_PreviousGross;
        public System.Decimal PreviousGross
        {
            get { return m_dcm_PreviousGross; }
            set { m_dcm_PreviousGross = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INC_BASIC", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_IncBasic;
        public System.Decimal IncBasic
        {
            get { return m_dcm_IncBasic; }
            set { m_dcm_IncBasic = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INC_HOURSE_RENT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_IncHouseRent;
        public System.Decimal IncHouseRent
        {
            get { return m_dcm_IncHouseRent; }
            set { m_dcm_IncHouseRent = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INC_CONVEYENCE", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_IncConveyence;
        public System.Decimal IncConveyence
        {
            get { return m_dcm_IncConveyence; }
            set { m_dcm_IncConveyence = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INC_MEDICAL", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_IncMedical;
        public System.Decimal IncMedical
        {
            get { return m_dcm_IncMedical; }
            set { m_dcm_IncMedical = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INC_ENTERTAINMENT", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_IncEntertainment;
        public System.Decimal IncEntertainment
        {
            get { return m_dcm_IncEntertainment; }
            set { m_dcm_IncEntertainment = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INC_GROSS", typeof(System.Decimal), true, false)]
        protected System.Decimal m_dcm_IncGross;
        public System.Decimal IncGross
        {
            get { return m_dcm_IncGross; }
            set { m_dcm_IncGross = value; }
        }

        
        //[SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), true, false)]
        //protected System.DateTime m_dt_EntryDate;
        //public System.DateTime EntryDate
        //{
        //    get { return m_dt_EntryDate; }
        //    set { m_dt_EntryDate = value; }
        //}

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { m_ui64_EntryEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_MONTH", typeof(SilkERP360.CCL.Enums.Month), true, false)]
        protected SilkERP360.CCL.Enums.Month m_enm_EffectiveMonth;
        public SilkERP360.CCL.Enums.Month EffectiveMonth
        {
            get { return m_enm_EffectiveMonth; }
            set { m_enm_EffectiveMonth = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EFFECTIVE_YEAR", typeof(System.UInt32), true, false)]
        protected System.UInt32 m_ui32_EffectiveYear;
        public System.UInt32 EffectiveYear
        {
            get { return m_ui32_EffectiveYear; }
            set { m_ui32_EffectiveYear = value; }
        }
        
    }
}
