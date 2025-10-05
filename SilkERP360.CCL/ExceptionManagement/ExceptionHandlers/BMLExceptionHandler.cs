using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace SilkERP360.CCL.ExceptionManagement.ExceptionHandlers
{
    [ConfigurationElementType(typeof(Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.CustomHandlerData))]
    public class BMLExceptionHandler : SilkERP360.CCL.ExceptionManagement.Base.ExceptionHandlerBase,
        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler, 
        System.Web.SessionState.IRequiresSessionState
    {
        public BMLExceptionHandler(System.Collections.Specialized.NameValueCollection attributes)
        {
        }
        public System.Exception HandleException(System.Exception exception, Guid handlingInstanceId)
        {
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException)
            {
                 return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.BMLProcessedException)            
            {
               
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.BMLProcessedException)exception).ExceptionInfo);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.DALProcessedException)            
            {
               
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.DALProcessedException)exception).ExceptionInfo);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)            
            {
               
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)exception).ExceptionInfo);
                return exception;
            }

            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = null;
            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.String.Empty;
            try
            {
                System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
                lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

               
                
                lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            catch (System.Exception Ex)
            {
            }
            
            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = handlingInstanceId.ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = 10011;// System.Runtime.InteropServices.Marshal.GetHRForException(exception);//.GetExceptionCode(); //exception.GetHashCode();
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.UserGeneratedException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.BML;
            lcl_obj_ExceptionInfo.ErrorDescription = exception.Message;
            lcl_obj_ExceptionInfo.Source = exception.Source;
            lcl_obj_ExceptionInfo.TargetSite = exception.TargetSite;
            lcl_obj_ExceptionInfo.Trace = exception.StackTrace;
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
            exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.BMLProcessedException(lcl_str_Msg, lcl_obj_ExceptionInfo);
                     
            return exception;
        }
    }
}
