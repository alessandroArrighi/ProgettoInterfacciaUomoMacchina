using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Statistics
{

    public class StatsUserQuery
    {
        public Guid IDUser { get; set; }
    }

    public class StatsUserDTO
    {
        public Statistic Stats { get; set; }
        public class Statistic
        {
            public int MatchesPlayed { get; set; }
            public int MatchesWon { get; set; }
            public int MatchesLost { get; set; }
            public int Aces { get; set; }
            public int DoubleFaults { get; set; }
            public int FirstService { get; set; }
            public int SecondService { get; set; }
            public int Returns { get; set; }
        }
    }


    public partial class StatisticsService
    {

        public async Task<StatsUserDTO> Query(StatsUserQuery qry)
        {
            var stats = await _dbContext.Statistics
                .Where(Statistics => Statistics.IDUser == qry.IDUser)
                .Select(x => new StatsUserDTO.Statistic
                {
                    MatchesPlayed = x.MatchesPlayed,
                    MatchesWon = x.MatchesWon,
                    MatchesLost = x.MatchesLost,
                    Aces = x.Aces,
                    DoubleFaults = x.DoubleFaults,
                    FirstService = x.FirstService,
                    SecondService = x.SecondService,
                    Returns = x.Returns
                })
                .FirstOrDefaultAsync();


            return new StatsUserDTO
            {
                Stats = stats
            };
        }
    }
}
