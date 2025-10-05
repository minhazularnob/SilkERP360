/*
This program can be used in any way one sees fit. It needs more testing and if any of you
find/fix bugs I would love to hear from you. If you make enhancements, please send me a copy/link at
mailsash@gmail.com
I haven't tested it fully. In case this screws up any of your work you have only yourselves to blame.

Since this program uses the email functionality, you are advised to tweak/turn-off some features of your anti-virus (esp. McAfee)


USAGE:
(In the OnStart() of your service)
Sathish.ServiceScheduler.Scheduler sch = new Sathish.ServiceScheduler.Scheduler("MyServiceName");
Sathish.ServiceScheduler.MailConfiguration mailConfig = new Sathish.ServiceScheduler.MailConfiguration("yourmail@gmail.com", "admin@yourcompany.com", "Service Down", "localhost", "MyServiceName");
sch.MailComponent = mailConfig; //If you don't do this, all your exceptions will be logged to the event log under "Service Scheduler"
sch.SchedulerFired += new EventHandler(YourServiceMethod); //I used EventHandler because it was straightforward. You can write your own delegate signature.
sch.ScheduleWeekly(DayOfWeek.Friday, "3:00 AM");
//sch.ScheduleMonthly(4, "6:20 PM");
//sch.ScheduleDaily("4:00 AM");

Sathish.P. (mailsash@gmail.com)
*/


using System;
using System.Text;
using System.Net;

namespace SilkERPSync
{
    /// <summary>
    /// Used to configure the mails to be sent in case of exceptions
    /// </summary>
    public class MailConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="To">To addresses separated by semicolon</param>
        /// <param name="From">From addresses separated by semicolon</param>
        /// <param name="Subject">Subject of the mail</param>
        /// <param name="smtpHost">Host used to send the email</param>
        /// <param name="ServiceName">Name of the your service (used in the text of the mail)</param>
        public MailConfiguration(string To, string From, string Subject, string smtpHost, string ServiceName)
        {
            this.to = To;
            this.from = From;
            this.subject = Subject;
            this.SMTPHost = smtpHost;
            this.mailBody = ScriptMailBody(ServiceName);
        }
        public string to;
        public string from;
        public string subject;
        public string SMTPHost;
        public string mailBody;

        private string ScriptMailBody(string serviceName)
        {
            string hostName = Dns.GetHostName();
            IPHostEntry entry = Dns.GetHostEntry(hostName);

            IPAddress[] ipAddr = entry.AddressList;

            StringBuilder sb = new StringBuilder();
            sb.Append("Your service " + serviceName + " has encountered an exception. Details are :" + System.Environment.NewLine);
            sb.Append("Machine Name: " + hostName + System.Environment.NewLine);
            sb.Append("IPAddress: " + ipAddr[0].ToString() + System.Environment.NewLine);
            sb.Append("Details of the exception: " + System.Environment.NewLine);

            return sb.ToString();
        }


    }
}
