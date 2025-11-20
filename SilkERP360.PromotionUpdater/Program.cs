using System;
using SilkERP360.DAL;
using Oracle.ManagedDataAccess.Client;

namespace SilkERP360.PromotionUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get connection string from your DAL
                string connStr = DALObjectPoolManager.CONNECTION_STRING;

                using (var conn = new OracleConnection(connStr))
                {
                    conn.Open();

                    // Begin transaction
                    using (var transaction = conn.BeginTransaction())
                    {
                        string sql = @"
                            UPDATE employee e
                               SET e.designation_code = (
                                   SELECT p.current_designation_code
                                   FROM promotion_history p
                                   WHERE p.employee_code = e.employee_code
                                     AND TRUNC(p.effective_from) = TRUNC(SYSDATE)
                               )
                             WHERE EXISTS (
                                   SELECT 1
                                   FROM promotion_history p
                                   WHERE p.employee_code = e.employee_code
                                     AND TRUNC(p.effective_from) = TRUNC(SYSDATE)
                             )";

                        using (var cmd = new OracleCommand(sql, conn))
                        {
                            cmd.Transaction = transaction; // associate command with transaction
                            int rowsUpdated = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{rowsUpdated} rows updated successfully.");
                        }

                        // Commit transaction so changes persist
                        transaction.Commit();
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
