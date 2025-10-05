using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement.Exceptions
{
    public class UIProcessedException : SilkERP360.CCL.ExceptionManagement.Base.BaseException
    {
        private SilkERP360.CCL.ExceptionManagement.ExceptionInfo m_obj_ExceptionInfo;

        public SilkERP360.CCL.ExceptionManagement.ExceptionInfo ExceptionInfo
        {
            get { return this.m_obj_ExceptionInfo; }
        }
        public UIProcessedException()
            : base()
        {
            // Add implementation (if required)
        }

        public UIProcessedException(System.String IP_str_Message,SilkERP360.CCL.ExceptionManagement.ExceptionInfo IP_obj_ExceptionInfo)
            : base(IP_str_Message)
        {
            // Add Implementation (if required)
            this.m_obj_ExceptionInfo = IP_obj_ExceptionInfo;
        }

        public UIProcessedException(System.String IP_str_Message, System.Exception IP_obj_InnerException)
            : base(IP_str_Message, IP_obj_InnerException)
        {
            // Add implementation (if required)
        }

        public UIProcessedException(System.String IP_str_Message)
            : base(IP_str_Message)
        {
            // Add implementation (if required)
        }
    }
}
