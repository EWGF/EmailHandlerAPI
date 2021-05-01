using System.Collections.Generic;
using EmailHandlerAPI.DataAcessLayer;

namespace EmailHandlerAPI.BusinessLayer
{
    public interface IDBAcessHandler
    {
        EmailMessage AddEmails(EmailMessage message);
        IEnumerable<EmailMessage> GetEmails();
    }
}
