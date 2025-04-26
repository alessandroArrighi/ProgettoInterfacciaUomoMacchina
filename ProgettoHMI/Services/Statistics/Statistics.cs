using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Statistics
{
    public class Statistics
    {
        public Guid IDUser { get; set; }
        public string IDTournament { get; set; }
        public int PointsGained { get; set; } = 0;
        public int PointsLost { get; set; } = 0;
        public int PointsTotal { get; set; } = 0;
        public int MatchesPlayed { get; set; } = 0;
        public int MatchesWon { get; set; } = 0;
        public int MatchesLost { get; set; } = 0;
        public int MatchesDrawn { get; set; } = 0;
    }
}
