using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SilkERP360.SP.MailServiceProviders
{
    public static class MailSettings
    {
        public const System.String SMTP_SERVER_IP = "192.168.200.3";
        public const System.Int32 PORT = 25;
        public const System.String MAIL_SENDER_DISPLAY_NAME = "Silk Autobot-Silkcard Production Service";
        public const System.String MAIL_ID = "info@apps.silkways.net";
        public const System.String MAIL_PASSWORD = "Asdf1234";

        //public const System.String SMTP_SERVER_IP = "smtp.gmail.com";
        //public const System.Int32 PORT = 587;
        //public const System.String MAIL_SENDER_DISPLAY_NAME = "Silk AutoBot-SilkcardProductionService";
        //public const System.String MAIL_ID = "pallab.gt@gmail.com";
        //public const System.String MAIL_PASSWORD = "2608Unicorn@2501";
        //private System.Net.Mail.MailMessage m_obj_MailMessage;
        //private System.Net.Mail.SmtpClient m_obj_SmtpClient;
        //private System.Net.Mail.MailAddress m_obj_FromMailAddress;
        //private System.Net.Mail.MailAddress m_obj_ToMailAddress;
    }
}
