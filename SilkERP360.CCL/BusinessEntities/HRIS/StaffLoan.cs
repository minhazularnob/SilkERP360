using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.CCL.BusinessEntities.HRIS
{
    public class StaffLoan
    {
        public StaffLoan() { }
        public UInt64? LoanCode { get; set; } 
        public UInt64 EmployeeCode { get; set; }
        public string EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public decimal LoanAmount { get; set; }
        public int NoOfInstallments { get; set; }
        public int LoanType { get; set; }
        public string LoanDisburseDate { get; set; }
        public string EntryDate { get; set; }

        public int InstallmentStartMonth { get; set; }
        public int InstallmentStartYear { get; set; }
        public decimal CurrentDueAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }

        public int Status { get; set; }
        public List<StaffLoanSchedule> Installments { get; set; } = new List<StaffLoanSchedule>();
    }
}