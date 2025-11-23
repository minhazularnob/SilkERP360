using SilkERP360.CCL.BusinessEntities.HRIS;
using SilkERP360.CCL.Enums;
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

        public ulong Save(CCL.BusinessEntities.HRIS.PromotionHistory promotionHistory)
        {
            if (!DateTime.TryParse(promotionHistory.EffectiveFrom, out DateTime effectiveDate))
                throw new ArgumentException("Invalid EffectiveFrom date.");

            if(promotionHistory.CurrentDesignationCode == promotionHistory.PreviousDesignationCode)
                throw new ArgumentException("Current Designation  and New Designation cannot be same.");

            return this.ExceptionManager.Process<ulong>(() =>
            {
                using (var dbManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (dbManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                        dbManager.InternalResource.Open();

                    // Check for duplicate promotion for the same employee on the same date
                    string checkSql = $"SELECT COUNT(*) AS CNT FROM PROMOTION_HISTORY " +
                                      $"WHERE EMPLOYEE_CODE = {promotionHistory.EmployeeCode} " +
                                      $"AND TRUNC(EFFECTIVE_FROM) = TO_DATE('{effectiveDate:yyyy-MM-dd}', 'YYYY-MM-DD')";

                    var reader = dbManager.InternalResource.ExecuteDataReader(checkSql);
                    reader.Read();
                    int count = int.Parse(reader["CNT"].ToString());
                    reader.Close();


                    if (count > 0)
                        throw new Exception("A record already exists for the same employee and date.");

                    // Get next sequence value
                    string seqSql = $"SELECT {promotionHistory.GetSequence()}.NEXTVAL AS ID FROM DUAL";
                    var seqReader = dbManager.InternalResource.ExecuteDataReader(seqSql);
                    seqReader.Read();
                    ulong promotionId = ulong.Parse(seqReader["ID"].ToString());
                    seqReader.Close();

                    promotionHistory.PromotionID = promotionId;

                    // Insert promotion history
                    string insertSql = promotionHistory.GenerateSqlInsert();
                    dbManager.InternalResource.ExecuteScalar(insertSql);

                    // Save approver details
                    if (promotionHistory.approverDetails != null && promotionHistory.approverDetails.Count > 0)
                    {
                        foreach (var approver in promotionHistory.approverDetails)
                        {
                            // Get next sequence value for approver
                            string seqSqlApprover = $"SELECT {approver.GetSequence()}.NEXTVAL AS ID FROM DUAL";
                            var seqReaderApprover = dbManager.InternalResource.ExecuteDataReader(seqSqlApprover);
                            seqReaderApprover.Read();
                            ulong approverID = ulong.Parse(seqReaderApprover["ID"].ToString());
                            seqReaderApprover.Close();

                            // Set approver properties
                            approver.Id = approverID;
                            approver.HistoryId = promotionId;
                            approver.Status = (int)PromotionStatus.Pending;

                            // Generate and execute insert SQL
                            string approverSql = approver.GenerateSqlInsert();
                            dbManager.InternalResource.ExecuteScalar(approverSql);
                        }
                    }

                    dbManager.InternalResource.CommitTransaction();
                    return promotionId;
                }
            }, "BMLExceptionPolicy");
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
                            item.PromotionID = Convert.ToUInt64(lcl_obj_dr["promotion_id"]);
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

        public List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> GetAllApprovers(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail>>(() =>
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
                        List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail> list =
                            new List<SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail>();

                        // If no rows → return empty list (not exception)
                        if (!lcl_obj_dr.HasRows)
                        {
                            return list;
                        }

                        // Populate list
                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.ApproverDetail();

                            // Safe parsing
                            item.EmployeeCode = Convert.ToUInt64(lcl_obj_dr["EMPLOYEE_CODE"]);
                            item.EmployeeId = lcl_obj_dr["EMPLOYEE_ID"]?.ToString();
                            item.EmployeeName = lcl_obj_dr["EMPLOYEE_NAME"]?.ToString();

                            list.Add(item);
                        }

                        return list;
                    }
                }
            }, "BMLExceptionPolicy");
        }
    }
}
