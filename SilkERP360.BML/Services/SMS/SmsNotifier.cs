using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SilkERP360.CCL.ModelClass;

public class SmsNotifier
{
    // Base URL of SMS engine (can be moved to config)
    private readonly string _rootApiUrl = "http://192.168.200.55/smsEngine/api/Sms/";

    public void SendDynamicSmsToApprovers(Dictionary<string, List<string>> employeeInfo, string messageText)
    {
        if (employeeInfo == null || employeeInfo.Count == 0)
            return; // Nothing to send

        var messages = new List<DynamicMessage>();

        // Flatten employee info into messages
        foreach (var approver in employeeInfo)
        {
            var employeeName = approver.Key;
            foreach (var phone in approver.Value)
            {
                if (string.IsNullOrWhiteSpace(phone))
                    continue;

                messages.Add(new DynamicMessage
                {
                    PhoneNumber = phone,
                    Message = $"{employeeName}, {messageText}" // cleaner formatting
                });
            }
        }

        if (messages.Count == 0)
            return;

        // Serialize request
        var requestData = new DynamicSmsRequest { Messages = messages };
        var jsonBody = JsonConvert.SerializeObject(requestData);

        // Send HTTP POST request
        var requestUrl = _rootApiUrl + "dynamic";
        var httpRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/json";
        httpRequest.Timeout = 15000; // 15 sec timeout

        try
        {
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonBody);
            }

            using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                // Optional: log or handle response if needed
            }
        }
        catch (WebException ex)
        {
            string errorText = string.Empty;

            if (ex.Response != null)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    errorText = reader.ReadToEnd();
                }
            }

            throw new Exception($"Dynamic SMS API Failed: {errorText}", ex);
        }
    }
}