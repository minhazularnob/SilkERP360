using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Data.OracleClient;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
//using Microsoft.Practices.EnterpriseLibrary.Common;


namespace SilkERP360.CCL.ExceptionManagement.ExceptionHandlers
{
    [ConfigurationElementType(typeof(Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.CustomHandlerData))]
    public class DALExceptionHandler : SilkERP360.CCL.ExceptionManagement.Base.ExceptionHandlerBase,
        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler,System.Web.SessionState.IRequiresSessionState
    {
        public DALExceptionHandler(System.Collections.Specialized.NameValueCollection attributes)
        {
        }
        
        public Exception HandleException(System.Exception exception, System.Guid handlingInstanceId)
        {
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.DALProcessedException)
            {
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, exception);
                return exception;
            }
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException)
            {
                exception = (ExceptionManagement.Exceptions.ProcessedException)exception;
                return exception;
            }
            //if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.DALCustomException)
            //{
            //    SilkERP360.CCL.ExceptionManagement.Exceptions.DALCustomException lcl_obj_DALCustomException = (SilkERP360.CCL.ExceptionManagement.Exceptions.DALCustomException)exception;
            //    exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.PassThroughException(lcl_obj_DALCustomException.Message, lcl_obj_DALCustomException.ExceptionInfo);
            //    return exception;
            //}
            if (exception is SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)
            {
                exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.ProcessedException(exception.Message, ((SilkERP360.CCL.ExceptionManagement.Exceptions.CCLProcessedException)exception).ExceptionInfo);
                return exception;
            }
            SilkERP360.CCL.ExceptionManagement.ExceptionInfo lcl_obj_ExceptionInfo = new SilkERP360.CCL.ExceptionManagement.ExceptionInfo();
            System.String lcl_str_ExceptionLogId = System.String.Empty;
            System.String lcl_str_Msg = System.String.Empty;
            try
            {
                System.Web.SessionState.HttpSessionState lcl_obj_Session = System.Web.HttpContext.Current.Session;
                System.String lcl_str_SessionID = lcl_obj_Session.SessionID;
                SilkERP360.CCL.Repository.AuthenticUserContext lcl_obj_AuthenticUserContext = SilkERP360.CCL.Repository.AuthenticUserContextRepository.GetAuthenticatedUserContextBySession(lcl_str_SessionID);

                //System.Exception lcl_obj_ReturnException = null;
                lcl_str_ExceptionLogId = System.String.Empty;
                
                System.String lcl_str_IP = System.Web.HttpContext.Current.Request.UserHostAddress;
            }
            catch (System.Exception Ex)
            {
                //Means System is in Windows Service no web context available
                lcl_obj_ExceptionInfo.ModuleCode = 0;
                lcl_obj_ExceptionInfo.UserName = "Offline Service";
                
            }

            


            //if (lcl_obj_AuthenticUserContext != null)
            //{
            //    lcl_obj_ExceptionInfo.ModuleCode = lcl_obj_AuthenticUserContext.ActiveModuleCode;
            //    lcl_obj_ExceptionInfo.UserName = lcl_obj_AuthenticUserContext.UserProfile.UserName;
            //}
            lcl_obj_ExceptionInfo.EventSourceCode = 10010;// System.Runtime.InteropServices.Marshal.GetHRForException(exception); //System.Runtime.InteropServices.Marshal.GetExceptionCode(); //exception.GetHashCode();
            lcl_obj_ExceptionInfo.ErrorID = handlingInstanceId.ToString();
            lcl_obj_ExceptionInfo.HostIP = "";
            lcl_obj_ExceptionInfo.ErrorDateTime = System.DateTime.Now;
            lcl_obj_ExceptionInfo.ExceptionType = Enums.ExceptionType.DatabaseServerException;
            lcl_obj_ExceptionInfo.ExceptionOriginatorLayer = Enums.ExceptionOriginatorLayer.DAL;
            lcl_obj_ExceptionInfo.ErrorDescription = exception.Message;//lcl_obj_DALException.Message;
            lcl_obj_ExceptionInfo.Source = exception.Source;//lcl_obj_DALException.Source;
            lcl_obj_ExceptionInfo.TargetSite = exception.TargetSite;//lcl_obj_DALException.TargetSite;
            lcl_obj_ExceptionInfo.Trace = exception.StackTrace;//lcl_obj_DALException.StackTrace;
            lcl_str_ExceptionLogId = SilkERP360.CCL.ExceptionManagement.ExceptionInfoManager.LogException(lcl_obj_ExceptionInfo);
            lcl_str_Msg = System.String.Format("Fatal Error : Contact SSL with The Error Code : {0} | Event Source : {1} !!!", lcl_str_ExceptionLogId, lcl_obj_ExceptionInfo.EventSourceCode);
            exception = new SilkERP360.CCL.ExceptionManagement.Exceptions.DALProcessedException(lcl_str_Msg, lcl_obj_ExceptionInfo);
            return exception;
        }
    }
}
