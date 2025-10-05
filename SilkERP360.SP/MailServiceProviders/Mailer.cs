using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace SilkERP360.SP.MailServiceProviders
{
    public class Mailer
    {
        protected System.Net.Mail.MailMessage m_obj_MailMessage;
        protected System.Net.Mail.SmtpClient m_obj_SmtpClient;
        protected System.Net.Mail.MailAddress m_obj_FromMailAddress;
        protected System.Net.Mail.MailAddress m_obj_ToMailAddress;

        public Mailer(System.Collections.Generic.List<System.String> IP_objLst_MailToList, System.Collections.Generic.List<System.String> IP_objLst_MailCcList)
        {
            this.m_obj_SmtpClient = new SmtpClient(SilkERP360.SP.MailServiceProviders.MailSettings.SMTP_SERVER_IP, SilkERP360.SP.MailServiceProviders.MailSettings.PORT);
            this.m_obj_SmtpClient.Timeout = 600000;
            this.m_obj_SmtpClient.EnableSsl = false;
            this.m_obj_SmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            this.m_obj_SmtpClient.UseDefaultCredentials = false;
            this.m_obj_SmtpClient.Credentials = new NetworkCredential(SilkERP360.SP.MailServiceProviders.MailSettings.MAIL_ID, SilkERP360.SP.MailServiceProviders.MailSettings.MAIL_PASSWORD);

            this.m_obj_FromMailAddress = new MailAddress(SilkERP360.SP.MailServiceProviders.MailSettings.MAIL_ID, SilkERP360.SP.MailServiceProviders.MailSettings.MAIL_SENDER_DISPLAY_NAME);
            this.m_obj_ToMailAddress = new MailAddress(IP_objLst_MailToList[0]);
            this.m_obj_MailMessage = new MailMessage(this.m_obj_FromMailAddress, this.m_obj_ToMailAddress);
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
