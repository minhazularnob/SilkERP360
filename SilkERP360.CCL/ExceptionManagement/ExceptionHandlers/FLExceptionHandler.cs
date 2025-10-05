using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
//using System.Data.OracleClient;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace SilkERP360.CCL.ExceptionManagement.ExceptionHandlers
{
    [ConfigurationElementType(typeof(Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.CustomHandlerData))]
    public class FLExceptionHandler : SilkERP360.CCL.ExceptionManagement.Base.ExceptionHandlerBase,
        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler, 
        System.Web.SessionState.IRequiresSessionState
    {
        public FLExceptionHandler(System.Collections.Specialized.NameValueCollection attributes)
        {
            
        }

        
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException)
            {
                //exception = (SilkERP360.CCL.ExceptionManagement.Exceptions.PassThroughException)exception;
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException)
            {
                /********PROCESS EXCEPTION HERE**********/
                /****************************************/
                SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException lcl_obj_DALCustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException)exception;
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(lcl_obj_DALCustomException.Message, lcl_obj_DALCustomException.ExceptionInfo);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.BMLProcessedException)
            {
                /********PROCESS EXCEPTION HERE**********/
                /****************************************/
                SilkERP360.CCL.ExceptionManagement.Exceptions.BMLProcessedException lcl_obj_BMLCustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.BMLProcessedException)exception;
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(lcl_obj_BMLCustomException.Message, lcl_obj_BMLCustomException.ExceptionInfo);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)
            {
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)exception).ExceptionInfo);
                return exception;
            }

            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            
            System.Exception lcl_obj_Exception = (System.Exception)exception;
            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = handlingInstanceId.ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = 10012;
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.FL;
            lcl_obj_ExceptionInfo.ErrorDescription = lcl_obj_Exception.Message;
            lcl_obj_ExceptionInfo.Source = lcl_obj_Exception.Source;
            lcl_obj_ExceptionInfo.TargetSite = lcl_obj_Exception.TargetSite;
            lcl_obj_ExceptionInfo.Trace = lcl_obj_Exception.StackTrace;
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
            exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException(lcl_str_Msg, lcl_obj_ExceptionInfo);
               
            return exception;
        }
    }
}
