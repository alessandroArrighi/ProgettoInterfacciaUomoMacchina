using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Games;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;

namespace ProgettoHMI.web.Areas.Tournaments.Live
{
    [Area("Tournaments")]
    public partial class LiveController : Controller, BaseTournamentController<TournamentsFiltersQueryViewModel>
    {
        private readonly TournamentService _tournamentService;
        private readonly GameService _gameService;

        public LiveController(TournamentService tournamentService, GameService gameService)
        {
            _tournamentService = tournamentService;
            _gameService = gameService;
        }

        public virtual async Task<IActionResult> Index()
        {
            BaseTournamentViewModel model = new IndexViewModel();

            var tournaments = await _tournamentService.Query(new TournamentFiltersStatusQuery { Status = Services.Tournament.Status.Start });

            model.SetTournaments(tournaments);

            return View(model);
        }

        public virtual async Task<IActionResult> TournamentsFilters([FromBody] TournamentsFiltersQueryViewModel query)
        {
            query ??= new TournamentsFiltersQueryViewModel { };

            var tournament = await _tournamentService.Query(new TournamentFiltersStatusQuery
            {
                City = query.City,
                Rank = query.Rank,
                StartDate = query.StartDate,
                EndDate = query.EndDate,
                Status = (Services.Tournament.Status)query.Status
            });

            if (tournament == null)
            {
                return Json(new TournamentViewModel { });
            }

            return Json(tournament.Tournaments.Select(t => new TournamentViewModel
            {
                Id = t.Id,
                Name = t.Name,
                RankId = t.Rank.Id,
                ImgRank = t.Rank.ImgRank
            }));
        }

        [HttpGet]
        public virtual async Task<IActionResult> GamesLive(Guid tournamentId)
        {
            var games = await _gameService.Query(new GameStatusQuery { Status = Services.Games.Status.Start, TournamentId = tournamentId });

            if (games == null)
            {
                return Json(new GameStatusDTO { });
            }

            var json = Infrastructure.JsonSerializer.ToJsonCamelCase(games.Games);

            return Content(json, "application/json");
        }
    }
}