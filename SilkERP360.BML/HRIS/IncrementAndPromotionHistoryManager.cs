using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.BML.HRIS
{
    public class IncrementAndPromotionHistoryManager : SilkERP360.CCL.ExceptionManagement.Base.ExceptionManagementBase
    {
        public IncrementAndPromotionHistoryManager()
        {
            this.Initialize();
        }

        public List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory> GetAllApprovedIncrementAndPromotionHistory(string IP_str_SqlQuery)
        {
            return this.ExceptionManager.Process<List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory>>(() =>
            {
                using (var lcl_obj_DBManager = SilkERP360.DAL.DALObjectPoolManager.DBManagerPool.GetObject())
                {
                    if (lcl_obj_DBManager.InternalResource.ConnectionState != System.Data.ConnectionState.Open)
                    {
                        lcl_obj_DBManager.InternalResource.Open();
                    }

                    // Execute reader
                    using (Oracle.ManagedDataAccess.Client.OracleDataReader lcl_obj_dr =
                           lcl_obj_DBManager.InternalResource.ExecuteDataReader(IP_str_SqlQuery))
                    {
                        List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory> list =
                            new List<SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory>();

                        // If no rows → return empty list (not exception)
                        if (!lcl_obj_dr.HasRows)
                        {
                            return list;
                        }

                        // Populate list
                        while (lcl_obj_dr.Read())
                        {
                            var item = new SilkERP360.CCL.BusinessEntities.HRIS.IncrementAndPromotionHistory();

                            // Safe parsing
                            item.EmployeeCode = lcl_obj_dr["employee_code"] != DBNull.Value ? Convert.ToUInt64(lcl_obj_dr["employee_code"]) : 0;
                            item.EmployeeId = lcl_obj_dr["employee_id"] != DBNull.Value ? Convert.ToString(lcl_obj_dr["employee_id"]) : string.Empty;
                            item.EmployeeName = lcl_obj_dr["employee_name"] != DBNull.Value ? Convert.ToString(lcl_obj_dr["employee_name"]) : string.Empty;
                            item.PreviousDesignation = lcl_obj_dr["previous_designation"] != DBNull.Value ? Convert.ToString(lcl_obj_dr["previous_designation"]) : string.Empty;
                            item.NewDesignation = lcl_obj_dr["new_designation"] != DBNull.Value ? Convert.ToString(lcl_obj_dr["new_designation"]) : string.Empty;
                            item.PromotionEffectiveDate = lcl_obj_dr["promotionEffectiveFrom"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(lcl_obj_dr["promotionEffectiveFrom"]) : null;
                            item.Type = lcl_obj_dr["record_type"] != DBNull.Value ? Convert.ToString(lcl_obj_dr["record_type"]) : string.Empty;

                            item.PreviousGross = lcl_obj_dr["previous_gross"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["previous_gross"]) : null;
                            item.IncGross = lcl_obj_dr["inc_gross"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["inc_gross"]) : null;
                            item.IncBasic = lcl_obj_dr["inc_basic"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["inc_basic"]) : null;
                            item.IncHouseRent = lcl_obj_dr["inc_hourse_rent"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["inc_hourse_rent"]) : null;
                            item.IncConveyance = lcl_obj_dr["inc_conveyence"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["inc_conveyence"]) : null;
                            item.IncMedical = lcl_obj_dr["inc_medical"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["inc_medical"]) : null;
                            item.IncEntertainment = lcl_obj_dr["inc_entertainment"] != DBNull.Value ? (decimal?)Convert.ToDecimal(lcl_obj_dr["inc_entertainment"]) : null;

                            item.IncEffectiveMonth = lcl_obj_dr["IncrementEffectiveMonth"] != DBNull.Value ? (int?)Convert.ToInt16(lcl_obj_dr["IncrementEffectiveMonth"]) : null;
                            item.IncEffectiveYear = lcl_obj_dr["IncrementEffectiveYear"] != DBNull.Value ? (int?)Convert.ToInt16(lcl_obj_dr["IncrementEffectiveYear"]) : null;


                            list.Add(item);
                        }

                        return list;
                    }
                }
            }, "BMLExceptionPolicy");
        }
    }
}