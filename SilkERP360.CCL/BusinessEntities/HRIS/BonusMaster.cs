using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("BONUS_MASTER", "SEQ_BONUS_MASTER")]
    public class BonusMaster : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BONUS_MASTER_CODE", typeof(System.UInt64), true, false)]
        private System.UInt64 m_ui64_BonusMasterCode;
        public System.UInt64 BonusMasterCode
        {
            get { return m_ui64_BonusMasterCode; }
            set { m_ui64_BonusMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), true, false)]
        private System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OCCASION", typeof(SilkERP360.CCL.Enums.BonusOccasion), true, false)]
        private SilkERP360.CCL.Enums.BonusOccasion m_enm_Occasion;
        public SilkERP360.CCL.Enums.BonusOccasion Occasion
        {
            get { return m_enm_Occasion; }
            set { m_enm_Occasion = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("MONTH", typeof(SilkERP360.CCL.Enums.Month), true, false)]
        private SilkERP360.CCL.Enums.Month m_enm_Month;
        public SilkERP360.CCL.Enums.Month Month
        {
            get { return m_enm_Month; }
            set { m_enm_Month = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("YEAR", typeof(System.UInt32), true, false)]
        private System.UInt32 m_ui32_Year;
        public System.UInt32 Year
        {
            get { return m_ui32_Year; }
            set { m_ui32_Year = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("BONUS_DATE", typeof(System.DateTime), true, false)]
        private System.DateTime m_dt_BonusDate;
        public System.DateTime BonusDate
        {
            get { return m_dt_BonusDate; }
            set { m_dt_BonusDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), true, false)]
        private System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return m_dt_EntryDate; }
            set { m_dt_EntryDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), true, false)]
        private System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return m_ui64_EntryEmployeeCode; }
            set { m_ui64_EntryEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REMARKS", typeof(System.String), true, false)]
        private System.String m_str_Remarks;
        public System.String Remarks
        {
            get { return m_str_Remarks; }
            set { m_str_Remarks = value; }
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Bonus> BonusList { get; set; }
    }
}
