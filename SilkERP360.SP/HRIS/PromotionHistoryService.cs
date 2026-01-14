using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public System.UInt64 UpdatePromotionStatusForApprover(UInt64 IP_ui64_PromotionHistoryCode, UInt64 IP_ui64_ApproverCode, int status, string token =null)
        {
            System.UInt64 lcl_ui64_approver_detail_code = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_PromotionHistoryManager = new BML.HRIS.PromotionHistoryManager();
                System.UInt64 lcl_ui64_approverdetail_code_temp = lcl_obj_PromotionHistoryManager.UpdatePromotionStatusForApprover(IP_ui64_PromotionHistoryCode, IP_ui64_ApproverCode, status, token);
                return lcl_ui64_approverdetail_code_temp;
            }, "SPExceptionPolicy");
            return lcl_ui64_approver_detail_code;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> GetAllPromotionHistory(System.UInt64 IP_ui64_companyCode, UInt64 IP_ui64_user_employee_code, string from, string to)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_obj_Designation = null;
            lcl_obj_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select h.promotion_id,e.employee_code,e.employee_id,e.employee_name,h.previous_designation_code,
                                                                        h.current_designation_code,pd.degn_name PreviousDesName,nd.degn_name CurrentDesName,h.remarks,
                                                                        h.effective_from,h.company_code,h.ISAPPROVED,NVL(p.status, 0) as specificUserAppraval,
                                                                        CASE WHEN h.INCREMENT_CODE IS NULL THEN 'NO' ELSE 'YES' END AS IS_INCREMENTED from promotion_history h
                                                                        inner join employee e on h.employee_code = e.employee_code
                                                                        inner join designation pd on h.previous_designation_code = pd.designation_code
                                                                        inner join designation nd on h.current_designation_code = nd.designation_code
                                                                        left join promotion_approvers p on h.promotion_id = p.history_id and p.employee_code={1}
                                                                        where h.company_code = {0} and h.effective_from between TO_DATE('{2}', 'DD/MM/YYYY') and TO_DATE('{3}', 'DD/MM/YYYY') order by h.created_date asc", IP_ui64_companyCode, IP_ui64_user_employee_code, from, to);
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_DesignationManager = new SilkERP360.BML.HRIS.PromotionHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_obj_DesignationTmp =
                    lcl_obj_DesignationManager.GetAllPromotionHistory(lcl_str_SqlQuery);
                return lcl_obj_DesignationTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_Designation;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Notification> GetAllNotifications(System.UInt64 IP_ui64_companyCode)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Notification> lcl_obj_Notification = null;
            lcl_obj_Notification = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Notification>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select Employee_Code,Employee_Id,Employee_Name,is_deleted,confirmation_date,joining_date from employee where is_deleted=1 and employee_status=2 and company_code={0} AND confirmation_date >= TRUNC(SYSDATE)
                                                                        AND confirmation_date < TRUNC(SYSDATE)+7", IP_ui64_companyCode);
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_PromotionHistoryManager = new SilkERP360.BML.HRIS.PromotionHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Notification> lcl_obj_DesignationTmp = lcl_obj_PromotionHistoryManager.GetAllNotifications(lcl_str_SqlQuery);
                return lcl_obj_DesignationTmp;
            }, "SPExceptionPolicy");
            return lcl_obj_Notification;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> GetAllApprovers()
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> lcl_obj_approver_list = null;
            lcl_obj_approver_list = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail>>(() =>
            {
                System.String lcl_str_SqlQuery = System.String.Format(@"select e.employee_code,e.employee_id,e.employee_name from users u inner join employee e on u.employee_code = e.employee_code 
                                                                        where u.is_deleted =1 and e.employee_status = 0 and u.access_level = 5 order by e.employee_name asc");
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_PromotionHistoryManager = new SilkERP360.BML.HRIS.PromotionHistoryManager();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> lcl_obj_approverListTemp =
                    lcl_obj_PromotionHistoryManager.GetAllApprovers(lcl_str_SqlQuery);
                return lcl_obj_approverListTemp;
            }, "SPExceptionPolicy");
            return lcl_obj_approver_list;
        }
        public int GetTokenStatus(string token)
        {
            int isValid = 0;
            return isValid = this.ExceptionManager.Process<int>(() =>
            {
                string lcl_str_SqlQuery = $"SELECT IS_VALID FROM TOKENS WHERE TOKEN_ID = '{token}'";
                SilkERP360.BML.HRIS.PromotionHistoryManager lcl_obj_PromotionHistoryManager = new SilkERP360.BML.HRIS.PromotionHistoryManager();
                int isValidTemp = lcl_obj_PromotionHistoryManager.GetTokenStatus(lcl_str_SqlQuery);
                return isValidTemp;

            }, "SPExceptionPolicy");
        }
    }
}
