using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Infrastructure;
using ProgettoHMI.Services.Shared;
using T = ProgettoHMI.Services.Tournament;
using ProgettoHMI.Services.Games;

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
    }
}
