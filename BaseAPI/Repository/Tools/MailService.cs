using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace BaseAPI.Repository.Tools
{
    public class MailService : IMailService
    {
        private IMailConfig _mailConfig;

        public MailService(IMailConfig mailConfig)
        {
            _mailConfig = mailConfig;
        }
        public void SendMail(string to, string msg, string subject)
        {
            var message = new MailMessage(new MailAddress(_mailConfig.serverUserId), new MailAddress(to));
            // replace with receiver's email id  
            //message.From = new MailAddress(_mailConfig.serverUserId);  // replace with sender's email id 
            message.Subject = subject;
            message.Body = msg;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _mailConfig.serverUserId,  // replace with sender's email id 
                    Password = _mailConfig.password  // replace with password 
                };
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = credential;
                smtp.Host = _mailConfig.smtpHost;
                smtp.Port = _mailConfig.serverPort;
                smtp.EnableSsl = true;
                smtp.Send(message);
                smtp.Dispose();
            }
        }
    }
}
