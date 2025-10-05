using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Web;
using System.Web.Script.Serialization;


namespace SilkERP360.CCL.ExceptionManagement.ExceptionHandlers
{
    [ConfigurationElementType(typeof(Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.CustomHandlerData))]
    public class UIExceptionHandler : SilkERP360.CCL.ExceptionManagement.Base.ExceptionHandlerBase,
        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler,System.Web.SessionState.IRequiresSessionState
    {
        public UIExceptionHandler(System.Collections.Specialized.NameValueCollection attributes)
        {
        }
        public System.Exception HandleException(System.Exception exception, Guid handlingInstanceId)
        {
            
            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = null;
            System.String lcl_str_ExceptionMessage = System.String.Empty;

            if ((exception is SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException))
            {
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Session["err_msg"] = exception.Message;
                return exception;
            }
            if((exception is SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException))
            {
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException)exception).ExceptionInfo);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Session["err_msg"] = exception.Message;
                return exception;
            }
            if((exception is SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException))
            {
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException)exception).ExceptionInfo);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Session["err_msg"] = exception.Message;
                return exception;
            }
             if((exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException))
            {
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)exception).ExceptionInfo);
                HttpContext.Current.Response.StatusCode = 500;
                HttpContext.Current.Session["err_msg"] = exception.Message;
                return exception;
            }
                       
            
            //Exception could be thrown from UIControlExceptionHandler also
            //if thrown from UIControlExceptionHandler, the InnerException contains the original exception
            //SilkERP360.CCL.ExceptionManagement.Exceptions.UIException lcl_obj_UIException = (SilkERP360.CCL.ExceptionManagement.Exceptions.UIException)exception;
            //System.Exception lcl_obj_InnerException = lcl_obj_UIException.InnerException;

            //for all other exception types
            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);

            //System.String lcl_str_ExceptionLogId = System.String.Empty;
            //System.String lcl_str_Msg = System.String.Empty;
            System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;

            lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (lcl_obj_AuthenticUserContext != null)
            {
                lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            }
            lcl_obj_ExceptionInfo.ErrorID = handlingInstanceId.ToString();
            lcl_obj_ExceptionInfo.EventSourceCode = 10013;
            lcl_obj_ExceptionInfo.HostIP = lcl_str_IP;
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.CriticalSystemException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.UI;
            lcl_obj_ExceptionInfo.ErrorDescription = exception.Message;
            lcl_obj_ExceptionInfo.Source = exception.Source;
            lcl_obj_ExceptionInfo.TargetSite = exception.TargetSite;
            lcl_obj_ExceptionInfo.Trace = exception.StackTrace;

            System.String lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_ExceptionMessage = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
            HttpContext.Current.Response.StatusCode = 500;
           // HttpContext.Current.Response.StatusDescription = lcl_str_ExceptionMessage;
            //save the error message in session
            HttpContext.Current.Session["err_msg"] = lcl_str_ExceptionMessage;
            exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException(lcl_str_ExceptionMessage, lcl_obj_ExceptionInfo);           
            return exception;
         }
    }
}
