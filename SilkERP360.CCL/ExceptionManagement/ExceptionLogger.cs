using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement
{
    /// <summary>
    /// Page/Web Control Level Exceptions are logged through this class using ExceptionInfo and ExceptionInfoManager class
    /// </summary>
    public class ExceptionLogger
    {
        /// <summary>
        /// Logs the exception
        /// </summary>
        /// <param name="Ex">Exception to Log</param>
        /// <returns>Formatted Exception Message To be Set in Response object</returns>
        public System.String LogException(System.Exception Ex)
        {
            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;

            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = System.Guid.NewGuid().ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = 20001;
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.UI;
            lcl_obj_ExceptionInfo.ErrorDescription = Ex.Message;
            lcl_obj_ExceptionInfo.Source = Ex.Source;
            lcl_obj_ExceptionInfo.TargetSite = Ex.TargetSite;
            lcl_obj_ExceptionInfo.Trace = Ex.StackTrace;
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
            return lcl_str_Msg;
        }

        public System.String LogException(System.Int32 IP_ui32_EventSourceCode, System.String IP_str_Message)
        {
            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;

            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = System.Guid.NewGuid().ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = IP_ui32_EventSourceCode;
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.UI;
            lcl_obj_ExceptionInfo.ErrorDescription = IP_str_Message;
            lcl_obj_ExceptionInfo.Source = "";
            lcl_obj_ExceptionInfo.TargetSite = null;
            lcl_obj_ExceptionInfo.Trace = "";
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source Code : {1} !!!", lcl_str_ExceptionLogId, IP_ui32_EventSourceCode);
            return lcl_str_Msg;
        }

        public System.String LogException(System.Int32 IP_ui32_EventSourceCode, System.String IP_str_Message, System.String IP_str_Source)
        {
            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;

            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = System.Guid.NewGuid().ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = IP_ui32_EventSourceCode;
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.UI;
            lcl_obj_ExceptionInfo.ErrorDescription = IP_str_Message;
            lcl_obj_ExceptionInfo.Source = IP_str_Source;
            lcl_obj_ExceptionInfo.TargetSite = null;
            lcl_obj_ExceptionInfo.Trace = "";
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source Code : {1} !!!", lcl_str_ExceptionLogId, IP_ui32_EventSourceCode);
            return lcl_str_Msg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP_ui32_EventID">That will identify the control which generated the error</param>
        /// <param name="IP_str_Source">Function from which the error was generated</param>
        /// <param name="IP_obj_Ex">Exception</param>
        /// <returns></returns>
        public System.String LogException(System.Int32 IP_ui32_EventSourceCode, System.String IP_str_Source, System.Exception IP_obj_Ex)
        {
            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;

            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = System.Guid.NewGuid().ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = IP_ui32_EventSourceCode;
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.UI;
            lcl_obj_ExceptionInfo.ErrorDescription = IP_obj_Ex.Message;
            lcl_obj_ExceptionInfo.Source = IP_obj_Ex.Source;
            lcl_obj_ExceptionInfo.TargetSite = IP_obj_Ex.TargetSite;
            lcl_obj_ExceptionInfo.Trace = IP_obj_Ex.StackTrace;
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source Code : {1} !!!", lcl_str_ExceptionLogId, IP_ui32_EventSourceCode);
            return lcl_str_Msg;
        }
    }
}
