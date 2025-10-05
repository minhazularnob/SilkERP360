using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.Validation.ErrorsExceptions
{
    public class ValidationException : System.ApplicationException
    {
        public ValidationException()
            : base()
        {
            
        }

        public ValidationException(System.String IP_str_Message) 
            : base(IP_str_Message)
        {
        }
        public ValidationException(System.String IP_str_Message,System.Exception IP_obj_InnerException)
            : base(IP_str_Message,IP_obj_InnerException)
        {
        }
    }
}
