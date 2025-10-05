using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.BML.HRIS
{
    public class LeaveApprovedRecommendManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase,
          SilkERP360.CCL.Interfaces.IManagerOperations<SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender>
    {
        
            public LeaveApprovedRecommendManager()
            {
                this.Initialize();
            }
            public object GetList(string IP_str_SqlQuery, object IP_obj_DBManager)
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender> lcl_list_details = null;
                lcl_list_details = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender>>(() =>
                {
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        return null;
                    }
                    System.Data.OracleClient.OracleDataReader dr = lcl_obj_DBManager.ExecuteDataReader(IP_str_SqlQuery);
                    dr.Read(); if (dr.HasRows == false)
                    {
                        return null;
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender> lcl_obj_ListTmp = new System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender>();
                    while (dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender lcl_obj = new SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender();
                        lcl_obj.LeaveRecommenderCode = System.Decimal.Parse(dr["LEAVE_RECOMMENDER_CODE"].ToString());
                        lcl_obj.ApproverRecommenderCode = System.Decimal.Parse(dr["APPROVER_RECOMMENDER_CODE"].ToString());
                        lcl_obj.DepartmentCode = System.Decimal.Parse(dr["DEPARTMENT_CODE"].ToString());
                        lcl_obj.IsDeleted = System.Decimal.Parse(dr["IS_DELETED"].ToString());
                        lcl_obj.Status = System.Decimal.Parse(dr["STATUS"].ToString());
                        lcl_obj.IsApprover = System.Decimal.Parse(dr["IS_APPROVER"].ToString());
                        lcl_obj.IsRecommender = System.Decimal.Parse(dr["IS_RECOMMENDER"].ToString());
                        lcl_obj_ListTmp.Add(lcl_obj);
                    }
                    return lcl_obj_ListTmp;
                }, "BMLExceptionPolicy");
                return lcl_list_details;
            }
            public ulong Save(object IP_obj_Object, object IP_obj_DBManager)
            {
                SilkERP360.DAL.DBManager lcl_obj_DBManager = (SilkERP360.DAL.DBManager)IP_obj_DBManager;
                SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender lcl_obj = (SilkERP360.CCL.BusinessEntities.HRIS.LeaveApproverRecommender)IP_obj_Object;
                System.UInt64 lcl_ui64_Return = 0;
                return lcl_ui64_Return = this.ExceptionManager.Process<System.UInt64>(() =>
                {
                    if (lcl_obj_DBManager.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        return 0;
                    }
                    if (lcl_obj.Validate() == false)
                    {
                        return 0;
                    }
                    System.Data.OracleClient.OracleParameter lcl_obj_LeaveRecommenderCode = new System.Data.OracleClient.OracleParameter("v_LEAVE_RECOMMENDER_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_LeaveRecommenderCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_LeaveRecommenderCode.Value = lcl_obj.LeaveRecommenderCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_ApproverRecommenderCode = new System.Data.OracleClient.OracleParameter("v_APPROVER_RECOMMENDER_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_ApproverRecommenderCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_ApproverRecommenderCode.Value = lcl_obj.ApproverRecommenderCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_DepartmentCode = new System.Data.OracleClient.OracleParameter("v_DEPARTMENT_CODE", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_DepartmentCode.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_DepartmentCode.Value = lcl_obj.DepartmentCode;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsDeleted = new System.Data.OracleClient.OracleParameter("v_IS_DELETED", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsDeleted.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsDeleted.Value = lcl_obj.IsDeleted;
                    System.Data.OracleClient.OracleParameter lcl_obj_Status = new System.Data.OracleClient.OracleParameter("v_STATUS", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_Status.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_Status.Value = lcl_obj.Status;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsApprover = new System.Data.OracleClient.OracleParameter("v_IS_APPROVER", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsApprover.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsApprover.Value = lcl_obj.IsApprover;
                    System.Data.OracleClient.OracleParameter lcl_obj_IsRecommender = new System.Data.OracleClient.OracleParameter("v_IS_RECOMMENDER", System.Data.OracleClient.OracleType.Number);
                    lcl_obj_IsRecommender.Direction = System.Data.ParameterDirection.Input;
                    lcl_obj_IsRecommender.Value = lcl_obj.IsRecommender;
                    System.Data.OracleClient.OracleParameter[] lcl_obj_SP_Parameters = { lcl_obj_LeaveRecommenderCode, lcl_obj_ApproverRecommenderCode, lcl_obj_DepartmentCode, lcl_obj_IsDeleted, lcl_obj_Status, lcl_obj_IsApprover, lcl_obj_IsRecommender, };
                    lcl_obj_DBManager.ExecuteStoredProcedure("HRIS.LeaveApproverRecommender_IU", lcl_obj_SP_Parameters);
                    return System.UInt64.Parse(lcl_obj_LeaveRecommenderCode.Value.ToString());
                }, "BMLExceptionPolicy");
            }
        }
    }

