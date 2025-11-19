using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public class PromotionHistoryService : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public PromotionHistoryService()
        {
            this.Initialize();
        }

        public System.UInt64 SavePromotionHistory(SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory Ip_Obj_PromotionHistory)
        {
            System.UInt64 lcl_ui64_promotionHistoryCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_PromotionHistoryManager = new BML.HRIS.PromotionHistoryManager();
                System.UInt64 lcl_ui64_PromotionHistoryCodeTemp = lcl_obj_PromotionHistoryManager.Save(Ip_Obj_PromotionHistory);
                return lcl_ui64_PromotionHistoryCodeTemp;
            }, "SPExceptionPolicy");
            return lcl_ui64_promotionHistoryCode;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> GetAllPromotionHistory(System.UInt64 IP_ui64_companyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select e.employee_code,e.employee_id,e.employee_name,h.previous_designation_code,h.current_designation_code,pd.degn_name PreviousDesName,nd.degn_name CurrentDesName,h.remarks,h.effective_from,h.company_code from promotion_history h
                                                                        inner join employee e on h.employee_code = e.employee_code
                                                                        inner join designation pd on h.previous_designation_code = pd.designation_code
                                                                        inner join designation nd on h.current_designation_code = nd.designation_code where h.company_code = {0} order by h.created_date desc", IP_ui64_companyCode);
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.PromotionHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_obj_DesignationTmp =
                    lcl_obj_DesignationManager.GetAllPromotionHistory(lcl_str_SqlQuery);
                return lcl_obj_DesignationTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_Designation;
        }
    }
}
