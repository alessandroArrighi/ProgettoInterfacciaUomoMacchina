using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel.Resolution;
using ProgettoHMI.Services.Tournament;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    [Area("Tournaments")]
    public partial class TournamentsController : Controller
    {
        private readonly TournamentService _tournamentService;

        public TournamentsController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public virtual  async Task<IActionResult> Index()
        {
            var model = new IndexViewModel();

            var tournaments = await _tournamentService.Query(new TournamentsFiltersQuery { });

            model.SetTournaments(tournaments);

            return View(model);
        }

        [HttpPost]
        public virtual async Task<IActionResult> TournamentsFilters([FromBody] TournamentsFiltersQueryViewModel query)
        {
            query ??= new TournamentsFiltersQueryViewModel{ };

            var tournament = await _tournamentService.Query(new TournamentsFiltersQuery
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

        public virtual IActionResult Draw()
        {
            return View();
        }
    }
}
