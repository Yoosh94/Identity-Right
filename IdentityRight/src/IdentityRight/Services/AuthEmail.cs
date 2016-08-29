using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace IdentityRight.Services
{
    public class AuthEmail :IEmailSender
    {
        public void SendEmail(string email, string subject, string message)
        {
            var body = "This is the test email. It seems like you have been signed up for Identity Right.";

            var messageToSend = new MailMessage();
            messageToSend.To.Add(new MailAddress(email));
            messageToSend.From = new MailAddress("identityright@gmail.com");
            messageToSend.Subject = subject;
            messageToSend.Body = body;
            messageToSend.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credentials = new NetworkCredential
                {
                    UserName = "identityright@gmail.com",
                    Password = "deakinSIT302"
                };
                smtp.Credentials = credentials;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(messageToSend);
            }
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var body = message;

            var messageToSend = new MailMessage();
            messageToSend.To.Add(new MailAddress(email));
            messageToSend.From = new MailAddress("identityright@gmail.com");
            messageToSend.Subject = subject;
            messageToSend.Body = body;
            messageToSend.IsBodyHtml = true;
            var smtp = new SmtpClient();         
            var credentials = new NetworkCredential
            {
                UserName = "identityright@gmail.com",
                Password = "deakinSIT302"
            };
            smtp.Credentials = credentials;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            Object state = messageToSend;
            smtp.SendCompleted += (s, e) =>
            {
                SendCompletedCallBack(s, e);
                smtp.Dispose();
                messageToSend.Dispose();
                System.Diagnostics.Debug.WriteLine("Email sent successfully");
            };
            smtp.SendAsync(messageToSend,null);            
            
            return Task.FromResult(0);
        }

        void SendCompletedCallBack(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;

            if (!e.Cancelled && e.Error != null)
            {
               
            }
        }
    }
}
