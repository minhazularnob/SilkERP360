using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SilkERP360.CCL.ModelClass;


public class SmsNotifier
{
    private readonly string _smsEngineUrl = "http://192.168.200.55/smsEngine/api/Sms/";

    public void SendDynamicMessages(List<DynamicMessage> messages)
    {
        if (messages == null || messages.Count == 0) return;
        SendRequest(new { Messages = messages }, "dynamic");
    }

    public void SendSingleMessage(string phoneNumber, string message)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(message))
            return;

        var payload = new
        {
            PhoneNumber = phoneNumber,
            Message = message
        };

        SendRequest(payload, "single");
    }

    public void SendBulkMessages(List<string> phoneNumbers, string message)
    {
        if (phoneNumbers == null || phoneNumbers.Count == 0 || string.IsNullOrWhiteSpace(message))
            return;

        var payload = new
        {
            Recipients = phoneNumbers,
            Message = message
        };

        SendRequest(payload, "bulk");
    }

    private void SendRequest(object payload, string endpoint)
    {
        string jsonBody = JsonConvert.SerializeObject(payload);
        string requestUrl = _smsEngineUrl + endpoint;

        var httpRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
        httpRequest.Method = "POST";
        httpRequest.ContentType = "application/json";
        httpRequest.Timeout = 15000;

        try
        {
            using (var writer = new StreamWriter(httpRequest.GetRequestStream()))
                writer.Write(jsonBody);

            using (var httpResponse = (HttpWebResponse)httpRequest.GetResponse())
            using (var reader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string responseText = reader.ReadToEnd();
                // Optional: parse or log response
            }
        }
        catch (WebException ex)
        {
            string errorText = string.Empty;
            if (ex.Response != null)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    errorText = reader.ReadToEnd();
            }
            throw new Exception($"SMS API Failed: {errorText}", ex);
        }
    }
}