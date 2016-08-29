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
        /// <summary>
        /// This method will create the message and send an email to the specified email
        /// </summary>
        /// <param name="email">email address of user to send the email to</param>
        /// <param name="subject">Subject of the email</param>
        /// <param name="message">body of the message</param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var body = message;
            var messageToSend = new MailMessage();
            messageToSend.To.Add(new MailAddress(email));
            messageToSend.From = new MailAddress("Identity Right");
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
