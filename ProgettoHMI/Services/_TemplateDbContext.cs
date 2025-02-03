using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Infrastructure;
using ProgettoHMI.Services.Shared;

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
    }
}
