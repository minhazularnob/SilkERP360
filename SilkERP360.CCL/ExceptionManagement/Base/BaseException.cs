using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.CCL.ExceptionManagement.Base
{
    public class BaseException : System.Exception
    {
        //protected SilkERP360.CCL.Enums.ExceptionOriginatorLayer m_enm_ExceptionOriginatorLayer;
        //protected SilkERP360.CCL.Enums.ExceptionType m_enm_ExceptionType;

        //public SilkERP360.CCL.Enums.ExceptionType ExceptionType
        //{
        //    get { return this.m_enm_ExceptionType; }
        //    //set { m_enm_ExceptionType = value; }
        //}
        //public SilkERP360.CCL.Enums.ExceptionOriginatorLayer ExceptionOriginatorLayer
        //{
        //    get { return this.m_enm_ExceptionOriginatorLayer; }
        //    //set { m_enm_ExceptionOriginatorLayer = value; }
        //}
        public BaseException()
            : base()
        {
            // Add implementation (if required)
            //this.m_enm_ExceptionOriginatorLayer = IP_enm_ExceptionOriginatorLayer;
            //this.m_enm_ExceptionType = IP_enm_ExceptionType;
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
