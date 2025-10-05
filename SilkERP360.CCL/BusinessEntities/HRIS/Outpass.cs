using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("OUT_PASS", "SEQ_OUT_PASS")]
    public class Outpass : SilkERP360.CCL.Validation.ValidationBase
    {
        public Outpass()
        {
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUT_PASS_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_OutpassCode;
        public System.UInt64 OutpassCode
        {
            get { return this.m_ui64_OutpassCode; }
            set { this.m_ui64_OutpassCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return this.m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUT_PASS_TYPE", typeof(SilkERP360.CCL.Enums.OutpassType), false, false)]
        protected SilkERP360.CCL.Enums.OutpassType m_enm_OutpassType;
        public SilkERP360.CCL.Enums.OutpassType OutpassType
        {
            get { return this.m_enm_OutpassType; }
            set { this.m_enm_OutpassType = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUT_PASS_DATE", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_OutpassDate;
        public System.DateTime OutpassDate
        {
            get { return this.m_dt_OutpassDate; }
            set { this.m_dt_OutpassDate = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("OUT_DATE_TIME", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_OutDateTime;
        public System.DateTime OutDateTime
        {
            get { return this.m_dt_OutDateTime; }
            set { this.m_dt_OutDateTime = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("IN_DATE_TIME", typeof(System.DateTime), false, false)]
        protected System.DateTime m_dt_InDateTime;
        public System.DateTime InDateTime
        {
            get { return this.m_dt_InDateTime; }
            set { this.m_dt_InDateTime = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("REASON", typeof(System.String), false, false)]
        protected System.String m_str_Reason;
        public System.String Reason
        {
            get { return this.m_str_Reason; }
            set { this.m_str_Reason = value; }
        }
    }
}
