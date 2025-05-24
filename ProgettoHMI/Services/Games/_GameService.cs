namespace ProgettoHMI.Services.Games
{
    public partial class GameService
    {
        TemplateDbContext _dbContext;

        public GameService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}