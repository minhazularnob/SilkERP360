using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.WPMS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("WPMS_CURRENCY", "SEQ_WPMS_CURRENCY")]
   public class Currency: SilkERP360.CCL.Validation.ValidationBase 
    {
       public Currency()
       { 
       }
       [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENCY_CODE", typeof(System.UInt64), false, false)]
       protected System.UInt64 m_ui64_CurrencyCode;

       public System.UInt64 CurrencyCode
       {
           get { return m_ui64_CurrencyCode; }
           set { m_ui64_CurrencyCode = value; }
       }
            [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENCY_NAME", typeof(System.UInt64), false, false)]
       protected System.String m_ui64_CurrencyName;

            public System.String CurrencyName
            {
                get { return m_ui64_CurrencyName; }
                set { m_ui64_CurrencyName = value; }
            }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CURRENCY_RATE", typeof(System.Decimal), false, false)]
            protected System.Decimal m_ui64_CurrencyRate;

        public System.Decimal CurrencyRate
        {
            get { return m_ui64_CurrencyRate; }
            set { m_ui64_CurrencyRate = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_ACTIVE", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enum_IsActive;

        public SilkERP360.CCL.Enums.YesNo IsActive
        {
            get { return m_enum_IsActive; }
            set { m_enum_IsActive = value; }
        }
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected System.DateTime m_dt_EntryDate;

        public System.DateTime EntryDate
        {
            get { return m_dt_EntryDate; }
            set { m_dt_EntryDate = value; }
        }
    }
}
