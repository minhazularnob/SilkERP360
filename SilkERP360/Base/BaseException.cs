using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement.Base
{
    public class BaseException : System.Exception
    {
        public BaseException()
            : base()
        {
            // Add implementation (if required)
        }

        public BaseException(System.String IP_str_Message)
            : base(IP_str_Message)
        {
            // Add implementation (if required)
        }

        public BaseException(System.String IP_str_Message, System.Exception IP_obj_InnerException)
            : base(IP_str_Message, IP_obj_InnerException)
        {
            // Add implementation (if required)
        }

        /*protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // Add implementation (if required)
        }*/
    }
}
