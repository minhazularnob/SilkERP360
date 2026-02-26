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
            //SilkERPSync.ServiceLog.Init();
            SilkERP360.SP.HRIS.ServiceLog.Init();
            //System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=db; User Id=silkerp; Password=silkerp;";
            //System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=ORCL; User Id=silkerp_dev; Password=silkerp_dev;";
            System.String SILKERP_DATABASE_CONNECTION_STRING_ORCL = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.200.55)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl3)));User Id=silkerp;Password=silkerp;";
            //System.String BIOMETRIC_DATABASE_CONNECTION_STRING_SQL = @"Data Source=192.168.48.5;Initial Catalog=CCFTCentral;Uid=system1;Password=Asdf@12345678";
            SilkERP360.DAL.DBManager lcl_obj_DBManager = null;
            try
            {
                System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                //System.UInt64 lcl_ui64_CompanyCode = 110000000004;//STTL
                //System.UInt64 lcl_ui64_CompanyCode = 110000000003;//SSL
               //System.UInt64 lcl_ui64_CompanyCode = 110000000018;//SilK aGRO
               //System.UInt64 lcl_ui64_CompanyCode = 110000000019;//SilK Cargo

                /****************************************************************************************/
                //lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_DBManager.Initialize();
                //lcl_obj_DBManager.Open();
                //SilkERPSync.BiometricDataUploader lcl_obj_BiometricDataUploader = new SilkERPSync.BiometricDataUploader();
                //lcl_obj_BiometricDataUploader.Init(lcl_obj_DBManager);
                //lcl_obj_BiometricDataUploader.ReadAndUpload();
                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();
                //Console.WriteLine("BMS Data Updated");


                /************************************************************************************************************************/
               /************************************************************************************************************************/
                //ONE YEAR SALARY REPORT
                /*System.String lcl_str_OutputFilePath = @"D:\LiveSilkERP360\AllEmployeeSalaryReport-2022-2023.csv";
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> lcl_objLst_AllEmployeeSalaryList = new List<SilkERP360.CCL.BusinessEntities.HRIS.Salary>();

                SilkERP360.CCL.Enums.Month lcl_enm_SalaryMonth = SilkERP360.CCL.Enums.Month.July;
                System.UInt16 lcl_i32_SalaryYear = 2022;

                for (int i = 0; i < 12; i++)
                {
                    
                    SilkERP360.BML.Services.HRIS.SalaryServices lcl_obj_SalaryService = new SilkERP360.BML.Services.HRIS.SalaryServices();
                    lcl_obj_SalaryService.Initialize();
                    SilkERP360.CCL.BusinessEntities.HRIS.SalaryMaster lcl_obj_SalaryMaster = lcl_obj_SalaryService.GetSalaryMaster(lcl_ui64_CompanyCode, lcl_enm_SalaryMonth, lcl_i32_SalaryYear);

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_obj_SalaryMaster.SalaryList)
                    {
                        if (!(lcl_objLst_AllEmployeeSalaryList.Exists(x => x.EmployeeCode == lcl_obj_Salary.EmployeeCode)))
                        {
                            lcl_objLst_AllEmployeeSalaryList.Add(lcl_obj_Salary);
                        }
                        else
                        {
                            System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Salary> lcl_objLst_SelectedEmployeeSalaryList = lcl_objLst_AllEmployeeSalaryList.Where(x => x.EmployeeCode == lcl_obj_Salary.EmployeeCode).ToList();
                            SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_SelectedSalary = lcl_objLst_SelectedEmployeeSalaryList[0];
                            lcl_obj_SelectedSalary.OverTimeAmount += lcl_obj_Salary.OverTimeAmount;
                            lcl_obj_SelectedSalary.GrandTotal += lcl_obj_Salary.GrandTotal;
                        }
                    }

                    if (lcl_enm_SalaryMonth == SilkERP360.CCL.Enums.Month.December)
                    {
                        lcl_enm_SalaryMonth = SilkERP360.CCL.Enums.Month.January;
                        lcl_i32_SalaryYear++;
                    }
                    else
                    {
                        lcl_enm_SalaryMonth++;
                    }
                }

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(lcl_str_OutputFilePath))
                {
                    System.String lcl_str_Line = "Employee ID, Employee Name, Designation, Department, Basic,Total Overtime Amount, Total Payable Amount";
                    sw.WriteLine(lcl_str_Line);

                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.Salary lcl_obj_Salary in lcl_objLst_AllEmployeeSalaryList)
                    {
                        lcl_str_Line = lcl_obj_Salary._EmployeeID + "," + lcl_obj_Salary._EmployeeName + "," + lcl_obj_Salary._Designation.Replace(',', ' ') + "," +
                                       lcl_obj_Salary._Department.Replace(',', ' ') + "," + lcl_obj_Salary.Basic + "," + lcl_obj_Salary.OverTimeAmount + "," + lcl_obj_Salary.GrandTotal;
                        sw.WriteLine(lcl_str_Line);
                    }
                    sw.Close();
                }
                */

                int a = 0;
                /************************************************************************************************************************/
                /************************************************************************************************************************/

                /************************************************************************************************************************/
                /************************************************************************************************************************/
                //Bank Account Update
                //BiometricDataSync.BankAccountManager lcl_obj_BAManager = new BankAccountManager();
                //lcl_obj_BAManager.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_BAManager.UpdateBankAccount(lcl_ui64_CompanyCode, @"C:\Documents and Settings\amitav.SILKAPP\Desktop\SILKCARD_EMPLOYEE_LIST_FOR_BANK_ACCOUNT.csv");
                /************************************************************************************************************************/

                /************************************************************************************************************************/
                /************************************************************************************************************************/
                //Bonus Processing
                //SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster lcl_obj_BonusMaster = new SilkERP360.CCL.BusinessEntities.HRIS.BonusMaster();
                //lcl_obj_BonusMaster.Occasion = SilkERP360.CCL.Enums.BonusOccasion.EidUlFitr;
                /************************************************************************************************************************/
                /************************************************************************************************************************/
                //PROVIDENT FUND EXCEL
                /*SilkERP360.SP.HRIS.ProvidentFundServices lcl_obj_PFServices = new SilkERP360.SP.HRIS.ProvidentFundServices();
                System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile> lcl_objLst_EmployeeProvidentFundProfile = lcl_obj_PFServices.GetAllProvidentFundProfileAndTransactionsByAllDurationForCompany(lcl_ui64_CompanyCode);

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    //Console.WriteLine("Excel is not properly installed!!");
                    return;
                }


                Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //xlWorkSheet.Cells[1, 1] = "Sheet 1 content";

                //First Row is Header Row so has to be written 12 times

                //for (int k = 1; k < 96;)
                System.Int32 lcl_ColumnWidth = 0;
                System.String lcl_str_OutputFileName = "ExEmployeesPF_Wellpac.xls";
               
                //for (int k = 1; k < 60; )
                //for (int k = 1; k < 120; )

                xlWorkSheet.Cells[1, 1] = "Employee Id";
                xlWorkSheet.Cells[1, 2] = "Name";
                xlWorkSheet.Cells[1, 3] = "Designation";
                xlWorkSheet.Cells[1, 4] = "Department";
                xlWorkSheet.Cells[1, 5] = "Joining Date";
                xlWorkSheet.Cells[1, 6] = "Total Amount";

                int lcl_i32_RowCount = 2;
                int lcl_i32_ColumnCount = 1;
                foreach (SilkERP360.CCL.BusinessEntities.HRIS.DataStructures.EmployeeProvidentFundProfile lcl_obj_EmployeeProvidentFundProfile in lcl_objLst_EmployeeProvidentFundProfile)
                {
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = lcl_obj_EmployeeProvidentFundProfile.EmployeeID;
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = lcl_obj_EmployeeProvidentFundProfile.EmployeeName;
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = lcl_obj_EmployeeProvidentFundProfile.Designation.Name;
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = lcl_obj_EmployeeProvidentFundProfile.Department.Name;
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = lcl_obj_EmployeeProvidentFundProfile.JoiningDate.ToShortDateString();
                    System.Decimal lcl_dcm_TotalAmount = 0;
                    System.Decimal lcl_dcm_GrandTotal = 0;
                    foreach (SilkERP360.CCL.BusinessEntities.HRIS.PFAccountTransaction lcl_obj_PFAccountTransaction in lcl_obj_EmployeeProvidentFundProfile.EmployeePFAccountTransactionList)
                    {
                        lcl_dcm_TotalAmount += lcl_obj_PFAccountTransaction.Amount;
                    }
                    lcl_dcm_GrandTotal += lcl_dcm_TotalAmount;
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount].EntireColumn.NumberFormat = "#,###.00 Tk.";
                    xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = lcl_dcm_TotalAmount;
                    lcl_dcm_TotalAmount = 0;
                    
                    lcl_i32_RowCount++;
                    //xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount++] = "Grand Total : ";
                    //xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount].EntireColumn.NumberFormat = "#,###.00 Tk.";
                    //xlWorkSheet.Cells[lcl_i32_RowCount, lcl_i32_ColumnCount] = lcl_dcm_GrandTotal;
                    lcl_i32_ColumnCount = 1;
                }

                   
                //xlWorkBook.SaveAs(@"E:\BarcodeDataProcessor\Output.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                System.String lcl_str_OutputFileFullName = @"D:\" + lcl_str_OutputFileName;
                xlWorkBook.SaveAs(lcl_str_OutputFileFullName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();*/





                //int a = 0;

                /************************************************************************************************************************/
                /************************************************************************************************************************/
                //PRODUCTION REPORT MAILER
                /*lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                lcl_obj_DBManager.Initialize();
                lcl_obj_DBManager.Open();
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Processing Silkcard Production Report...");
                System.UInt64 lcl_ui64_CompanyCodeTmp = 110000000001;//SilkCard

                System.DateTime lcl_dt_ProductionDate = System.DateTime.Today.AddDays(-1); //System.DateTime.ParseExact("06/04/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
                SilkERPSync.SilkcardProductionReporter lcl_obj_SilkcardProductionReporter = new SilkERPSync.SilkcardProductionReporter(lcl_dt_ProductionDate, lcl_ui64_CompanyCodeTmp);
                lcl_obj_SilkcardProductionReporter.Init(lcl_obj_DBManager);
                lcl_obj_SilkcardProductionReporter.MailSilkcardProductionReport();
                //SilkcardProductionReporter.LastExecutionDateTime = System.DateTime.Now;
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Silkcard Production Report Processed & Mailed!!");*/
                /************************************************************************************************************************/
                /************************************************************************************************************************/

                /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/
                //DUPLICATE ROW ELIMINATOR
                //DuplicateRowEliminator lcl_obj_DuplicateRowEliminator = new DuplicateRowEliminator();
                //lcl_obj_DuplicateRowEliminator.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_DuplicateRowEliminator.EliminateDuplicateLeaveApplication();
                /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/

                /*System.DateTime lcl_dt_ProductionDate = System.DateTime.ParseExact("06/04/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
                SilkERPSync.SilkcardProductionReporter lcl_obj_SilkcardProductionReporter = new SilkERPSync.SilkcardProductionReporter(lcl_dt_ProductionDate, lcl_ui64_CompanyCode);
                lcl_obj_SilkcardProductionReporter.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                lcl_obj_SilkcardProductionReporter.MailSilkcardProductionReport();
               //int a = 0;
               //lcl_obj_DBManager = new SilkERP360.DAL.DBManager(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
               //lcl_obj_DBManager.Initialize();
               //lcl_obj_DBManager.Open();
               //SilkERPSync.BiometricDataUploader lcl_obj_Biometric = new SilkERPSync.BiometricDataUploader();
               //lcl_obj_Biometric.Init(lcl_obj_DBManager);
               //lcl_obj_Biometric.ReadAndUpload();
               //lcl_obj_Biometric.SynchronizeBiometricRepository();
               //SilkERP360.SP.HRIS.AttendanceProcessor lcl_obj_AttendanceProcessor = new SilkERP360.SP.HRIS.AttendanceProcessor();
               //lcl_obj_AttendanceProcessor.Init(lcl_obj_DBManager);
               //System.DateTime lcl_dt_ProcessStartDate = System.DateTime.ParseExact("28/04/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
               //System.DateTime lcl_dt_ProcessEndDate = System.DateTime.ParseExact("28/04/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
               //lcl_obj_Biometric.SynchronizeBiometricRepository();

               /**********************************************************************************************************************************/
                /**********************************************************************************************************************************/
                //Annual Leave Syschronization
                //LeaveAccountSync lcl_obj_LeaveAccountSync = new LeaveAccountSync();
                //lcl_obj_LeaveAccountSync.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_LeaveAccountSync.CheckLeaveAccountExistance(lcl_ui64_CompanyCode);
                //lcl_obj_LeaveAccountSync.YearChangeLeaveSynchronization(lcl_ui64_CompanyCode);
                /********************************************************************************************************************************/

                //POJOMailer po = new POJOMailer();
                //System.String lcl_str_HTML = po.GetPOHtml();
                /*POJOMailer po = new POJOMailer();
                System.String lcl_str_HTML = po.GetJOHtml();
                List<string> lcl_objLst_MailListTo = new List<string>();
                List<string> lcl_objLst_MailListCC = new List<string>();
                //Common
                // lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                // lcl_objLst_MailListTo.Add("zinia.sc@silkways.net");
                //lcl_objLst_MailListTo.Add("shams.sc@silkways.net");
                //lcl_objLst_MailListTo.Add("amitav.sc@silkways.net");
                //lcl_objLst_MailListCC.Add("pallab_gt@yahoo.com");
                //lcl_objLst_MailListCC.Add("manik@silkways.net");
                //lcl_objLst_MailListCC.Add("sarder@silkways.net");
                // lcl_objLst_MailListCC.Add("hasan.ss@silkways.net");
                //lcl_objLst_MailListCC.Add("shameem.sc@silkways.net");
                //lcl_objLst_MailListCC.Add("ataur.wp@silkways.net");
                //lcl_objLst_MailListCC.Add("sabbir.wp@silkways.net");
                //lcl_objLst_MailListCC.Add("saif.sc@silkways.net");

                lcl_objLst_MailListTo.Add("emdad.sc@silkways.net");
                lcl_objLst_MailListCC.Add("manik@silkways.net");
                lcl_objLst_MailListCC.Add("saif.sc@silkways.net");
                lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");
                lcl_objLst_MailListCC.Add("taj.sc@silkways.net");
                lcl_objLst_MailListCC.Add("zamil.sc@silkways.net");
                lcl_objLst_MailListCC.Add("suman.sc@silkways.net");
                lcl_objLst_MailListCC.Add("mahedi.sc@silkways.net");
                lcl_objLst_MailListCC.Add("hiron.sc@silkways.net");

                //lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                SilkERPSync.SilkMailer lcl_obj_SilkMailer = new SilkERPSync.SilkMailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                //lcl_obj_SilkMailer.SendMail("Job Order (J.O) For Scratch Card", lcl_str_HTML);*/
                /**********************************************************************************************************************************/


                /********************************************************************************************************************************/
                //FOR MONTHLY ALLOWANCE PROCESSING
                // MonthlyAllowanceProcessor lcl_obj_MonthlyAllowanceProcessor = new MonthlyAllowanceProcessor(SilkERP360.CCL.Enums.Month.August, 2016);
                //lcl_obj_MonthlyAllowanceProcessor.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_MonthlyAllowanceProcessor.Process(lcl_ui64_CompanyCode);
                /********************************************************************************************************************************/
                /********************************************************************************************************************************/
                //FOR UNIFORM DEDUCTION    // ************************* SSL 20161128 3, To change Month and year *********************** 
                //AdditionDeductionProcessor lcl_obj_AdditionDeductionProcessor = new AdditionDeductionProcessor(SilkERP360.CCL.Enums.Month.June, 2018);
                //lcl_obj_AdditionDeductionProcessor.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_AdditionDeductionProcessor.ProcessUnicormDeduction(lcl_ui64_CompanyCode);
                /********************************************************************************************************************************/
                /********************************************************************************************************************************/

                //FOR PROCESSING PROVIDENT FUND   // ************************* SSL 20161128 3, To change Month and year *********************** 
                //ProvidentFundProcessor lcl_obj_ProvidentFundProcessor = new ProvidentFundProcessor(SilkERP360.CCL.Enums.Month.April, 2018);
                //lcl_obj_ProvidentFundProcessor.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_ProvidentFundProcessor.Process(lcl_ui64_CompanyCode);

                //MANUAL INPUT PROVIDENT FUND
                //ProvidentFundProcessor lcl_obj_ProvidentFundProcessor = new ProvidentFundProcessor(SilkERP360.CCL.Enums.Month.December, 2014);
                //lcl_obj_ProvidentFundProcessor.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_ProvidentFundProcessor.ProvidentFundManualInput(lcl_ui64_CompanyCode);
                //lcl_obj_ProvidentFundProcessor.PrintProvidentFund(lcl_ui64_CompanyCode);

                //CREATING PROVIDENT FUND ACCOUNT
                //ProvidentFundProcessor lcl_obj_ProvidentFundProcessor = new ProvidentFundProcessor();
                //lcl_obj_ProvidentFundProcessor.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //lcl_obj_ProvidentFundProcessor.CreateProvidentFundAccounts(lcl_ui64_CompanyCode);
                //lcl_obj_ProvidentFundProcessor.TransferProvidentFundToAccount(lcl_ui64_CompanyCode);
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

                            //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Executing Query : " + lcl_str_SqlQuery);
                            System.Object lcl_obj_NumberOfEmployee = lcl_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                            System.String lcl_str_NumberOfEmployee = lcl_obj_NumberOfEmployee.ToString();
                            System.Int32 lcl_ui32_NumberOfEmployee = System.Int32.Parse(lcl_str_NumberOfEmployee);
                            if (lcl_ui32_NumberOfEmployee == 0)
                            {
                                continue;
                            }


                            lcl_obj_AttendanceProcessor.Process(lcl_obj_Company.CompanyCode, lcl_dt_Date);
                            //System.String lcl_str_AttendanceMail = lcl_obj_AttendanceProcessor.GetHTMLReport(lcl_obj_Company);
                            //System.String lcl_str_AttendanceMailSubject = "HRIS Daily Attendance Report (" + lcl_dt_Today.ToString("dd/MM/yyyy") + ")-" + lcl_obj_Company.Name;
                            //SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Mailing Attendance Report...");

                            List<string> lcl_objLst_MailListTo = new List<string>();
                            List<string> lcl_objLst_MailListCC = new List<string>();
                            //Common                                                        
                            //lcl_objLst_MailListTo.Add("lota.sc@silkways.net");

                            //lcl_objLst_MailListCC.Add("zinia.sc@silkways.net");

                            //lcl_objLst_MailListCC.Add("konica.sc@silkways.net");

                            lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");

                            lcl_objLst_MailListCC.Add("maria.sc@silkways.net");

                            lcl_objLst_MailListCC.Add("shareat.sc@silkways.net");

                            //SilkERPSync.SilkMailer lcl_obj_SilkMailer = new SilkERPSync.SilkMailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                            // lcl_obj_SilkMailer.SendMail(lcl_str_AttendanceMailSubject, lcl_str_AttendanceMail);

                            System.GC.Collect();
                            //lcl_obj_DBManager.CommitTransaction();
                            Console.WriteLine(lcl_obj_Company.Name + "  Attendance Process Successful!!!");
                        }
                    }
                    //lcl_obj_AttendanceProcessor.Commit();
                    //lcl_obj_DBManager.RollbackTransaction();
                    //lcl_obj_DBManager.CommitTransaction();
                    //lcl_obj_DBManager.Close();
                }
                // Attendance Process (***)End
                lcl_obj_DBManager.CommitTransaction();
                lcl_obj_DBManager.Close();
                /***************************************************************************************************************************/
                /***************************************************************************************************************************/
                //SCPMManualInput lcl_obj_SCPMManualInput = new SCPMManualInput();
                ////lcl_obj_SCPMManualInput.InsertSCPMCustomer(lcl_obj_DBManager);
                ////lcl_obj_SCPMManualInput.InsertSCPMProducts(lcl_obj_DBManager);
                ////lcl_obj_SCPMManualInput.InsertSCPMPurchaseOrder(lcl_obj_DBManager);
                //lcl_obj_SCPMManualInput.InsertSCPMJobOrder(lcl_obj_DBManager);
                //lcl_obj_DBManager.CommitTransaction();
                //lcl_obj_DBManager.Close();
                //Console.WriteLine("Scratch Card Purchase Order SAVED SUCCESSFULLY!!!");
                //Console.ReadLine();
                //ManualDataInput mip = new ManualDataInput();
                //mip.Input();
                //mip.AdjustMonthlyAllowance();
                // mip.DeductAutoOvertimeAndAdjustFromSalary();

                //BiometricDataUploader bdu = new BiometricDataUploader();
                //bdu.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL, BIOMETRIC_DATABASE_CONNECTION_STRING_SQL);
                //bdu.ReadAndUpload();

                //EmployeeStatusSync emps = new EmployeeStatusSync();
                //emps.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //emps.SyncStatus();

                //System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                ////System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                ///System.UInt64 lcl_ui64_CompanyCode = 110000000004;//STTL
                //AttendanceProcessor ap = new AttendanceProcessor();
                //ap.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //string HTML;

                //List<string> lcl_objLst_MailListTo = new List<string>();
                //lcl_objLst_MailListTo.Add("amitav.sc@silkways.net");

                //List<string> lcl_objLst_MailListCC = new List<string>();
                //lcl_objLst_MailListCC.Add("pallab_gt@yahoo.com");

                //SilkMailer lcl_obj_SilkMailer = new SilkMailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                //for (System.DateTime lcl_dt_Date = lcl_dt_StartDate; lcl_dt_Date <= lcl_dt_EndDate; lcl_dt_Date = lcl_dt_Date.AddDays(1))
                //{
                //    ap.Process(lcl_dt_Date);

                //}
                //ap.Dispose();


                // Console.Read();
                //LeaveAccountSync LA = new LeaveAccountSync();
                //LA.Init(SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //LA.CheckLeaveAccountExistance();
                //LA.YearChangeLeaveSynchronization();

                //System.UInt64 lcl_ui64_CompanyCode = 110000000001;//SilkCard
                //System.UInt64 lcl_ui64_CompanyCode = 110000000002;//Wellpac
                ////System.UInt64 lcl_ui64_CompanyCode = 110000000004;//STTL
                //AttendanceProcessor ap = new AttendanceProcessor();
                //ap.Init(lcl_ui64_CompanyCode, SILKERP_DATABASE_CONNECTION_STRING_ORCL);
                //System.DateTime lcl_dt_StartDate = System.DateTime.ParseExact("26/01/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
                //System.DateTime lcl_dt_EndDate = System.DateTime.ParseExact("26/01/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
                //for (System.DateTime lcl_dt_Date = lcl_dt_StartDate; lcl_dt_Date <= lcl_dt_EndDate; lcl_dt_Date = lcl_dt_Date.AddDays(1))
                //{
                //    ap.Process(lcl_dt_Date);
                //}
                //ap.Dispose();
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
