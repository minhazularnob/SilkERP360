using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using SilkERP360.SP;
namespace SilkERPSync
{
    public partial class SilkERPSync : ServiceBase
    {
        /// <summary>
        /// Service Log Refreshed on 12:00:01 AM
        /// </summary>
        private static System.String SERVICE_LOG_REFRESH_TIME = "00:00:01";
        private static System.DateTime START_DATE = System.DateTime.ParseExact("08/03/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
        private System.Collections.Generic.List<SilkERP360.CCL.BusinessEntities.HRIS.Company> m_objLst_Companies;
        private SilkERP360.DAL.DBManager m_obj_DBManager;
        
       // private ServiceLog m_obj_ServiceLog;

        //private System.Text.StringBuilder m_sb_Log;
        public SilkERPSync()
        {
            InitializeComponent();
            this.m_obj_DBManager = new SilkERP360.DAL.DBManager(SilkERPSync.SILKERP_DATABASE_CONNECTION_STRING_ORCL);
            this.m_obj_DBManager.Initialize();
            //this.m_sb_Log = new StringBuilder();
            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString() + "=> ERP Service Object Initialized");
            //this.m_obj_ServiceLog = new ServiceLog();
            //this.m_obj_ServiceLog.Init(ServiceLogType.SystemErrorLog);
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString() + "=> Starting SilkERP Service...");
                SilkERP360.SP.HRIS.ServiceLog.Init();
                this.m_obj_DBManager.Open();
                SilkERP360.BML.HRIS.CompanyManager lcl_obj_CompanyManager = new SilkERP360.BML.HRIS.CompanyManager();
                lcl_obj_CompanyManager.Initialize();
                this.m_objLst_Companies = lcl_obj_CompanyManager.GetList("SELECT * FROM COMPANY ORDER BY COMPANY_CODE DESC", this.m_obj_DBManager);
                this.m_obj_DBManager.Close();
                BiometricDataUploader.LastExecutionDateTime = System.DateTime.MinValue;
                SilkERP360.SP.HRIS.AttendanceProcessor.LastExecutionDateTime = System.DateTime.MinValue;
                SilkcardProductionReporter.LastExecutionDateTime = System.DateTime.MinValue;

