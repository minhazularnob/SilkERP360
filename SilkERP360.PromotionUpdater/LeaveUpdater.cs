using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkERP360.PromotionUpdater
{
    public class LeaveUpdater
    {
        private readonly string _connectionString;
        DateTime sysDate = DateTime.Now.Date;
        Common common = new Common();
        public LeaveUpdater(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void ExecuteCasualLeaveUpdate()
        {
            try
            {
                using (var conn = new OracleConnection(_connectionString))
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        string sql = @"UPDATE EMPLOYEE_LEAVE_ACCOUNT ela SET ela.CL = 10 WHERE ela.EMPLOYEE_CODE IN (SELECT e.EMPLOYEE_CODE FROM EMPLOYEE e WHERE TRUNC(e.CONFIRMATION_DATE) = TRUNC(SYSDATE))";

                        common.ExecuteNonQuery(conn, tran, sql);
                        Console.WriteLine("Rejected old salary increment requests.");

                        tran.Commit();
                        Console.WriteLine("Transaction committed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing promotions: " + ex.Message);
                throw;
            }
        }
    }
}
