using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Diagnostics;

namespace SilkERP360.CCL.ExceptionManagement
{
    public static class ExceptionInfoManager
    {
        /// <summary>
        /// Pre-Condition : 1. The DBManager class must be initialized with an open connection to the DB
        ///                 2. The class ExceptionInfo class must be initialized
        /// </summary>
        /// <param name="IP_obj_DBManager">DAL.DBManager class</param>
        /// <param name="IP_obj_ExceptionInfo">CCL.ExceptionManagement.ExceptionInfo Class</param>
        /// <returns></returns>
        public static System.String LogException(SilkERP360.CCL.ExceptionManagement.ExceptionInfo IP_obj_ExceptionInfo)
        {
            try
            {
                System.String lcl_str_Source = "Application";
                System.Text.StringBuilder lcl_sb_LogFormatter = new System.Text.StringBuilder();
                lcl_sb_LogFormatter.AppendLine("ModuleCode : " + IP_obj_ExceptionInfo.ModuleCode.ToString());
                lcl_sb_LogFormatter.AppendLine("User : " + IP_obj_ExceptionInfo.UserName);
                lcl_sb_LogFormatter.AppendLine("Error ID : " + IP_obj_ExceptionInfo.ErrorID);
                lcl_sb_LogFormatter.AppendLine("Client IP : " + IP_obj_ExceptionInfo.HostIP);
                lcl_sb_LogFormatter.AppendLine("Exception Layer : " + IP_obj_ExceptionInfo.ExceptionOriginatorLayer.ToString());
                lcl_sb_LogFormatter.AppendLine("Exception Type : " + IP_obj_ExceptionInfo.ExceptionType.ToString());
                lcl_sb_LogFormatter.AppendLine("Description : " + IP_obj_ExceptionInfo.ErrorDescription);
                lcl_sb_LogFormatter.AppendLine("Source Object : " + IP_obj_ExceptionInfo.Source.ToString());
                lcl_sb_LogFormatter.AppendLine("Source Function : " + IP_obj_ExceptionInfo.TargetSite.ToString());
                lcl_sb_LogFormatter.AppendLine("Trace : " + IP_obj_ExceptionInfo.Trace);

                System.Diagnostics.EventLog lcl_obj_EventLog = new System.Diagnostics.EventLog(lcl_str_Source);
                lcl_obj_EventLog.Log = "Application";
                lcl_obj_EventLog.MachineName = "Amitav-LT";

                if (!EventLog.SourceExists("Application"))
                {
                    EventLog.CreateEventSource("Application", "Application");
                }

                EventLog.WriteEntry(lcl_str_Source, lcl_sb_LogFormatter.ToString(), EventLogEntryType.Error,IP_obj_ExceptionInfo.EventSourceCode);
                return IP_obj_ExceptionInfo.ErrorID;
                
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
