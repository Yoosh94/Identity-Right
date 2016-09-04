using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.OptionsModel;
using Newtonsoft.Json.Linq;

namespace IdentityRight.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSender(IOptions<TextMessageApiConfiguration> smsConfigAccessor)
        {
            SmsConfig = smsConfigAccessor.Value;
        }

        public TextMessageApiConfiguration SmsConfig { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            // Using the Telstra SMS API
            try
            {
                SendSms(GetAccessToken(), number, message);
                return Task.FromResult(0);
            }
            catch (Exception)
            {
                return Task.FromResult(-1);
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string GetAccessToken()
        {
            var url = "";
            var consumerKey = Base64Decode("ZEFaTVdQc1ZZUE1GOUJ0SU5sM25WMEI3VXltWEEwQUc=");
            var consumerSecret = Base64Decode("bkltdW5wajFjMDJpZWxGUw==");

            url =
                $"https://api.telstra.com/v1/oauth/token?client_id={consumerKey}&client_secret={consumerSecret}&grant_type=client_credentials&scope=SMS";

            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(url);
                var obj = JObject.Parse(json);
                return obj.GetValue("access_token").ToString();
            }
        }

        public void SendSms(string token, string recipientNumber, string message)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    webClient.Headers.Clear();
                    webClient.Headers.Add(HttpRequestHeader.ContentType, @"application/json");
                    webClient.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                    var data = "{\"to\":\"" + recipientNumber + "\", \"body\":\"" + message + "\"}";
                    webClient.UploadData("https://api.telstra.com/v1/sms/messages", "POST",
                        Encoding.Default.GetBytes(data));
                }
            }
            catch
            {
                // Suppress Errors for now
            }
        }
    }
}