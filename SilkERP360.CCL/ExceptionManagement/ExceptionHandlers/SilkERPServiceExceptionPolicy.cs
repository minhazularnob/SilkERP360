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
    [ConfigurationElementType(typeof(Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.CustomHandlerData))]
    public class SilkERPServiceExceptionPolicy : SilkERP360.CCL.ExceptionManagement.Base.ExceptionHandlerBase,
        Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.IExceptionHandler
    {
        public SilkERPServiceExceptionPolicy(System.Collections.Specialized.NameValueCollection attributes)
        {
        }
        public System.Exception HandleException(System.Exception exception, Guid handlingInstanceId)
        {
            return exception;
        }
    }
}
