using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement.Exceptions
{
    public class UIException : SilkERP360.CCL.ExceptionManagement.Base.BaseException
    {
        public UIException()
            : base()
        {
            // Add implementation (if required)
        }

        public UIException(System.String IP_str_Message)
            : base(IP_str_Message)
        {
            // Add Implementation (if required)
        }

        public UIException(System.String IP_str_Message, System.Exception IP_obj_InnerException)
            : base(IP_str_Message, IP_obj_InnerException)
        {
            // Add implementation (if required)
        }
    }
}
