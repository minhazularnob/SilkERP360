using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailService
{
    public static class MailSettings
    {
        public const System.String SMTP_SERVER_IP = "192.168.200.3";
        public const System.Int32 PORT = 25;
        public const System.String MAIL_SENDER_DISPLAY_NAME = "Silk Autobot";
        public const System.String MAIL_ID = "info@apps.silkways.net";
        public const System.String MAIL_PASSWORD = "Asdf1234";
        
        //private System.Net.Mail.MailMessage m_obj_MailMessage;
        //private System.Net.Mail.SmtpClient m_obj_SmtpClient;
        //private System.Net.Mail.MailAddress m_obj_FromMailAddress;
        //private System.Net.Mail.MailAddress m_obj_ToMailAddress;
    }
}
