using SilkERP360.CCL.BusinessEntities.HRIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class EmployeeTaxService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public EmployeeTaxService()
        {
            this.Initialize();
        }

        public System.UInt64 SaveEmployeeTax(List<EmployeeTax> employeeTaxes)
        {
            System.UInt64 lcl_ui64_promotionHistoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.EmployeeTaxManager lcl_obj_PromotionHistoryManager = new BML.HRIS.EmployeeTaxManager();
                System.UInt64 lcl_ui64_PromotionHistoryCodeTemp = lcl_obj_PromotionHistoryManager.SaveEmployeeTax(employeeTaxes);
                return lcl_ui64_PromotionHistoryCodeTemp;
            }, "SPExceptionPolicy");
            return lcl_ui64_promotionHistoryCode;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> GetEmployeeTaxList(System.UInt64 IP_ui64_companyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> lcl_obj_EmployeeTax = null;
            lcl_obj_EmployeeTax = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT e.employee_code, e.employee_id, e.employee_name, t.tax_code, NVL(t.is_tax_deduction, 0) AS is_tax_deduction,
                                                                        NVL(t.tax_amount, 0) AS tax_amount,s.basic,s.gross FROM employee e
                                                                        LEFT JOIN employee_tax t ON e.employee_code = t.employee_code
                                                                        left join employee_salary_structure s on e.employee_code=s.employee_code
                                                                        WHERE e.employee_status IN (0, 1, 2) AND e.company_code = {0} AND e.e_tin_eligible = 1 order by s.gross desc", IP_ui64_companyCode);
                SilkERP360.BML.HRIS.EmployeeTaxManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.EmployeeTaxManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.EmployeeTax> lcl_obj_EmployeeTaxTemp =  lcl_obj_DesignationManager.GetEmployeeTaxList(lcl_str_SqlQuery);
                return lcl_obj_EmployeeTaxTemp;
            }, "SPExceptionPolicy");
            return lcl_obj_EmployeeTax;
        }
    }
}