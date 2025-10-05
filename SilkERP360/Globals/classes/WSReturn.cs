using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SilkERP360.Globals.classes
{
    public class WSReturn
    {
        private System.Int32 m_i32_Code;
        private System.String m_str_Message;
        private System.Object m_obj_Data;
        public WSReturn()
        {
            this.m_i32_Code = System.Int32.MinValue;
            this.m_str_Message = System.String.Empty;
            this.m_obj_Data = null;
        }
        public WSReturn(System.Int32 IP_i32_Code, System.String IP_str_Message)
        {
            this.m_i32_Code = IP_i32_Code;
            this.m_str_Message = IP_str_Message;
            this.m_obj_Data = null;
        }
        public WSReturn(System.Int32 IP_i32_Code, System.String IP_str_Message, System.Object IP_obj_Data)
        {
            this.m_i32_Code = IP_i32_Code;
            this.m_str_Message = IP_str_Message;
            this.m_obj_Data = IP_obj_Data;
        }

        public System.Int32 Code
        {
            get
            {
                return this.m_i32_Code;
            }
        }

        public System.String Message
        {
            get
            {
                return this.m_str_Message;
            }
        }

        public System.Object Data
        {
            get
            {
                return this.m_obj_Data;
            }
            set
            {
                this.m_obj_Data = value;
            }
        }
    }
}