using Oracle.ManagedDataAccess.Client;
using SilkERP360.CCL.Enums;
using System;
using System.Collections.Generic;
using System.Data;

namespace SilkERP360.PromotionUpdater
{
    public class PromotionUpdater
    {
        private readonly string _connectionString;
        DateTime sysDate = DateTime.Now.Date;
        public PromotionUpdater(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void ExecutePromotionsAndIncrement()
        {
            try
            {
                using (var conn = new OracleConnection(_connectionString))
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        RejectPassedSalaryRequests(conn, tran);
                        RejectPassedPromotions(conn, tran);
                        UpdateEmployeeDesignations(conn, tran);

                        var pendingCodes = GetPendingIncrementCodes(conn, tran);
                        foreach (var code in pendingCodes)
                            ProcessIncrementRequest(conn, tran, code);

                        MarkPromotionsExecuted(conn, tran);
                        InvalidateExpiredTokens(conn, tran);

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

        // --------------------------------------------------------------------
        // STEP 1 — Reject Salary Increment Request For Passed Effective Dates
        // --------------------------------------------------------------------
        private void RejectPassedSalaryRequests(OracleConnection conn, OracleTransaction tran)
        {
            string sql = @"
                UPDATE salary_increment_request sir
                SET is_approved = 0
                WHERE EXISTS (
                    SELECT 1 FROM promotion_history ph
                    WHERE ph.increment_code = sir.increment_code
                      AND ph.effective_from < TRUNC(SYSDATE)
                      AND ph.isapproved = 1
                )";

            ExecuteNonQuery(conn, tran, sql);
            Console.WriteLine("Rejected old salary increment requests.");
        }

        // --------------------------------------------------------------------
        // STEP 2 — Reject Promotions With Past Effective Date
        // --------------------------------------------------------------------
        private void RejectPassedPromotions(OracleConnection conn, OracleTransaction tran)
        {
            string sql = @"
                UPDATE promotion_history
                SET isapproved = 0
                WHERE isapproved = 1
                  AND effective_from < TRUNC(SYSDATE)";

            ExecuteNonQuery(conn, tran, sql);
            Console.WriteLine("Rejected outdated promotions.");
        }

        // --------------------------------------------------------------------
        // STEP 3 — Update Employee Designation
        // --------------------------------------------------------------------
        private void UpdateEmployeeDesignations(OracleConnection conn, OracleTransaction tran)
        {
            string sql = @"
                UPDATE employee e
                SET designation_code = (
                    SELECT p.current_designation_code
                    FROM promotion_history p
                    WHERE p.employee_code = e.employee_code
                      AND p.isapproved = 2
                      AND p.effective_from = TRUNC(SYSDATE)
                )
                WHERE EXISTS (
                    SELECT 1
                    FROM promotion_history p
                    WHERE p.employee_code = e.employee_code
                      AND p.isapproved = 2
                      AND p.effective_from = TRUNC(SYSDATE)
                )";

            ExecuteNonQuery(conn, tran, sql);
            Console.WriteLine("Employee designations updated.");
        }

        // --------------------------------------------------------------------
        // STEP 4 — Get Pending Increment Codes
        // --------------------------------------------------------------------
        private List<long> GetPendingIncrementCodes(OracleConnection conn, OracleTransaction tran)
        {
            List<long> list = new List<long>();

            string sql = @"
        SELECT increment_code 
        FROM
        (
            -- Pending promotions
            SELECT DISTINCT increment_code
            FROM promotion_history
            WHERE isapproved = 2 
              AND increment_code IS NOT NULL

            UNION ALL

            -- Pending increments (not mapped)
            SELECT DISTINCT r.increment_code
            FROM salary_increment_request r
            WHERE r.is_approved = 2
              AND NOT EXISTS (
                    SELECT 1 
                    FROM increment_mapping m 
                    WHERE m.increment_request_code = r.increment_code
              )
        )";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(reader.GetInt64(0));
                }
            }

            return list;
        }


        // --------------------------------------------------------------------
        // STEP 5 — Process Each Increment Request
        // --------------------------------------------------------------------
        private void ProcessIncrementRequest(OracleConnection conn, OracleTransaction tran, long code)
        {
            var req = LoadSalaryRequest(conn, tran, code);
            long newInc = InsertSalaryIncrement(conn, tran, req);
            InsertMapping(conn, tran, code, newInc);
            UpdateEmployeeSalaryStructure(conn, tran, req);

            Console.WriteLine($"Processed increment request {code}");
        }

        private SalaryRequest LoadSalaryRequest(OracleConnection conn, OracleTransaction tran, long code)
        {
            string sql = @"
                SELECT EMPLOYEE_CODE, INCREMENT_DATE, PREVIOUS_GROSS,
                       INC_BASIC, INC_HOURSE_RENT, INC_CONVEYENCE,
                       INC_MEDICAL, INC_ENTERTAINMENT, INC_GROSS,
                       ENTRY_DATE, ENTRY_EMPLOYEE_CODE,
                       EFFECTIVE_MONTH, EFFECTIVE_YEAR
                FROM salary_increment_request
                WHERE increment_code = :C";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;
                cmd.Parameters.Add(new OracleParameter("C", code));

                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) throw new Exception("Request not found");

                    return new SalaryRequest
                    {
                        Employee = r.GetInt64(0),
                        IncrementDate = r.GetDateTime(1),
                        PrevGross = r.GetDecimal(2),
                        Basic = r.GetDecimal(3),
                        HouseRent = r.GetDecimal(4),
                        Conveyence = r.GetDecimal(5),
                        Medical = r.GetDecimal(6),
                        Entertainment = r.GetDecimal(7),
                        Gross = r.GetDecimal(8),
                        EntryDate = r.GetDateTime(9),
                        EntryBy = r.GetInt64(10),
                        EffMonth = r.GetInt32(11),
                        EffYear = r.GetInt32(12)
                    };
                }
            }
        }

        // --------------------------------------------------------------------
        // INSERT salary_increment
        // --------------------------------------------------------------------
        private long InsertSalaryIncrement(OracleConnection conn, OracleTransaction tran, SalaryRequest r)
        {
            string sql = @"
                INSERT INTO salary_increment (
                    INCREMENT_CODE, EMPLOYEE_CODE, INCREMENT_DATE,
                    PREVIOUS_GROSS, INC_BASIC, INC_HOURSE_RENT,
                    INC_CONVEYENCE, INC_MEDICAL, INC_ENTERTAINMENT,
                    INC_GROSS, ENTRY_DATE, ENTRY_EMPLOYEE_CODE,
                    EFFECTIVE_MONTH, EFFECTIVE_YEAR
                )
                VALUES (
                    SEQ_INCREMENT.NEXTVAL,
                    :EMP, :ID, :PG, :B, :HR, :C, :M, :E, :G,
                    :ED, :EB, :MON, :YR
                )
                RETURNING INCREMENT_CODE INTO :OUT";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;

                cmd.Parameters.Add(new OracleParameter("EMP", r.Employee));
                cmd.Parameters.Add(new OracleParameter("ID", r.IncrementDate));
                cmd.Parameters.Add(new OracleParameter("PG", r.PrevGross));
                cmd.Parameters.Add(new OracleParameter("B", r.Basic));
                cmd.Parameters.Add(new OracleParameter("HR", r.HouseRent));
                cmd.Parameters.Add(new OracleParameter("C", r.Conveyence));
                cmd.Parameters.Add(new OracleParameter("M", r.Medical));
                cmd.Parameters.Add(new OracleParameter("E", r.Entertainment));
                cmd.Parameters.Add(new OracleParameter("G", r.Gross));
                cmd.Parameters.Add(new OracleParameter("ED", r.EntryDate));
                cmd.Parameters.Add(new OracleParameter("EB", r.EntryBy));
                cmd.Parameters.Add(new OracleParameter("MON", r.EffMonth));
                cmd.Parameters.Add(new OracleParameter("YR", r.EffYear));

                var outParam = new OracleParameter("OUT", OracleDbType.Int64, ParameterDirection.Output);
                cmd.Parameters.Add(outParam);

                cmd.ExecuteNonQuery();

                return Convert.ToInt64(outParam.Value.ToString());
            }
        }

        // --------------------------------------------------------------------
        // INSERT increment mapping
        // --------------------------------------------------------------------
        private void InsertMapping(OracleConnection conn, OracleTransaction tran, long req, long newCode)
        {
            string sql = @"INSERT INTO increment_mapping (increment_request_code, increment_code)
                           VALUES (:R, :N)";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;
                cmd.Parameters.Add(new OracleParameter("R", req));
                cmd.Parameters.Add(new OracleParameter("N", newCode));
                cmd.ExecuteNonQuery();
            }
        }

        // --------------------------------------------------------------------
        // Update Employee Salary Structure
        // --------------------------------------------------------------------
        private void UpdateEmployeeSalaryStructure(OracleConnection conn, OracleTransaction tran, SalaryRequest r)
        {
            string sql = @"
                UPDATE employee_salary_structure
                SET BASIC = :B, HOUSE_RENT = :HR, MEDICAL = :M,
                    CONVEYENCE = :C, ENTERTAINMENT = :E, GROSS = :G
                WHERE employee_code = :EMP";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;

                cmd.Parameters.Add(new OracleParameter("B", r.Basic));
                cmd.Parameters.Add(new OracleParameter("HR", r.HouseRent));
                cmd.Parameters.Add(new OracleParameter("M", r.Medical));
                cmd.Parameters.Add(new OracleParameter("C", r.Conveyence));
                cmd.Parameters.Add(new OracleParameter("E", r.Entertainment));
                cmd.Parameters.Add(new OracleParameter("G", r.Gross));
                cmd.Parameters.Add(new OracleParameter("EMP", r.Employee));

                cmd.ExecuteNonQuery();
            }
        }

        // --------------------------------------------------------------------
        // STEP 6 — Mark Executed Promotions
        // --------------------------------------------------------------------
        private void MarkPromotionsExecuted(OracleConnection conn, OracleTransaction tran)
        {
            string sql = @"
                UPDATE promotion_history
                SET isapproved = 3
                WHERE isapproved = 2
                  AND effective_from = TRUNC(SYSDATE)";

            ExecuteNonQuery(conn, tran, sql);
        }

        // --------------------------------------------------------------------
        // STEP 7 — Invalidate Expired Tokens
        // --------------------------------------------------------------------
        private void InvalidateExpiredTokens(OracleConnection conn, OracleTransaction tran)
        {
            string sql = @"UPDATE tokens SET is_valid = 0 
                           WHERE expiry_at < SYSDATE AND is_valid = 1";

            ExecuteNonQuery(conn, tran, sql);
        }

        // --------------------------------------------------------------------
        // Helper for simple non-query execution
        // --------------------------------------------------------------------
        private void ExecuteNonQuery(OracleConnection conn, OracleTransaction tran, string sql)
        {
            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Helper DTO
    internal class SalaryRequest
    {
        public long Employee;
        public DateTime IncrementDate;
        public decimal PrevGross, Basic, HouseRent, Conveyence, Medical, Entertainment, Gross;
        public DateTime EntryDate;
        public long EntryBy;
        public int EffMonth, EffYear;
    }
}