using Oracle.ManagedDataAccess.Client;
using SilkERP360.CCL.Enums;
using SilkERP360.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SilkERP360.PromotionUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = DALObjectPoolManager.CONNECTION_STRING;
            var executor = new PromotionUpdater(connStr);
            var LeaveExecutor = new LeaveUpdater(connStr);
            var attendanceProcessor = new AttendanceProcessor(connStr);
            executor.ExecutePromotionsAndIncrement();
            LeaveExecutor.ExecuteCasualLeaveUpdate();
            attendanceProcessor.ExecuteAttendanceSync();
            //attendanceProcessor.ProcessAttendance()

        }

        public void processed()
        {
            SilkERP360.SP.HRIS.ServiceLog.Init();
            string SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.55)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl3)));User Id=silkerp;Password=silkerp;";
            SilkERP360.DAL.DBManager lcl_obj_DBManager = null;
            try
            {
                ulong lcl_ui64_CompanyCode = 110000000001; // SilkCard

                // ---------------------------------------------------
                // Attendance Process (Previous Day Data)
                // ---------------------------------------------------
                lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();

                SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                lcl_obj_CompanyManager.Initialize();
                List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_Companies =
                    lcl_obj_CompanyManager.GetList("SELECT * FROM COMPANY ORDER BY COMPANY_CODE desc", lcl_obj_DBManager);

                SilkERP360.SP.HRIS.AttendanceProcessor lcl_obj_AttendanceProcessor = new SilkERP360.SP.HRIS.AttendanceProcessor();
                lcl_obj_AttendanceProcessor.Init(lcl_obj_DBManager);

                // 🔹 Yesterday's date
                DateTime lcl_dt_ProcessDate = DateTime.Today.AddDays(-1);

                foreach (SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company in lcl_objLst_Companies)
                {
                    if (lcl_obj_Company.CompanyCode != lcl_ui64_CompanyCode)
                        continue;

                    string lcl_str_SqlQuery = string.Format(
                        "SELECT COUNT(EMPLOYEE_CODE) FROM EMPLOYEE WHERE COMPANY_CODE = {0} AND (EMPLOYEE_STATUS = {1} OR EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3})",
                        lcl_ui64_CompanyCode,
                        (int)SilkERP360.CCL.Enums.EmployeeStatus.Regular,
                        (int)SilkERP360.CCL.Enums.EmployeeStatus.Probation,
                        (int)SilkERP360.CCL.Enums.EmployeeStatus.Temporary
                    );

                    int lcl_ui32_NumberOfEmployee = Convert.ToInt32(lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery));
                    if (lcl_ui32_NumberOfEmployee == 0)
                        continue;

                    // Process attendance for yesterday
                    lcl_obj_AttendanceProcessor.Process(lcl_obj_Company.CompanyCode, lcl_dt_ProcessDate);

                    Console.WriteLine($"{lcl_obj_Company.Name} Attendance Processed Successfully for {lcl_dt_ProcessDate:dd/MM/yyyy}!");
                }

                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();

                Console.WriteLine("Attendance & Overtime Processed Successfully for Yesterday!");
            }
            catch (Exception Ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => FATAL ERROR ->  " + Ex.Message);
                SilkERP360.SP.HRIS.ServiceLog.Flush();
                if (lcl_obj_DBManager != null)
                {
                    lcl_obj_DBManager.RollbackTransaction();
                    lcl_obj_DBManager.Close();
                }
                Console.WriteLine(Ex.Message);
            }
        }
    }
}