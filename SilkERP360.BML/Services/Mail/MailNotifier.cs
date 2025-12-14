using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace SilkERP360.BML.Services.Mail
{
    public class MailNotifier
    {
        private readonly string _mailEngineUrl = "http://192.168.200.55/mailEngine/";

        public MailNotifier()
        {
        }

        /// <summary>
        /// Send a single email via EmailEngine API
        /// </summary>
        public bool SendEmail(string to, string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(to))
                return false;

            try
            {
                var payload = new
                {
                    To = to,
                    Subject = subject,
                    Body = body
                };

                string json = JsonConvert.SerializeObject(payload);
                byte[] data = Encoding.UTF8.GetBytes(json);

                var request = (HttpWebRequest)WebRequest.Create(_mailEngineUrl + "api/Email/send");
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);  // Sync write
                }

                using (var response = (HttpWebResponse)request.GetResponse())  // Sync response
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                // Optionally log exception
                return false;
            }
        }
    }
}
