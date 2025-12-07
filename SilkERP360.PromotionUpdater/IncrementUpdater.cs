//using Oracle.ManagedDataAccess.Client;
//using SilkERP360.CCL.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SilkERP360.IncrementUpdater
//{
//    public class IncrementUpdater
//    {
//        private readonly string _connectionString;

//        public IncrementUpdater(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public void ExecuteIncrements()
//        {
//            try
//            {
//                using (var conn = new OracleConnection(_connectionString))
//                {
//                    conn.Open();

//                    using (var transaction = conn.BeginTransaction())
//                    {
//                        // STEP 1: Update employee designation from promotion_history
//                        string updateEmployeeSql = @"
//                            UPDATE employee e
//                               SET e.designation_code = (
//                                   SELECT p.current_designation_code
//                                   FROM promotion_history p
//                                   WHERE p.employee_code = e.employee_code AND p.ISAPPROVED = 2
//                               )
//                             WHERE EXISTS (
//                                   SELECT 1
//                                   FROM promotion_history p
//                                   WHERE p.employee_code = e.employee_code
//                                     AND p.ISAPPROVED = 2
//                             )";

//                        using (var cmd = new OracleCommand(updateEmployeeSql, conn))
//                        {
//                            cmd.Transaction = transaction;
//                            int updatedRows = cmd.ExecuteNonQuery();
//                            Console.WriteLine($"{updatedRows} employee rows updated.");
//                        }

                        

//                        // Commit transaction
//                        transaction.Commit();
//                        Console.WriteLine("Transaction committed successfully.");
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error executing promotions: " + ex.Message);
//                throw; // rethrow if you want the caller to handle exceptions
//            }
//        }
//    }
//}
