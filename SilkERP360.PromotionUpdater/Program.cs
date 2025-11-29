using Oracle.ManagedDataAccess.Client;
using SilkERP360.CCL.Enums;
using SilkERP360.DAL;
using System;

namespace SilkERP360.PromotionUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connStr = DALObjectPoolManager.CONNECTION_STRING;

                using (var conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    using (var transaction = conn.BeginTransaction())
                    {
                        // STEP 1: Update employee designation from promotion_history (only ISAPPROVED = 2)
                        string updateEmployeeSql = @"
                            UPDATE employee e
                               SET e.designation_code = (
                                   SELECT p.current_designation_code
                                   FROM promotion_history p
                                   WHERE p.employee_code = e.employee_code
                                     AND TRUNC(p.effective_from) = TRUNC(SYSDATE)
                                     AND p.ISAPPROVED = 2
                               )
                             WHERE EXISTS (
                                   SELECT 1
                                   FROM promotion_history p
                                   WHERE p.employee_code = e.employee_code
                                     AND TRUNC(p.effective_from) = TRUNC(SYSDATE)
                                     AND p.ISAPPROVED = 2
                             )";

                        using (var cmd = new OracleCommand(updateEmployeeSql, conn))
                        {
                            cmd.Transaction = transaction;
                            int updatedRows = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{updatedRows} employee rows updated.");
                        }

                        // STEP 2: Update promotion_history → ISAPPROVED = Promoted for today's executed promotions
                        string updateHistorySql = $@"UPDATE promotion_history SET ISAPPROVED = {(int)PromotionStatus.Promoted} WHERE TRUNC(effective_from) = TRUNC(SYSDATE) AND ISAPPROVED = 2";

                        using (var cmd2 = new OracleCommand(updateHistorySql, conn))
                        {
                            cmd2.Transaction = transaction;
                            int updatedHistoryRows = cmd2.ExecuteNonQuery();
                            Console.WriteLine($"{updatedHistoryRows} promotion history rows marked as executed (ISAPPROVED = 3).");
                        }

                        // STEP 2: Update promotion_history → ISAPPROVED = Promoted for today's executed promotions
                        string updateTokenSql = $@"UPDATE tokens SET is_valid = 0 WHERE expiry_at < SYSDATE AND IS_valid = 1";

                        using (var cmd3 = new OracleCommand(updateTokenSql, conn))
                        {
                            cmd3.Transaction = transaction;
                            int updatedTokenIsValidRows = cmd3.ExecuteNonQuery();
                            Console.WriteLine($"{updatedTokenIsValidRows} token rows marked as executed (ISVALID = 0).");
                        }

                        // Commit transaction
                        transaction.Commit();
                        Console.WriteLine("Transaction committed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}