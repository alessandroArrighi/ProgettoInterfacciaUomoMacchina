using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoHMI.Services.Statistics
{
    public class Statistics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
