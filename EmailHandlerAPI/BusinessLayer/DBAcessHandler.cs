using System;
using System.Collections.Generic;
using System.Linq;
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
