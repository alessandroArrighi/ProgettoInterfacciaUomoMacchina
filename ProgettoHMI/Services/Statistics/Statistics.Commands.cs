using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Statistics
{
    public class AddOrUpdateStatisticCommand
    {
        public Guid IDUser { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int Aces { get; set; }
        public int DoubleFaults { get; set; }
        public int FirstService { get; set; }
        public int SecondService { get; set; }
        public int Returns { get; set; }
    }

    public partial class StatisticsService
    {
        public async Task<Guid> Handle(AddOrUpdateStatisticCommand cmd)
        {
            var statistic = await _dbContext.Statistics
                .Where(x => x.IDUser == cmd.IDUser)
                .FirstOrDefaultAsync();

            if (statistic == null)
            {
                statistic = new Statistic
                {
                    IDUser = cmd.IDUser,
                    MatchesPlayed = cmd.MatchesPlayed,
                    MatchesWon = cmd.MatchesWon,
                    MatchesLost = cmd.MatchesLost,
                    Aces = cmd.Aces,
                    DoubleFaults = cmd.DoubleFaults,
                    FirstService = cmd.FirstService,
                    SecondService = cmd.SecondService,
                    Returns = cmd.Returns
                };
                _dbContext.Statistics.Add(statistic);
            }
            else
            {
                statistic.MatchesPlayed = cmd.MatchesPlayed;
                statistic.MatchesWon = cmd.MatchesWon;
                statistic.MatchesLost = cmd.MatchesLost;
                statistic.Aces = cmd.Aces;
                statistic.DoubleFaults = cmd.DoubleFaults;
                statistic.FirstService = cmd.FirstService;
                statistic.SecondService = cmd.SecondService;
                statistic.Returns = cmd.Returns;
            }

            await _dbContext.SaveChangesAsync();

            return statistic.IDUser;
        }
    }
}
