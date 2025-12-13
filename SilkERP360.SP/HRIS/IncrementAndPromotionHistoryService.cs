using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.SP.HRIS
{
    public class IncrementAndPromotionHistoryService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public IncrementAndPromotionHistoryService()
        {
            this.Initialize();
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory> GetAllApprovedIncrementAndPromotionHistory(System.UInt64 IP_ui64_companyCode, string from, string to)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory> lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"SELECT e.employee_code,e.employee_id, e.employee_name,pd.degn_name as previous_designation,nd.degn_name as new_designation,ph.effective_from as promotionEffectiveFrom,  CASE
                                    WHEN ph.promotion_id IS NOT NULL
                                     AND ph.increment_code IS NOT NULL THEN 'PROMOTION & INCREMENT'
                                    WHEN ph.promotion_id IS  not NULL and ph.increment_code is null THEN 'PROMOTION'
                                    WHEN ph.promotion_id IS NULL THEN 'INCREMENT'
                                END AS record_type,
                                sir.previous_gross,sir.inc_gross,sir.inc_basic,sir.inc_hourse_rent,sir.inc_conveyence,sir.inc_medical,sir.inc_entertainment,sir.effective_month as IncrementEffectiveMonth,sir.effective_year as IncrementEffectiveYear
                            FROM promotion_history ph
                            FULL OUTER JOIN salary_increment_request sir ON ph.increment_code = sir.increment_code
                            left join designation pd on ph.previous_designation_code = pd.designation_code
                            left join designation nd on ph.current_designation_code = nd.designation_code
                            LEFT JOIN employee e
                                ON e.employee_code = COALESCE(ph.employee_code, sir.employee_code) where e.company_code={0} AND (
                                  (ph.effective_from IS NOT NULL AND ph.effective_from BETWEEN TO_DATE('{1}','DD/MM/YYYY') AND TO_DATE('{2}','DD/MM/YYYY'))
                                  OR
                                  (sir.effective_month IS NOT NULL 
                                   AND sir.effective_year IS NOT NULL
                                   AND REGEXP_LIKE(sir.effective_month,'^\d+$')
                                   AND REGEXP_LIKE(sir.effective_year,'^\d+$')
                                   AND TO_DATE(LPAD(sir.effective_month,2,'0') || '/01/' || sir.effective_year,'MM/DD/YYYY')
                                       BETWEEN TO_DATE('{1}','DD/MM/YYYY') 
                                           AND TO_DATE('{2}','DD/MM/YYYY'))) and (ph.isapproved= 2 or sir.is_approved = 2) order by e.employee_name asc", IP_ui64_companyCode, from, to);
                SilkERP360.BML.HRIS.IncrementAndPromotionHistoryManager lcl_obj_incrementAndPromotionHistoryManager = new SilkERP360.BML.HRIS.IncrementAndPromotionHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory> lcl_obj_DesignationTmp =
                    lcl_obj_incrementAndPromotionHistoryManager.GetAllApprovedIncrementAndPromotionHistory(lcl_str_SqlQuery);
                return lcl_obj_DesignationTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_Designation;
        }
    }
}