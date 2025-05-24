using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoHMI.Services.Statistics
{
    public class Statistic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IDUser { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int Aces { get; set; }
        public int DoubleFaults { get; set; }
        public int FirstService {  get; set; }
        public int SecondService { get; set; }
        public int Returns { get; set; }
    }
}
