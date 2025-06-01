using System;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;

namespace ProgettoHMI.web.Areas.Tournaments.Home
{
    public class IndexViewModel
    {
        
    }

    public class TournamentViewModel : BaseTournamentViewModelTs
    {
        public string Club { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public Status Status { get; set; }
    }
}