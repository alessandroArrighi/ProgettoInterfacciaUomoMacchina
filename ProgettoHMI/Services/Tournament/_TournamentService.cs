namespace ProgettoHMI.Services.Tournament
{
    public partial class TournamentService
    {
        TemplateDbContext _dbContext;

        public TournamentService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}