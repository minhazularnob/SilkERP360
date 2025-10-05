using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace SilkERPSync
{
    public class SilkMailer
    {
        private const System.String SMTP_SERVER_IP = "192.168.200.29";
        private const System.Int32 PORT = 25;
        private const System.String MAIL_SENDER_DISPLAY_NAME = "Silk Autobot";
        private const System.String MAIL_ID = "info@apps.silkways.net";
        private const System.String MAIL_PASSWORD = "Asdf@1234";

        //private const System.String SMTP_SERVER_IP = "smtp.gmail.com";
        //private const System.Int32 PORT = 587;
        //private const System.String MAIL_SENDER_DISPLAY_NAME = "Silk-Agrani Services";
        //private const System.String MAIL_ID = "pallab.gt@gmail.com";
        //private const System.String MAIL_PASSWORD = "2608Unicorn@2501";


        private System.Net.Mail.MailMessage m_obj_MailMessage;
        private System.Net.Mail.SmtpClient m_obj_SmtpClient;
        private System.Net.Mail.MailAddress m_obj_FromMailAddress;
        private System.Net.Mail.MailAddress m_obj_ToMailAddress;

        public SilkMailer(System.Collections.Generic.List<System.String> IP_objLst_MailToList, System.Collections.Generic.List<System.String> IP_objLst_MailCcList)
        {
            this.m_obj_SmtpClient = new SmtpClient(SilkMailer.SMTP_SERVER_IP, SilkMailer.PORT);
            this.m_obj_SmtpClient.Timeout = 600000;
            this.m_obj_SmtpClient.EnableSsl = false;
            this.m_obj_SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            this.m_obj_SmtpClient.UseDefaultCredentials = true;
            this.m_obj_SmtpClient.Credentials = new NetworkCredential(MAIL_ID, MAIL_PASSWORD);

            this.m_obj_FromMailAddress = new MailAddress(MAIL_ID, MAIL_SENDER_DISPLAY_NAME);
            this.m_obj_ToMailAddress = new MailAddress(IP_objLst_MailToList[0]);
            this.m_obj_MailMessage = new MailMessage();//(this.m_obj_FromMailAddress, this.m_obj_ToMailAddress);
            this.m_obj_MailMessage.From = this.m_obj_FromMailAddress;
            //this.m_obj_MailMessage.From.Address = MAIL_ID;
            foreach (System.String lcl_str_MailTo in IP_objLst_MailToList)
            {
                this.m_obj_MailMessage.To.Add(lcl_str_MailTo);
            }
            if (IP_objLst_MailCcList != null)
            {
                foreach (System.String lcl_str_MailCc in IP_objLst_MailCcList)
                {
                    this.m_obj_MailMessage.CC.Add(lcl_str_MailCc);
                }
            }

        }

        public void SendMail(System.String IP_str_Subject, System.String IP_str_MailBodyHTML)
        {
            try
            {

                //this.m_obj_MailMessage.From.Address = MAIL_ID;
                this.m_obj_MailMessage.Subject = IP_str_Subject;
                this.m_obj_MailMessage.Body = IP_str_MailBodyHTML;
                this.m_obj_MailMessage.IsBodyHtml = true;
                this.m_obj_MailMessage.Priority = MailPriority.High;
                this.m_obj_SmtpClient.Send(this.m_obj_MailMessage);
                //Console.WriteLine("MAIL SENT SUCCESSFULLY!!");
                //Console.ReadLine();
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
        }
    }
}
