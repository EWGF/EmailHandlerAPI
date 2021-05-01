using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmailHandlerAPI.DataAcessLayer;

namespace EmailHandlerAPI.BusinessLayer
{
    public class DBAcessHandler : DbContext, IDBAcessHandler
    {
        public DbSet<EmailMessage> EmailMessages { get; set; }

        public DBAcessHandler()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EmailsDB;Username=postgres;Password=qwerty");
        }

        public EmailMessage AddEmails(EmailMessage message)
        {
            message.Date = DateTime.Now;
            using (DBAcessHandler DBAcessContext = new DBAcessHandler())
            {
                //var Email = new EmailMessage 
                //{ 
                //    Subject = message.Subject, 
                //    Body = message.Text, 
                //    Recipient = message.Recipient,
                //    Carbon_copy_recipients = message.Carbon_copy_recipients.ToList(), 
                //    Date = DateTime.Now 
                //};

                DBAcessContext.Add(message);
                DBAcessContext.SaveChanges();
                return message;
            }
        }

        public IEnumerable<EmailMessage> GetEmails()
        {
            using (DBAcessHandler DBAcessContext = new DBAcessHandler())
            {
                return DBAcessContext.EmailMessages.ToList();
            }
        }

       
    }
}
