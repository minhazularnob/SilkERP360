using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("EMPLOYEE_LEAVE_ACCOUNT", "SEQ_EMP_LEAVE_ACCOUNT")]
    public class EmployeeLeaveAccount : SilkERP360.CCL.Validation.ValidationBase
    {
        public EmployeeLeaveAccount()
        {
            
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("LEAVE_ACCOUNT_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_LeaveAccountCode;
        public System.UInt64 LeaveAccountCode
        {
            get { return this.m_ui64_LeaveAccountCode; }
            set { this.m_ui64_LeaveAccountCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.UInt64), false, false)]
        protected System.UInt64 m_ui64_EmployeeCode;
        public System.UInt64 EmployeeCode
        {
            get { return this.m_ui64_EmployeeCode; }
            set { this.m_ui64_EmployeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("CL", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_CL;
        public System.UInt32 CL
        {
            get { return m_ui32_CL; }
            set { m_ui32_CL = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("SL", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_SL;
        public System.UInt32 SL
        {
            get { return m_ui32_SL; }
            set { m_ui32_SL = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EL", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_EL;
        public System.UInt32 EL
        {
            get { return m_ui32_EL; }
            set { m_ui32_EL = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ML", typeof(System.UInt32), false, false)]
        protected System.UInt32 m_ui32_ML;
        public System.UInt32 ML
        {
            get { return m_ui32_ML; }
            set { m_ui32_ML = value; }
        }
    }
}
