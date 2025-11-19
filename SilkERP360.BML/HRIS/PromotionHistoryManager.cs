using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using System.Linq;
using System.Text;



namespace SilkERP360.BML.HRIS
{
   public class PromotionHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase


    {
       public PromotionHistoryManager()
       {
           //ExceptionManagement Initialization
           this.Initialize();
       }

        public ulong Save(CCL.BusinessEntities.HRIS.PromotionHistory lcl_obj_PromotionHistory)
        {
            System.UInt64 lcl_ui64_IncrementCode = 0;
            System.String lcl_str_SqlQuery = System.String.Format("SELECT {0}.NEXTVAL AS ID FROM DUAL", lcl_obj_PromotionHistory.GetSequence());
            lcl_ui64_IncrementCode = this.ExceptionManager.Process<System.UInt64>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_IDReader = lcl_obj_DBManager.InternalResource.ExecuteDataReader(lcl_str_SqlQuery);
                    lcl_obj_IDReader.Read();
                    System.UInt64 lcl_ui64_PROMOTION_ID = System.UInt64.Parse(lcl_obj_IDReader["ID"].ToString());
                    lcl_obj_IDReader.Close();

                    lcl_obj_PromotionHistory.PromotionID = lcl_ui64_PROMOTION_ID;
                    System.String lcl_str_SqlInsert = lcl_obj_PromotionHistory.GenerateSqlInsert();
                    lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlInsert);
                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_PROMOTION_ID;
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        public System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> GetAllPromotionHistory(string IP_str_SqlQuery)
        {
            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_objlist_Designation = null;
            lcl_objlist_Designation = this.ExceptionManager.Process<System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }
                    System.Data.OracleClient.OracleDataReader lcl_obj_dr = lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery); if (!(lcl_obj_dr.HasRows))
                    {
                        throw new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLException("Fatal Error (Designation.GetList(SqlQuery)) : No promotion History Data Found In The Database!!!");
                    }
                    System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> lcl_objlist_Tmp = new
                     System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>();
                    while (lcl_obj_dr.Read())
                    {
                        SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory lcl_obj_Tmp = new SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory();
                        lcl_obj_Tmp.EmployeeCode = System.UInt64.Parse(lcl_obj_dr["EMPLOYEE_CODE"].ToString());
                        lcl_obj_Tmp.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"].ToString();
                        lcl_obj_Tmp.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"].ToString();
                        lcl_obj_Tmp.PreviousDesignationCode = System.UInt64.Parse(lcl_obj_dr["PREVIOUS_DESIGNATION_CODE"].ToString());
                        lcl_obj_Tmp.CurrentDesignationCode = System.UInt64.Parse(lcl_obj_dr["CURRENT_DESIGNATION_CODE"].ToString());
                        lcl_obj_Tmp.PreviousDesignationName = (lcl_obj_dr["PREVIOUSDESNAME"].ToString());
                        lcl_obj_Tmp.CurentDesignationName = (lcl_obj_dr["CURRENTDESNAME"].ToString());
                        lcl_obj_Tmp.Remarks = (lcl_obj_dr["REMARKS"].ToString());
                        lcl_obj_Tmp.EffectiveFrom = (lcl_obj_dr["EFFECTIVE_FROM"].ToString());
                        lcl_objlist_Tmp.Add(lcl_obj_Tmp);
                    }
                    lcl_obj_dr.Close();
                    return lcl_objlist_Tmp;
                }
            }, "BMLExceptionPolicy");
            return lcl_objlist_Designation;
        }
    }
}
