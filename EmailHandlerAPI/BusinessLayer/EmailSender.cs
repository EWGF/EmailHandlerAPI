using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;
using EmailHandlerAPI.DataAcessLayer;
using System.Net;

namespace EmailHandlerAPI.BusinessLayer
{
    public class EmailSender : IEmailSender
    {
        public EmailMessage SendEmailMessage(EmailMessage emailMessage)
        {
            MailAddress from = new MailAddress("MyEmailServer@localhost.ru");
            MailAddress to = new MailAddress($"{emailMessage.Recipient}");
            MailMessage message = ConstructMessage(emailMessage, from, to);

            using (SmtpClient stmpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                stmpClient.Credentials = new NetworkCredential("somemail@gmail.com", "mypassword");
                stmpClient.EnableSsl = true;

                try 
                {
                    stmpClient.Send(message);
                    emailMessage.DeliveryStatus = "Success";
                }
                catch (Exception ex)
                {
                    //ex can be used for logging
                    emailMessage.DeliveryStatus = $"Failed";
                }

                return emailMessage;
            }
        }

        private MailMessage ConstructMessage(EmailMessage emailMessage, MailAddress from, MailAddress to)
        {
            MailMessage mailMessage = new MailMessage(from, to);

            mailMessage.Subject = emailMessage.Subject;
            mailMessage.Body = emailMessage.Body;
            mailMessage.IsBodyHtml = false;
            return mailMessage;
        }
    }
}
