using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class StaffLoanService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public StaffLoanService()
        {
            this.Initialize();
        }

        public System.UInt64 SaveStaffLoan(StaffLoan staffLoan)
        {
            System.UInt64 lcl_ui64_loanCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.StaffLoanManager lcl_obj_staffLoanManager = new BML.HRIS.StaffLoanManager();
                System.UInt64 lcl_ui64_loanCodeTemp = lcl_obj_staffLoanManager.SaveStaffLoan(staffLoan);
                return lcl_ui64_loanCodeTemp;
            }, "SPExceptionPolicy");
            return lcl_ui64_loanCode;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan> GetEmployeeLoanList(System.UInt64 IP_ui64_companyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan> lcl_obj_EmployeeLoan = null;
            lcl_obj_EmployeeLoan = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select e.employee_name,e.employee_id,sl.*,(sl.loan_amount-sl.current_due_amount)as total_paid_amount from staff_loan sl inner join employee e on sl.employee_code=e.employee_code where e.company_code = {0}  order by sl.Loan_disburse_date asc", IP_ui64_companyCode);
                SilkERP360.BML.HRIS.StaffLoanManager lcl_obj_loanManager = new SilkERP360.BML.HRIS.StaffLoanManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.StaffLoan> lcl_obj_EmployeeLoanTemp = lcl_obj_loanManager.GetEmployeeLoanList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeLoanTemp;
            }, "SPExceptionPolicy");
            return lcl_obj_EmployeeLoan;
        }
    }
}