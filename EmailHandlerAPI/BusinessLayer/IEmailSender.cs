using EmailHandlerAPI.DataAcessLayer;

namespace EmailHandlerAPI.BusinessLayer
{
    public interface IEmailSender
    {
        public EmailMessage SendEmailMessage(EmailMessage emailMessage);
    }
}
