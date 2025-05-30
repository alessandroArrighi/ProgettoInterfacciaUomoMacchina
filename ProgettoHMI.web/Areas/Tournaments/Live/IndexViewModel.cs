using System.Collections.Generic;
using System.Linq;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Live
{
    public class IndexViewModel : BaseTournamentViewModel
    {
        public IEnumerable<BaseTournamentViewModelTs> Tournaments { get; set; }

        public void SetTournaments(TournamentsFiltersDTO tournaments)
        {
            Tournaments = tournaments.Tournaments.Select(x => new TournamentViewModel
            {
                Id = x.Id,
                Name = x.Name,
                RankId = x.Rank.Id,
                ImgRank = x.Rank.ImgRank
            });
        }
    }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class TournamentViewModel : BaseTournamentViewModelTs {}

    [TypeScriptModule("Tournaments.Live.Server")]
    public class TournamentsFiltersQueryViewModel : BaseTournamentsFiltersQueryViewModelTs {}
}