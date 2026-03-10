using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
namespace BiometricDataSync
{
    class Program
    {
        static void Main(string[] args)
        {
            SilkERP360.SP.HRIS.ServiceLog.Init();
            System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.55)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl3)));User Id=silkerp;Password=silkerp;";
            SilkERP360.DAL.DBManager lcl_obj_DBManager = null;
            try
            {
                System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
              

                int a = 0;
                
                /********************************************************************************************************************************/
                //Upload Bio-Metric Data (NEW PROCESS)
                //lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_DBManager.Initialize();
                //lcl_obj_DBManager.Open();
                //SilkERPSync.BiometricDataUploader lcl_obj_Biometric = new SilkERPSync.BiometricDataUploader();
                //lcl_obj_Biometric.Init(lcl_obj_DBManager);
                //lcl_obj_Biometric.SynchronizeBiometricRepository(@"G:\Attendance\attendance.csv");
                //int p = 0;
                /**************************************************************************************************************/


                // Attendance Process (***)
                lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                lcl_obj_CompanyManager.Initialize();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> lcl_objLst_Companies = lcl_obj_CompanyManager.GetList("SELECT * FROM COMPANY ORDER BY COMPANY_CODE desc", lcl_obj_DBManager);
                SilkERPSync.BiometricDataUploader lcl_obj_Biometric = new SilkERPSync.BiometricDataUploader();
                lcl_obj_Biometric.Init(lcl_obj_DBManager);
                SilkERP360.SP.HRIS.AttendanceProcessor lcl_obj_AttendanceProcessor = new SilkERP360.SP.HRIS.AttendanceProcessor();
                lcl_obj_AttendanceProcessor.Init(lcl_obj_DBManager);
                System.DateTime lcl_dt_ProcessStartDate = System.DateTime.ParseExact("27/01/2026", "dd/M/yyyy", CultureInfo.InvariantCulture);
                System.DateTime lcl_dt_ProcessEndDate = System.DateTime.ParseExact("25/02/2026", "dd/M/yyyy", CultureInfo.InvariantCulture);


                System.DateTime lcl_dt_Today = System.DateTime.Now;
                System.String lcl_str_SqlQuery = System.String.Empty;
                for (System.DateTime lcl_dt_Date = lcl_dt_ProcessStartDate; lcl_dt_Date <= lcl_dt_ProcessEndDate; lcl_dt_Date = lcl_dt_Date.AddDays(1))
                {
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company in lcl_objLst_Companies)
                    {
                        if (lcl_obj_Company.CompanyCode == lcl_ui64_CompanyCode)
                        {
                            lcl_str_SqlQuery = System.String.Format("SELECT COUNT(EMPLOYEE_CODE) FROM EMPLOYEE WHERE COMPANY_CODE = {0} AND (EMPLOYEE_STATUS = {1} OR EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3})", lcl_ui64_CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);

                            System.Object lcl_obj_NumberOfEmployee = lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                            System.String lcl_str_NumberOfEmployee = lcl_obj_NumberOfEmployee.ToString();
                            System.Int32 lcl_ui32_NumberOfEmployee = System.Int32.Parse(lcl_str_NumberOfEmployee);
                            if (lcl_ui32_NumberOfEmployee == 0)
                            {
                                continue;
                            }


                            lcl_obj_AttendanceProcessor.Process(lcl_obj_Company.CompanyCode, lcl_dt_Date);
                           

                            List<string> lcl_objLst_MailListTo = new List<string>();
                            List<string> lcl_objLst_MailListCC = new List<string>();

                            lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");

                            lcl_objLst_MailListCC.Add("maria.sc@silkways.net");

                            lcl_objLst_MailListCC.Add("shareat.sc@silkways.net");

                            System.GC.Collect();
                            Console.WriteLine(lcl_obj_Company.Name + "  Attendance Process Successful!!!");
                        }
                    }
                }
                // Attendance Process (***)End
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                /***************************************************************************************************************************/
                /***************************************************************************************************************************/
               
                Console.WriteLine("Attendance & Overtime Processed Successfully!!!");
                Console.ReadLine();
            }
            catch (System.Exception Ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => FATAL ERROR ->  " + Ex.Message);
                SilkERP360.SP.HRIS.ServiceLog.Flush();
                if (lcl_obj_DBManager != null)
                {
                    lcl_obj_DBManager.RollbackTransaction();
                    lcl_obj_DBManager.Close();
                }
                Console.WriteLine(Ex.Message);
                Console.Read();
            }
        }
    }
}
