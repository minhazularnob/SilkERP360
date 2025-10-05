using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.HRIS
{
    public static class ServiceLog
    {
        private static System.String m_str_ServiceLogFolderPath;
        private static System.String m_str_LogFileFullName;
        private static System.IO.StreamWriter m_obj_LogWritter;

        private static System.Text.StringBuilder m_sb_Log;

        static ServiceLog()
        {
            ServiceLog.m_sb_Log = new StringBuilder();
            ServiceLog.m_sb_Log.EnsureCapacity(1024000);
        }

        public static void Init()
        {
            try
            {
                System.IO.DriveInfo[] lcl_objArr_DriveInfo = System.IO.DriveInfo.GetDrives();
                //Settle Folder Path
                foreach (System.IO.DriveInfo lcl_obj_DriveInfo in lcl_objArr_DriveInfo)
                {
                    if (lcl_obj_DriveInfo.IsReady)
                    {
                        ServiceLog.m_str_ServiceLogFolderPath = lcl_obj_DriveInfo.Name;
                        if ((ServiceLog.m_str_ServiceLogFolderPath.Contains('C')) || (ServiceLog.m_str_ServiceLogFolderPath.Contains('c')) ||
                            (ServiceLog.m_str_ServiceLogFolderPath.Contains('D')) || (ServiceLog.m_str_ServiceLogFolderPath.Contains('d')) ||
                            (ServiceLog.m_str_ServiceLogFolderPath.Contains('E')) || (ServiceLog.m_str_ServiceLogFolderPath.Contains('e')))
                        {
                            ServiceLog.m_str_ServiceLogFolderPath += "SilkERPServiceLog\\";
                            break;
                        }
                    }
                }
                //Create Folder Path
                System.IO.DirectoryInfo lcl_obj_DirectoryInfoTmp = System.IO.Directory.CreateDirectory(ServiceLog.m_str_ServiceLogFolderPath);
                ServiceLog.m_str_LogFileFullName = ServiceLog.m_str_ServiceLogFolderPath + "SilkERPSvc-" + System.DateTime.Now.ToString("ddMMyyyy") + ".txt";
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }

        public static void LogData(System.String IP_str_Data)
        {
            if ((ServiceLog.m_sb_Log.Length + IP_str_Data.Length) > ServiceLog.m_sb_Log.Capacity)
            {
                //WRITE LOG TO FILE
                ServiceLog.m_obj_LogWritter = new System.IO.StreamWriter(ServiceLog.m_str_LogFileFullName, true);
                ServiceLog.m_obj_LogWritter.WriteLine(ServiceLog.m_sb_Log.ToString());
                ServiceLog.m_obj_LogWritter.Flush();
                ServiceLog.m_obj_LogWritter.Close();
                ServiceLog.m_sb_Log.Clear();
            }
            else
            {
                ServiceLog.m_sb_Log.AppendLine(IP_str_Data);
            }
        }

        public static void Flush()
        {
            if (ServiceLog.m_sb_Log.Length > 0)
            {
                ServiceLog.m_obj_LogWritter = new System.IO.StreamWriter(ServiceLog.m_str_LogFileFullName, true);
                ServiceLog.m_obj_LogWritter.WriteLine(ServiceLog.m_sb_Log.ToString());
                ServiceLog.m_obj_LogWritter.Flush();
                ServiceLog.m_obj_LogWritter.Close();
                ServiceLog.m_sb_Log.Clear();
            }
        }
    }
}
