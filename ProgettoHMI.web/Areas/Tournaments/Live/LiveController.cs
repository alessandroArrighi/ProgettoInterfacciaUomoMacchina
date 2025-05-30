using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;

namespace ProgettoHMI.web.Areas.Tournaments.Live
{
    [Area("Tournaments")]
    public partial class LiveController : Controller, BaseTournamentController
    {
        private readonly TournamentService _tournamentService;

        public LiveController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public virtual async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();

            var tournaments = await _tournamentService.Query(new TournamentFiltersStatusQuery { Status = Status.Start });

            model.SetTournaments(tournaments);

            return View(model);
        }

        public virtual async Task<IActionResult> TournamentsFilters([FromBody] BaseTournamentsFiltersQueryViewModelTs query)
        {
            query ??= new TournamentsFiltersQueryViewModel{ };

            var tournament = await _tournamentService.Query(new TournamentFiltersStatusQuery
            {
                City = query.City,
                Rank = query.Rank,
                StartDate = query.StartDate,
                EndDate = query.EndDate
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
    }
}