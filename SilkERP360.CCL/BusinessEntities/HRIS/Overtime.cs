using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("OVERTIME", "SEQ_OVERTIME")]
    public class Overtime : SilkERP360.CCL.BusinessEntities.HRIS.Base.EmployeeCore
    {
        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OVERTIME_CODE",typeof(System.UInt64),true,false)]
        protected System.UInt64 m_ui64_OvertimeCode;
        public System.UInt64 OvertimeCode
        {
            get { return m_ui64_OvertimeCode; }
            set { m_ui64_OvertimeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OT_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_OvertimeDate;
        public System.DateTime OvertimeDate
        {
            get { return this.m_dt_OvertimeDate; }
            set { this.m_dt_OvertimeDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OT_HOUR", typeof(System.Double), false, false)]
        protected System.Double m_dbl_OvertimeHour;
        public System.Double OvertimeHour
        {
            get { return m_dbl_OvertimeHour; }
            set { m_dbl_OvertimeHour = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IS_PROCESSED", typeof(SilkERP360.CCL.Enums.YesNo), false, false)]
        protected SilkERP360.CCL.Enums.YesNo m_enm_IsProcessed;
        public SilkERP360.CCL.Enums.YesNo IsProcessed
        {
            get { return this.m_enm_IsProcessed; }
            set { this.m_enm_IsProcessed = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EntryEmployeeCode;
        public System.UInt64 EntryEmployeeCode
        {
            get { return this.m_ui64_EntryEmployeeCode; }
            set { this.m_ui64_EntryEmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ENTRY_DATE", typeof(System.DateTime), false, false,SilkERP360.CCL.DatabaseMapping.DateTimeFormat.DateAndTime)]
        protected System.DateTime m_dt_EntryDate;
        public System.DateTime EntryDate
        {
            get { return this.m_dt_EntryDate; }
            set { this.m_dt_EntryDate = value; }
        }
    }
}
