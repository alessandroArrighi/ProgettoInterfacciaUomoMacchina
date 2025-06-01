using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProgettoHMI.Services.Tournament;

namespace ProgettoHMI.web.Areas.Tournaments.Home
{
    [Area("Tournaments")]
    public partial class HomeController : Controller
    {
        TournamentService _tournamentService { get; set; }

        public HomeController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        public virtual async Task<IActionResult> Index(Guid TournamentId)
        {
            var tournament = await _tournamentService.Query(new TournamentsIdQuery { Id = TournamentId });

            var model = new IndexViewModel(tournament);

            return View(model);
        }
    }
}