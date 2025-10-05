using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BiometricDataSync
{
    /// <summary>
    /// Log the reports of different services daywise
    /// Pre-Condition : The path SERVICE_LOG_PATH must exist
    /// </summary>
    public class ServiceLog
    {
        private System.String m_str_ServiceLogFolderPath;
        private System.String m_str_LogFileName;
        private System.IO.StreamWriter m_obj_LogWritter;

        public ServiceLog()
        {
           
        }

        public void Init(ServiceLogType IP_enm_ServiceLogType)
        {
            try
            {
                System.IO.DriveInfo[] lcl_objArr_DriveInfo = System.IO.DriveInfo.GetDrives();
                //Settle Folder Path
                foreach (System.IO.DriveInfo lcl_obj_DriveInfo in lcl_objArr_DriveInfo)
                {
                    if (lcl_obj_DriveInfo.IsReady)
                    {
                        this.m_str_ServiceLogFolderPath = lcl_obj_DriveInfo.Name;
                        if ((this.m_str_ServiceLogFolderPath.Contains('C')) || (this.m_str_ServiceLogFolderPath.Contains('c')) ||
                            (this.m_str_ServiceLogFolderPath.Contains('D')) || (this.m_str_ServiceLogFolderPath.Contains('d')) ||
                            (this.m_str_ServiceLogFolderPath.Contains('E')) || (this.m_str_ServiceLogFolderPath.Contains('e')))
                        {
                            this.m_str_ServiceLogFolderPath += "SilkERPServiceLog\\";
                            break;
                        }
                    }
                }
                //Create Folder Path
                System.IO.DirectoryInfo lcl_obj_DirectoryInfoTmp = System.IO.Directory.CreateDirectory(this.m_str_ServiceLogFolderPath);
                switch (IP_enm_ServiceLogType)
                {
                    case ServiceLogType.AttendanceProcessor:
                        this.m_str_LogFileName = "AttendanceProcessingLog_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";
                        this.m_obj_LogWritter = new System.IO.StreamWriter(this.m_str_ServiceLogFolderPath + this.m_str_LogFileName, true);
                        this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
                        this.m_obj_LogWritter.WriteLine("Title : Attendance Processing");
                        break;
                    case ServiceLogType.BiometricDataUploader:
                        this.m_str_LogFileName = "BiometricDataUploaderLog_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";
                        this.m_obj_LogWritter = new System.IO.StreamWriter(this.m_str_ServiceLogFolderPath + this.m_str_LogFileName, true);
                        this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
                        this.m_obj_LogWritter.WriteLine("Title : Biometric Uploader");
                        break;
                    case ServiceLogType.EmployeeStatusSunchronizer:
                        this.m_str_LogFileName = "EmployeeStatusSynchronizerLog_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";
                        this.m_obj_LogWritter = new System.IO.StreamWriter(this.m_str_ServiceLogFolderPath + this.m_str_LogFileName, true);
                        this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
                        this.m_obj_LogWritter.WriteLine("Title : Employee Status Synchronizer");
                        break;
                    case ServiceLogType.LeaveAccountSynchronizer:
                        this.m_str_LogFileName = "LeaveAccountSynchronizerLog_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";
                        this.m_obj_LogWritter = new System.IO.StreamWriter(this.m_str_ServiceLogFolderPath + this.m_str_LogFileName, true);
                        this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
                        this.m_obj_LogWritter.WriteLine("Title : Leave Account Synchronizer");
                        break;
                    case ServiceLogType.TaxProcessor:
                        this.m_str_LogFileName = "TaxProcessingLog_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";
                        this.m_obj_LogWritter = new System.IO.StreamWriter(this.m_str_ServiceLogFolderPath + this.m_str_LogFileName, true);
                        this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
                        this.m_obj_LogWritter.WriteLine("Title : Monthly Tax Processing Log");
                        break;
                    case ServiceLogType.MonthlyAllowanceProcessor:
                        this.m_str_LogFileName = "MonthlyAllowanceLog_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";
                        this.m_obj_LogWritter = new System.IO.StreamWriter(this.m_str_ServiceLogFolderPath + this.m_str_LogFileName, true);
                        this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
                        this.m_obj_LogWritter.WriteLine("Title : Monthly Fixed Allowance Processing Log");
                        break;
                }
                this.m_obj_LogWritter.WriteLine("Date : " + System.DateTime.Now.ToLongDateString());
                this.m_obj_LogWritter.WriteLine("Time : " + System.DateTime.Now.ToLongTimeString());
                this.m_obj_LogWritter.WriteLine(" ");
                this.m_obj_LogWritter.WriteLine(" ");

            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public void LogData(System.String IP_str_Data)
        {
            this.m_obj_LogWritter.WriteLine(IP_str_Data);
        }

        public void Close()
        {
            this.m_obj_LogWritter.WriteLine("*****************************************************************************************************************************************************");
            this.m_obj_LogWritter.Close();
        }
    }
}