                //this.ServiceName = "Service1";
                this.m_obj_SecondTimer = new System.Timers.Timer(1000);
                this.m_obj_SecondTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.SecondTimer_Tick);
                this.m_obj_SecondTimer.Interval = 1000;
                this.m_obj_SecondTimer.Enabled = true;
                this.m_obj_SecondTimer.Start();

                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString() + "=> Service Started!");
            }
            catch (System.Exception ex)
            {
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString() + "=> Fatal Error (On_Start) : " + ex.Message);                
            }
            finally
            {
                
            }
        }

        protected override void OnStop()
        {
            SilkERP360.SP.HRIS.ServiceLog.Flush();
            this.m_obj_SecondTimer.Stop();
        }



        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.m_obj_SecondTimer.Stop();
                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Second Timer Activated");
                System.DateTime lcl_dt_Now = System.DateTime.Now;
                System.DateTime lcl_dt_Today = System.DateTime.Today;//.Parse(System.DateTime.Today.ToString("dd/MM/yyyy"));
                System.TimeSpan lcl_ts_Duration = lcl_dt_Now.Subtract(BiometricDataUploader.LastExecutionDateTime);

                System.TimeSpan lcl_ts_Now = System.TimeSpan.ParseExact(lcl_dt_Now.ToString("HH:mm:ss"), "g", CultureInfo.CurrentCulture);
                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Now : " + lcl_ts_Now.ToString());
                System.TimeSpan lcl_ts_ServiceLogRefreshScheduleTime = System.TimeSpan.ParseExact(SilkERPSync.SERVICE_LOG_REFRESH_TIME, "g", CultureInfo.CurrentCulture);
                if (System.TimeSpan.Compare(lcl_ts_Now, lcl_ts_ServiceLogRefreshScheduleTime) == 0)
                {
                    SilkERP360.SP.HRIS.ServiceLog.Flush();
                    SilkERP360.SP.HRIS.ServiceLog.Init();
                }

                if (lcl_ts_Duration.TotalHours >= 1.0)
                {
                    if (this.m_obj_DBManager.ConnectionState != ConnectionState.Open)
                    {
                        this.m_obj_DBManager.Open();
                    }

                    SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Bio-Metric Data Synchronization Started...");
                    
                    //Execute Every One Hour
                    
                    BiometricDataUploader lcl_obj_BiometricDataUploader = new BiometricDataUploader();
                    lcl_obj_BiometricDataUploader.Init(this.m_obj_DBManager);
                    lcl_obj_BiometricDataUploader.ReadAndUpload();
                    this.m_obj_DBManager.CommitTransaction();
                    this.m_obj_DBManager.Close();
                    SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Bio-Metric Data Synchronization Completed Successfully!!!");
                    SilkERP360.SP.HRIS.ServiceLog.Flush();
                    BiometricDataUploader.LastExecutionDateTime = lcl_dt_Now;
                }

                if (lcl_dt_Today.Date >= SilkERPSync.START_DATE)
                {
                    /******************************************************************************************************************************************/
                    /******************************************************************************************************************************************/
                    //Silkcard Production Reporter in Action
                    if (SilkcardProductionReporter.LastExecutionDateTime.Date != lcl_dt_Today.Date)
                    {
                        System.TimeSpan lcl_ts_SilkcardProductionReporterScheduleTime = System.TimeSpan.ParseExact(SilkcardProductionReporter.SCHEDULED_EXECUTION_TIME, "g", CultureInfo.CurrentCulture);
                        if (System.TimeSpan.Compare(lcl_ts_Now, lcl_ts_SilkcardProductionReporterScheduleTime) == 0)
                        {
                            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Processing Silkcard Production Report...");
                            System.UInt64 lcl_ui64_CompanyCodeTmp = 110000000001;//SilkCard

                            System.DateTime lcl_dt_ProductionDate = System.DateTime.Today.AddDays(-1); //System.DateTime.ParseExact("06/04/2015", "dd/M/yyyy", CultureInfo.InvariantCulture);
                            SilkcardProductionReporter lcl_obj_SilkcardProductionReporter = new SilkcardProductionReporter(lcl_dt_ProductionDate, lcl_ui64_CompanyCodeTmp);
                            lcl_obj_SilkcardProductionReporter.Init(this.m_obj_DBManager);
                            lcl_obj_SilkcardProductionReporter.MailSilkcardProductionReport();
                            SilkcardProductionReporter.LastExecutionDateTime = System.DateTime.Now;
                            this.m_obj_DBManager.CommitTransaction();
                            this.m_obj_DBManager.Close();
                            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Silkcard Production Report Processed & Mailed!!");
                        }
                    }
                    /******************************************************************************************************************************************/
                    /******************************************************************************************************************************************/

                    if (SilkERP360.SP.HRIS.AttendanceProcessor.LastExecutionDateTime.Date != lcl_dt_Today.Date)
                    {
                        
                        //SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Attendance Processing : " + lcl_dt_Today.Date.ToLongDateString());
                        //System.TimeSpan lcl_ts_Now = System.TimeSpan.ParseExact(lcl_dt_Now.ToString("HH:mm:ss"), "g", CultureInfo.CurrentCulture);
                        //SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Now : " + lcl_ts_Now.ToString());
                        System.TimeSpan lcl_ts_AttendanceProcessScheduleTime = System.TimeSpan.ParseExact(SilkERP360.SP.HRIS.AttendanceProcessor.SCHEDULED_EXECUTION_TIME, "g", CultureInfo.CurrentCulture);
                        //SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Attendance Process Schedule Time : " + lcl_ts_AttendanceProcessScheduleTime.ToString());
                        //SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Now : " + lcl_ts_Now.ToString());
                        if (System.TimeSpan.Compare(lcl_ts_Now, lcl_ts_AttendanceProcessScheduleTime) == 0)
                        {
                            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Attendance Processing Time.");
                            System.DateTime lcl_dt_AttendanceDate = System.DateTime.Today.AddDays(-1);//ONE DAY BEFORE
                            SilkERP360.SP.HRIS.ServiceLog.LogData("Processing Daily Attendance : " + lcl_dt_AttendanceDate.ToLongDateString());
                            //Execution Time
                            
                            //Update BMS_REPOSITORY
                            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Bio-Metric Repository Synchronization Started...");
                            if (this.m_obj_DBManager.ConnectionState != ConnectionState.Open)
                            {
                                this.m_obj_DBManager.Open();
                            }
                            BiometricDataUploader lcl_obj_BiometricDataUploader = new BiometricDataUploader();
                            lcl_obj_BiometricDataUploader.Init(this.m_obj_DBManager);
                            //SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Biometric Repository Uploader Initialised Successfully!");
                            lcl_obj_BiometricDataUploader.SynchronizeBiometricRepository();
                            this.m_obj_DBManager.CommitTransaction();
                            this.m_obj_DBManager.Close();
                            this.m_obj_DBManager.Open();
                            SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Bio-Metric Repository Synchronization Completed Successfully!!!");
                            SilkERP360.SP.HRIS.AttendanceProcessor lcl_obj_AttendanceProcessor = new SilkERP360.SP.HRIS.AttendanceProcessor();
                            lcl_obj_AttendanceProcessor.Init(this.m_obj_DBManager);
                            System.String lcl_str_SqlQuery = System.String.Empty;
                            foreach (SilkERP360.CCL.BusinessEntities.HRIS.Company lcl_obj_Company in this.m_objLst_Companies)
                            {
                                //if (this.m_obj_DBManager.ConnectionState != ConnectionState.Open)
                                //{
                                //    this.m_obj_DBManager.Open();
                                //}
                                SilkERP360.SP.HRIS.ServiceLog.LogData("*********************************************************************************************************************************************************");
                                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Attendance Processing For : " + lcl_obj_Company.Name);
                                SilkERP360.SP.HRIS.ServiceLog.LogData("*********************************************************************************************************************************************************");
                                //System.DateTime lcl_dt_AttendanceDate = System.DateTime.ParseExact(lcl_dt_Today.ToString("dd/M/yyyy"), "dd/M/yyyy", CultureInfo.InvariantCulture);
                                //CHECK IF COMPANY HAS NO EMPLOYEE
                                lcl_str_SqlQuery = System.String.Format("SELECT COUNT(EMPLOYEE_CODE) FROM EMPLOYEE WHERE COMPANY_CODE = {0} AND (EMPLOYEE_STATUS = {1} OR EMPLOYEE_STATUS = {2} OR EMPLOYEE_STATUS = {3})", lcl_obj_Company.CompanyCode, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Regular, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Probation, (System.Int32)SilkERP360.CCL.Enums.EmployeeStatus.Temporary);
                                //ServiceLog.LogData("SQL : " + lcl_str_SqlQuery);
                                //ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Executing Query : " + lcl_str_SqlQuery);
                                System.Object lcl_obj_NumberOfEmployee = this.m_obj_DBManager.ExecuteScalar(lcl_str_SqlQuery);
                                System.String lcl_str_NumberOfEmployee = lcl_obj_NumberOfEmployee.ToString();
                                System.Int32 lcl_ui32_NumberOfEmployee = System.Int32.Parse(lcl_str_NumberOfEmployee);

                                if (lcl_ui32_NumberOfEmployee == 0)
                                {
                                    SilkERP360.SP.HRIS.ServiceLog.LogData("**************************************************************************************************************************************************************************");
                                    SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => NO EMPLOYEE FOUND IN COMPANY : " + lcl_obj_Company.Name);
                                    SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => ATTENDANCE PROCESS TERMINATED.");
                                    SilkERP360.SP.HRIS.ServiceLog.LogData("**************************************************************************************************************************************************************************");
                                    continue;
                                }

                                

                                lcl_obj_AttendanceProcessor.Process(lcl_obj_Company.CompanyCode, lcl_dt_AttendanceDate);
                                System.GC.Collect();
                                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Attendance Processed Successfully!!!");

                                SilkERP360.SP.HRIS.ServiceLog.Flush();

                               /* System.String lcl_str_AttendanceMail = lcl_obj_AttendanceProcessor.GetHTMLReport(lcl_obj_Company);
                                System.String lcl_str_AttendanceMailSubject = "HRIS Daily Attendance Report (" + lcl_dt_Today.ToString("dd/MM/yyyy") + ")-" + lcl_obj_Company.Name;
                                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Mailing Attendance Report...");

                                List<string> lcl_objLst_MailListTo = new List<string>();
                                List<string> lcl_objLst_MailListCC = new List<string>();
                                //Common
                                //lcl_objLst_MailListTo.Add("munni.sc@silkways.net");
                                lcl_objLst_MailListCC.Add("manik@silkways.net");
                                //lcl_objLst_MailListCC.Add("sarder@silkways.net");
                                //lcl_objLst_MailListCC.Add("shameem.sc@silkways.net");
                                //lcl_objLst_MailListCC.Add("hasan.ss@silkways.net");

                                switch (lcl_obj_Company.CompanyCode)
                                {
                                    case 110000000001:
                                        //Silkcard
                                        lcl_objLst_MailListTo.Add("zinia.sc@silkways.net");
                                        lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                                        lcl_objLst_MailListTo.Add("emdad.sc@silkways.net");
                                        //lcl_objLst_MailListCC.Add("saif.sc@silkways.net");
                                        break;
                                    case 110000000002:
                                        //lcl_objLst_MailListTo.Add("ataur.wp@silkways.net");
                                        //lcl_objLst_MailListTo.Add("tauhid.wp@silkways.net");
                                        lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                                        //lcl_objLst_MailListTo.Add("jahid.wp@silkways.net");
                                        lcl_objLst_MailListCC.Add("tariqul.wellpac@silkways.net");
                                        //lcl_objLst_MailListCC.Add("zinnar.wp@silkways.net");
                                        //lcl_objLst_MailListCC.Add("riaj.wp@silkways.net");
                                        //lcl_objLst_MailListCC.Add("samir.wp@silkways.net");
                                        //Wellpac
                                        break;
                                    case 110000000003:
                                        lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                                        //SSL
                                        break;
                                    case 110000000004:
                                        //STTL
                                        lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                                        //lcl_objLst_MailListCC.Add("kamal.tt@silkways.net");
                                        break;
                                    case 110000000018:
                                        //STTL
                                        lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                                        //lcl_objLst_MailListCC.Add("kamal.tt@silkways.net");
                                        break;
                                    case 110000000019:
                                        //STTL
                                         lcl_objLst_MailListTo.Add("lota.sc@silkways.net");
                                        lcl_objLst_MailListTo.Add("zinia.sc@silkways.net");
                                        //lcl_objLst_MailListTo.Add("jahid.wp@silkways.net");
                                        lcl_objLst_MailListCC.Add("tariqul.wellpac@silkways.net");
                                        //lcl_objLst_MailListCC.Add("kamal.tt@silkways.net");
                                        break;
                                }
                                
                                //lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                                lcl_objLst_MailListCC.Add("amitav.sc@silkways.net");
                                lcl_objLst_MailListCC.Add("shareat.sc@silkways.net");
                                //lcl_objLst_MailListTo.Add("pallab_gt@yahoo.com");
                                //SilkMailer lcl_obj_SilkMailer = new SilkMailer(lcl_objLst_MailListTo, lcl_objLst_MailListCC);
                                //lcl_obj_SilkMailer.SendMail(lcl_str_AttendanceMailSubject, lcl_str_AttendanceMail);
                                */
                                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Mailer Successful!!");
                                SilkERP360.SP.HRIS.ServiceLog.LogData("*********************************************************************************************************************************************************");
                                
                            }
                            this.m_obj_DBManager.CommitTransaction();
                            this.m_obj_DBManager.Close();
                            SilkERP360.SP.HRIS.AttendanceProcessor.LastExecutionDateTime = System.DateTime.Now;
                            System.GC.Collect();
                        }
                    }
                }
                this.m_obj_SecondTimer.Start();
            }
            catch (System.Exception ex)
            {
                this.m_obj_SecondTimer.Start();
                SilkERP360.SP.HRIS.ServiceLog.LogData(System.DateTime.Now.ToString("dd/MM/yy hh:mm:ss tt") + " => Critical Error : " + ex.Message);
            }
        }
    }
}
