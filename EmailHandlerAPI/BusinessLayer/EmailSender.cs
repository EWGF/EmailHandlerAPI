using System;
using System.Net.Mail;
using EmailHandlerAPI.DataAcessLayer;
using System.Net;

namespace EmailHandlerAPI.BusinessLayer
{
    public class EmailSender : IEmailSender
    {
        public EmailMessage SendEmailMessage(EmailMessage emailMessage)
        {
            string sender = "mymail@foo.com";
            string password = "qwerty";

            MailAddress from = new MailAddress(sender);
            MailAddress to = new MailAddress($"{emailMessage.Recipient}");
            MailMessage message = ConstructMessage(emailMessage, from, to);


            using (SmtpClient stmpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                //works with proper Gmail account settings
                stmpClient.Credentials = new NetworkCredential(sender, password); 
                stmpClient.EnableSsl = true;
                stmpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                try
                {
                    stmpClient.Send(message);
                    emailMessage.DeliveryStatus = "Success";
                }
                catch (Exception ex)
                {
                    //TODO: logging ex;
                    emailMessage.DeliveryStatus = "Failed";
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

            foreach (var item in emailMessage.Carbon_copy_recipients)
            {
                mailMessage.CC.Add(item);
            }

            return mailMessage;
        }
    }
}
