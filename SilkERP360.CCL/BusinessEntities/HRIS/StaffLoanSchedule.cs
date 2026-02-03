using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class StaffLoanSchedule
    {
        public StaffLoanSchedule() { }
        public UInt64? LoanScheduleCode { get; set; }
        public UInt64 LoanCode { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public decimal? ScheduledAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public int? Status { get; set; }
    }
}
