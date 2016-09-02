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
            string htmlemail = "< !DOCTYPE html >< html xmlns=\"http://www.w3.org/1999/xhtml\"><meta content=\"text/html; charset=UTF-8\"http-equiv=Content-Type><title>Responsive Email Template</title><style>.ReadMsgBody{width:100%;background-color:#fff}.ExternalClass{width:100%;background-color:#fff}body{width:100%;background-color:#fff;margin:0;padding:0;-webkit-font-smoothing:antialiased;font-family:Georgia,Times,serif}table{border-collapse:collapse}@media only screen and (max-width:640px){body[yahoo] .deviceWidth{width:440px!important;padding:0}body[yahoo] .center{text-align:center!important}}@media only screen and (max-width:479px){body[yahoo] .deviceWidth{width:280px!important;padding:0}body[yahoo] .center{text-align:center!important}}</style><body leftmargin=0 marginheight=0 marginwidth=0 style=font-family:Georgia,Times,serif topmargin=0 yahoo=fix><table align=center border=0 cellpadding=0 cellspacing=0 width=100%><tr><td style=padding-top:20px valign=top bgcolor=#ffffff width=100%><table align=center border=0 cellpadding=0 cellspacing=0 width=580 bgcolor=#eeeeed width=\"200\" style=\"margin:0 auto\"><tr><td style=padding:0 valign=top bgcolor=#ffffff><a href=#><img alt=\"\"border=0 src=https://eoa-editor.s3.amazonaws.com/77ccef5867d8dd55131dbabfc20f45ad1459aa51%2FIR_logo.png class=deviceWidth style=display:block;border-radius:4px></a><tr><td style=\"font-size:13px;color:#959595;font-weight:400;text-align:left;font-family:Georgia,Times,serif;line-height:24px;vertical-align:top;padding:10px 8px 10px 8px\"bgcolor=#eeeeed><table><tr><td style=\"padding:0 10px 10px 0\"valign=top><img alt=\"\"border=0 src=http://placehold.it/38x40 align=left><td style=\"padding:0 10px 10px 0\"valign=middle><a href=# style=text-decoration:none;color:#272727;font-size:16px;color:#272727;font-weight:700;font-family:Arial,sans-serif>Final Step</a></table>Thankyou for registering with Identity Right."+message+".</table></table><div style=\"display:none;white-space:nowrap;font:15px courier;color:#fff\">- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -</div>";
    

            var body = message;
            var messageToSend = new MailMessage();
            messageToSend.To.Add(new MailAddress(email));
            messageToSend.From = new MailAddress("identityright@gmail.com", "Identity Right");
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
            smtp.SendCompleted += (s, e) =>
            {
                SendCompletedCallBack(s, e);
                smtp.Dispose();
                messageToSend.Dispose();
                System.Diagnostics.Debug.WriteLine("Email sent successfully");
            };

            smtp.SendAsync(messageToSend, null);                             
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
