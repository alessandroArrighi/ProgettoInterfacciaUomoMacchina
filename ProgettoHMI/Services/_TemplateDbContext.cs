using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Infrastructure;
using T = ProgettoHMI.Services.Tournament;
using ProgettoHMI.Services.Games;
using ProgettoHMI.Services.Ranks;
using ProgettoHMI.Services.Statistics;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.Services
{
    public class TemplateDbContext : DbContext
    {
        public TemplateDbContext()
        {
        }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<T.Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Subscription> Subscriptions {  get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Statistic> Statistics { get; set; }

    }
}
