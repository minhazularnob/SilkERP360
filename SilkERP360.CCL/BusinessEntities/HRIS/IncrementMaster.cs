using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("INCREMENT_MASTER", "SEQ_INCREMENT")]
    public class IncrementMaster : SilkERP360.CCL.Validation.ValidationBase
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("INCREMENT_MASTER_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_IncrementMasterCode;
        public System.UInt64 IncrementMasterCode
        {
            get { return m_ui64_IncrementMasterCode; }
            set { m_ui64_IncrementMasterCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("COMPANY_CODE", typeof(System.UInt64), true, false)]
        protected System.UInt64 m_ui64_CompanyCode;
        public System.UInt64 CompanyCode
        {
            get { return m_ui64_CompanyCode; }
            set { m_ui64_CompanyCode = value; }
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

        protected System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> m_objLst_Increment;
        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Increment> IncrementList
        {
            get { return m_objLst_Increment; }
            set { m_objLst_Increment = value; }
        }

    }
}
