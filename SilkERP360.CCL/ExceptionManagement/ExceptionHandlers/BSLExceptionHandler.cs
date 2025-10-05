using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
namespace SilkERP360.CCL.ExceptionManagement.ExceptionHandlers
{
    /// <summary>
    /// This class will be used to process the exception in the webservices and generate the WResponse object
    /// </summary>
    public class BSLExceptionHandler
    {
        public BSLExceptionHandler()
        {
        }
        public SilkERP360.CCL.Misc.WSResponse HandleException(Exception exception)
        {
            if(exception is SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException)
            {
                SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException lcl_obj_FLCustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.FLProcessedException)exception;
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_obj_FLCustomException.Message, false, null); 
            }
            if(exception is SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException)
            {
                SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException lcl_obj_UICustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.UIProcessedException)exception;
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_obj_UICustomException.Message, false, null); 
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException)
            {
                SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException lcl_obj_PassThroughException = (SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException)exception;
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_obj_PassThroughException.Message, false, null); 
            }

            System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
            SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_obj_Session.SessionID);
            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLException)
            {
                SilkERP360.CCL.ExceptionManagement.Exceptions.CCLException lcl_obj_CCLException = (SilkERP360.CCL.ExceptionManagement.Exceptions.CCLException)exception;
                //SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
                if (lcl_obj_AuthenticUserContext != null)
                {
                    lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                    lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
                }
                lcl_obj_ExceptionInfo.EventSourceCode = 10001;
                lcl_obj_ExceptionInfo.ErrorID = System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString();
                lcl_obj_ExceptionInfo.HostIP = lcl_obj_AuthenticUserContext.IPAddress;
                lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
                lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.DatabaseServerException;
                lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.CCL;
                lcl_obj_ExceptionInfo.ErrorDescription = lcl_obj_CCLException.Message;
                lcl_obj_ExceptionInfo.Source = lcl_obj_CCLException.Source;
                lcl_obj_ExceptionInfo.TargetSite = lcl_obj_CCLException.TargetSite;
                lcl_obj_ExceptionInfo.Trace = lcl_obj_CCLException.StackTrace;
                System.String lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
                System.String lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, 10001);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_obj_CCLException.Message, false, null); 
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)
            {
                SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException lcl_obj_CCLCustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)exception;
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.Error, -100, lcl_obj_CCLCustomException.Message, false, null);
            }
            if (exception is System.Exception)
            {
                if (lcl_obj_AuthenticUserContext != null)
                {
                    lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
                    lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
                }
                lcl_obj_ExceptionInfo.ErrorID = System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString();
                lcl_obj_ExceptionInfo.EventSourceCode = 11001;
                lcl_obj_ExceptionInfo.HostIP = lcl_obj_AuthenticUserContext.IPAddress; ;
                lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
                lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.UserGeneratedException;
                lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.UI;
                lcl_obj_ExceptionInfo.ErrorDescription = exception.Message;
                lcl_obj_ExceptionInfo.Source = exception.Source;
                lcl_obj_ExceptionInfo.TargetSite = exception.TargetSite;
                lcl_obj_ExceptionInfo.Trace = exception.StackTrace;
                System.String lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
                System.String lcl_str_Msg = System.String.Format("Critical Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, 8000);
                return new CCL.Misc.WSResponse(CCL.Enums.WebServiceExecutionStatus.CriticalError, -200, lcl_str_Msg, false, null);
            }
            return null;
        }
    }
}
