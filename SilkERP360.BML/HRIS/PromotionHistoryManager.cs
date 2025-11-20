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

                    // 3️⃣ Update Employee Designation if EffectiveFrom is today
                    DateTime effectiveDate;

                    if (DateTime.TryParse(lcl_obj_PromotionHistory.EffectiveFrom, out effectiveDate))
                    {
                        if (effectiveDate.Date == DateTime.Now.Date)
                        {
                            string lcl_str_SqlUpdate = string.Format("UPDATE EMPLOYEE SET DESIGNATION_CODE = {0} WHERE EMPLOYEE_CODE = {1}",lcl_obj_PromotionHistory.CurrentDesignationCode,lcl_obj_PromotionHistory.EmployeeCode);

                            lcl_obj_DBManager.InternalResource.ExecuteScalar(lcl_str_SqlUpdate);
                        }
                    }

                    lcl_obj_DBManager.InternalResource.CommitTransaction();
                    return lcl_ui64_PROMOTION_ID;   
                }
            }, "BMLExceptionPolicy");
            return lcl_ui64_IncrementCode;
        }

        public List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> GetAllPromotionHistory(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (System.Data.OracleClient.OracleDataReader lcl_obj_dr =
                           lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory> list =
                            new List<SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory>();

                        // If no rows → return empty list (not exception)
                        if (!lcl_obj_dr.HasRows)
                        {
                            return list;
                        }

                        // Populate list
                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.PromotionHistory();

                            // Safe parsing
                            item.EmployeeCode = Convert.ToUInt64(lcl_obj_dr["EMPLOYEE_CODE"]);
                            item.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"]?.ToString();
                            item.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"]?.ToString();

                            item.PreviousDesignationCode = Convert.ToUInt64(lcl_obj_dr["PREVIOUS_DESIGNATION_CODE"]);
                            item.CurrentDesignationCode = Convert.ToUInt64(lcl_obj_dr["CURRENT_DESIGNATION_CODE"]);

                            item.PreviousDesignationName = lcl_obj_dr["PREVIOUSDESNAME"]?.ToString();
                            item.CurentDesignationName = lcl_obj_dr["CURRENTDESNAME"]?.ToString();
                            item.Remarks = lcl_obj_dr["REMARKS"]?.ToString();

                            // EffectiveFrom stored as string
                            item.EffectiveFrom = lcl_obj_dr["EFFECTIVE_FROM"]?.ToString();

                            list.Add(item);
                        }

                        return list;
                    }
                }
            }, "BMLExceptionPolicy");
        }

    }
}
