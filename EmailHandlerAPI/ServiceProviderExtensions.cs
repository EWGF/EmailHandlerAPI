using EmailHandlerAPI.BusinessLayer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailHandlerAPI
{
    public static class ServiceProviderExtensions
    {

        public static void AddDBAcessHandler(this IServiceCollection services)
        {
            services.AddScoped<IDBAcessHandler>(x => new DBAcessHandler());
        }

        public static void AddEmailSender(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender>(x => new EmailSender());
        }

    }
}
