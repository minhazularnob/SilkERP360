using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace SilkERP360.CCL.ExceptionManagement.ExceptionHandlers
{
    /// <summary>
    /// /////This class will handle exception for CCL Layer only.Since CCL LAYER does
    /// not call any function from any layer, it will never receive error from other layers
    /// </summary>
    [ConfigurationElementType(typeof(Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.CustomHandlerData))]
    public class CCLExceptionHandler : SilkERP360.CCL.ExceptionManagement.Base.ExceptionHandlerBase,
        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler, System.Web.SessionState.IRequiresSessionState
    {
        public CCLExceptionHandler(System.Collections.Specialized.NameValueCollection attributes)
        {
        }
        public System.Exception HandleException(System.Exception exception, Guid handlingInstanceId)
        {
            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLException)
            {
                SilkERP360.CCL.ExceptionManagement.Exceptions.CCLException lcl_obj_CCLException = (SilkERP360.CCL.ExceptionManagement.Exceptions.CCLException)exception;
                SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
                if (lcl_obj_AuthenticUserContext != null)
                {
                    lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                    lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
                }
                lcl_obj_ExceptionInfo.ErrorID = handlingInstanceId.ToString();
                lcl_obj_ExceptionInfo.EventSourceCode = 10014;
                lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
                lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
                lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.UserGeneratedException;
                lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.CCL;
                lcl_obj_ExceptionInfo.ErrorDescription = lcl_obj_CCLException.Message;
                lcl_obj_ExceptionInfo.Source = lcl_obj_CCLException.Source;
                lcl_obj_ExceptionInfo.TargetSite = lcl_obj_CCLException.TargetSite;
                lcl_obj_ExceptionInfo.Trace = lcl_obj_CCLException.StackTrace;
                lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
                lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException(lcl_str_Msg, lcl_obj_ExceptionInfo);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)
            {
                /********PROCESS EXCEPTION HERE**********/
                /****************************************/
                SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException lcl_obj_CCLCustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)exception;
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(lcl_obj_CCLCustomException.Message, lcl_obj_CCLCustomException.ExceptionInfo);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException)
            {
                //exception = (SilkERP360.CCL.ExceptionManagement.Exceptions.PassThroughException)exception;
                return exception;
            }
            if (exception is System.Exception)
            {
                System.Exception lcl_obj_Exception = (System.Exception)exception;
                SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
                if (lcl_obj_AuthenticUserContext != null)
                {
                    lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                    lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
                }
                lcl_obj_ExceptionInfo.ErrorID = handlingInstanceId.ToString();
                lcl_obj_ExceptionInfo.EventSourceCode = 10014;
                lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
                lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
                lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
                lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.CCL;
                lcl_obj_ExceptionInfo.ErrorDescription = lcl_obj_Exception.Message;
                lcl_obj_ExceptionInfo.Source = lcl_obj_Exception.Source;
                lcl_obj_ExceptionInfo.TargetSite = lcl_obj_Exception.TargetSite;
                lcl_obj_ExceptionInfo.Trace = lcl_obj_Exception.StackTrace;
                lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
                lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException(lcl_str_Msg, lcl_obj_ExceptionInfo);
                return exception;
            }
            return exception;
        }
    }
}
