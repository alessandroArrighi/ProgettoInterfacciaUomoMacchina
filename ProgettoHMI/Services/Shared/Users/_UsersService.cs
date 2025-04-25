namespace ProgettoHMI.Services.Shared.Users
{
    public partial class UsersService
    {
        TemplateDbContext _dbContext;

        public UsersService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
