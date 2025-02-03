using Microsoft.Extensions.DependencyInjection;
using ProgettoHMI.web.SignalR;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.web
{
    public class Container
    {
        public static void RegisterTypes(IServiceCollection container)
        {
            // Registration of all the database services you have
            container.AddScoped<SharedService>();

            // Registration of SignalR events
            container.AddScoped<IPublishDomainEvents, SignalrPublishDomainEvents>();
        }
    }
}
