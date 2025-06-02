using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Live
{
    public class IndexViewModel : BaseGameViewModel, BaseTournamentViewModel
    {
        public IEnumerable<BaseTournamentViewModelTs> Tournaments { get; set; }
        public string UrlFilters { get; set; }
        public string UrlGames { get; set; }

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

        public void SetUrlFilters(IUrlHelper url, IActionResult action)
        {
            this.UrlFilters = url.Action(action);
        }

        public void SetUrlGames(IUrlHelper url, IActionResult action)
        {
            this.UrlGames = url.Action(action);
        }

    }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class TournamentViewModel : BaseTournamentViewModelTs { }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class TournamentsFiltersQueryViewModel : BaseTournamentsFiltersQueryViewModelTs
    {
        public int Status { get; set; }
    }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class GameViewModel : BaseGameViewModelTs<ScoreSetViewModel> { }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class UserViewModel : UserViewModelTs { }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class RankViewModel : RankViewModelTs { }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class ScoreViewModel : ScoreViewModelTs<ScoreSetViewModel> { }

    [TypeScriptModule("Tournaments.Live.Server")]
    public class ScoreSetViewModel : ScoreSetViewModelTs { }
}