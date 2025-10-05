using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement.Exceptions
{
    public class FLException : SilkERP360.CCL.ExceptionManagement.Base.BaseException
    {
        public FLException()
            : base()
        {
            // Add implementation (if required)
        }

        public FLException(System.String IP_str_Message)
            : base(IP_str_Message)
        {
            // Add Implementation (if required)
        }

        public FLException(System.String IP_str_Message, System.Exception IP_obj_InnerException)
            : base(IP_str_Message, IP_obj_InnerException)
        {
            // Add implementation (if required)
        }
    }
}
