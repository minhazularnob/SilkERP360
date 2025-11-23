using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    [SilkERP360.CCL.DatabaseMapping.DatabaseEntityMapping("promotion_approvers", "SEQ_PROMOTION_APPROVERS")]
    public class ApproverDetail: ValidationBase
    {
        public ApproverDetail()
        {

        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("ID", typeof(System.UInt64), true, false)]
        protected UInt64 m_id;
        public UInt64 Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("HISTORY_ID", typeof(System.UInt16), false, false)]
        protected UInt64 m_historyId;
        [Required(ErrorMessage = "History ID is required.")]
        public UInt64 HistoryId
        {
            get { return m_historyId; }
            set { m_historyId = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("EMPLOYEE_CODE", typeof(System.Int64), false, false)]
        protected UInt64 m_employeeCode;
        [Required(ErrorMessage = "Employee code is required.")]
        public UInt64 EmployeeCode
        {
            get { return m_employeeCode; }
            set { m_employeeCode = value; }
        }

        [SilkERP360.CCL.DatabaseMapping.DatabaseColumnMapping("STATUS", typeof(System.UInt16), false, false)]
        protected UInt16 m_status;
        [Required(ErrorMessage = "Status is required.")]
        public UInt16 Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }


    }
}
