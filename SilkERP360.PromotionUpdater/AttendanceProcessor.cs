using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SilkERP360.PromotionUpdater
{
    public class AttendanceProcessor
    {
        private readonly string _oracleConnection;

        private string BIOMETRIC_CONNECTION =
        @"Data Source=192.168.48.5;
        Initial Catalog=CCFTCentral;
        User ID=sa;
        Password=Asdf@12345678;
        Encrypt=No;
        TrustServerCertificate=Yes;";

        public AttendanceProcessor(string oracleConnection)
        {
            _oracleConnection = oracleConnection;
        }

        public void ExecuteAttendanceSync()
        {
            try
            {
                using (var conn = new OracleConnection(_oracleConnection))
                {
                    conn.Open();

                    using (var tran = conn.BeginTransaction())
                    {
                        DeleteRepository(conn, tran);

                        var table = LoadTodayAttendance();

                        InsertRepository(conn, tran, table);

                        tran.Commit();

                        Console.WriteLine("Attendance sync completed.");
                    }
                }

                // Call attendance processing for yesterday AFTER insert commit
                ProcessAttendance();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Attendance Sync Error: " + ex);
                LogError(ex);
            }
        }

        // ------------------- STEP 1 -------------------
        private void DeleteRepository(OracleConnection conn, OracleTransaction tran)
        {
            string sql = "DELETE FROM BMS_REPOSITORY";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.Transaction = tran;
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("BMS_REPOSITORY cleared.");
        }

        // ------------------- STEP 2 -------------------
        private DataTable LoadTodayAttendance()
        {
            DataTable dt = new DataTable();

            string biometricQuery = @"
            SELECT convert(varchar,Employee_ID) as Employee_ID,
                   convert(varchar,Ttime,106)+' '+convert(varchar,Ttime,108) Ttime,
                   XX,
                   Device_ID,
                   Device_ID_Name,
                   Timelog_ID 
            FROM (
                SELECT  
                    CCFTCentral..PersonalDataString.Value as Employee_ID,
                    DateAdd(HH,06,CCFTEvent..Event.OccurrenceTime) as Ttime,
                    CASE Event.eventtype
                        WHEN 20001 THEN '1'
                        WHEN 20091 THEN '1'
                        ELSE '2' 
                    END XX,
                    Door.ID as Device_ID,
                    Door.Name as Device_ID_Name,
                    CCFTEvent..Event.ID as Timelog_ID
                FROM CCFTEvent..Event
                JOIN CCFTEvent..RelatedItems as CardholderRelation
                    ON CardholderRelation.EventID = Event.ID AND CardholderRelation.RelationCode = 0
                JOIN CCFTCentral..FTItem as Cardholder
                    ON Cardholder.ID = CardholderRelation.FTItemID
                JOIN CCFTCentral..PersonalDataString
                    ON Cardholder.ID = CCFTCentral..PersonalDataString.CardholderID
                JOIN CCFTEvent..RelatedItems as DoorRelation
                    ON DoorRelation.EventID = Event.ID AND DoorRelation.RelationCode = 2
                JOIN CCFTCentral..FTItem as Door
                    ON Door.ID = DoorRelation.FTItemID
                WHERE Event.eventtype IN (20001,200091,20002,20003,20004,20006,20007)
                  AND CCFTCentral..PersonalDataString.Value <> ' '
                  AND DateAdd(HH,06,Event.OccurrenceTime) >= CAST(GETDATE()-1 AS DATE)
                  AND DateAdd(HH,06,Event.OccurrenceTime) < CAST(GETDATE() AS DATE)
                  AND Event.ID > 1
            ) X
            ORDER BY Timelog_ID";

            using (SqlConnection con = new SqlConnection(BIOMETRIC_CONNECTION))
            {
                con.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(biometricQuery, con))
                {
                    da.Fill(dt);
                }
            }

            Console.WriteLine("Biometric data loaded: " + dt.Rows.Count);
            return dt;
        }

        // ------------------- STEP 3 -------------------
        private void InsertRepository(OracleConnection conn, OracleTransaction tran, DataTable dt)
        {
            string sql = @"
            INSERT INTO BMS_REPOSITORY
            (BMS_TRAN_CODE, EMPLOYEE_ID, READER_CODE, TRAN_DATE_TIME, READER_NAME)
            VALUES
            (:CODE, :EMP, :READER, :TIME, :NAME)";

            int code = 1;

            foreach (DataRow row in dt.Rows)
            {
                using (var cmd = new OracleCommand(sql, conn))
                {
                    cmd.Transaction = tran;
                    cmd.Parameters.Add(new OracleParameter("CODE", code++));
                    cmd.Parameters.Add(new OracleParameter("EMP", row["Employee_ID"].ToString()));
                    cmd.Parameters.Add(new OracleParameter("READER", row["Device_ID"].ToString()));
                    cmd.Parameters.Add(new OracleParameter("TIME", Convert.ToDateTime(row["Ttime"])));
                    cmd.Parameters.Add(new OracleParameter("NAME", row["Device_ID_Name"].ToString()));
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Inserted rows: " + dt.Rows.Count);
        }

        // ------------------- STEP 4 -------------------
        public void ProcessAttendance()
        {
            SilkERP360.DAL.DBManager dbManager = null;
            try
            {
                SilkERP360.SP.HRIS.ServiceLog.Init();
                ulong companyCode = 110000000001; // SilkCard
                dbManager = new SilkERP360.DAL.DBManager(_oracleConnection);
                dbManager.Initialize();
                dbManager.Open();

                var companyManager = new SilkERP360.BML.HRIS.CompanyManager();
                companyManager.Initialize();
                var companies = companyManager.GetList("SELECT * FROM COMPANY ORDER BY COMPANY_CODE desc", dbManager);

                var attendanceProcessor = new SilkERP360.SP.HRIS.AttendanceProcessor();
                attendanceProcessor.Init(dbManager);

                DateTime processDate = DateTime.Today.AddDays(-1); // yesterday

                foreach (var company in companies)
                {
                    if (company.CompanyCode != companyCode)
                        continue;

                    string sql = string.Format(
                        "SELECT COUNT(EMPLOYEE_CODE) FROM EMPLOYEE WHERE COMPANY_CODE = {0} AND (EMPLOYEE_STATUS = {1} OR EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3})",
                        companyCode,
                        (int)SilkERP360.CCL.Enums.EmployeeStatus.Regular,
                        (int)SilkERP360.CCL.Enums.EmployeeStatus.Probation,
                        (int)SilkERP360.CCL.Enums.EmployeeStatus.Temporary
                    );

                    int numEmployees = Convert.ToInt32(dbManager.ExecuteScalar(sql));
                    if (numEmployees == 0)
                        continue;

                    attendanceProcessor.Process(company.CompanyCode, processDate);
                    Console.WriteLine($"{company.Name} Attendance Processed Successfully for {processDate:dd/MM/yyyy}!");
                }

                dbManager.CommitTransaction();
                dbManager.Close();

                Console.WriteLine("Attendance & Overtime Processed Successfully for Yesterday!");
            }
            catch (Exception ex)
            {
                LogError(ex);
                if (dbManager != null)
                {
                    dbManager.RollbackTransaction();
                    dbManager.Close();
                }
            }
        }

        private void LogError(Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
            try
            {
                System.IO.File.AppendAllText("AttendanceError.log", DateTime.Now + " => " + ex + Environment.NewLine);
            }
            catch { }
        }
    }
}