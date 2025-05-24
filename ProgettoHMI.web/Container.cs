using Microsoft.Extensions.DependencyInjection;
using ProgettoHMI.web.SignalR;
using ProgettoHMI.Services.Shared;
using ProgettoHMI.Services.Games;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.web
{
    public class Container
    {
        public static void RegisterTypes(IServiceCollection container)
        {
            // Registration of all the database services you have

            container.AddScoped<SharedService>();
            container.AddScoped<TournamentService>();
            container.AddScoped<GameService>();
            container.AddScoped<UsersService>();

            // Registration of SignalR events
            container.AddScoped<IPublishDomainEvents, SignalrPublishDomainEvents>();
        }
    }
}
