using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Tournament;

namespace ProgettoHMI.web.Areas.Tournaments.Home
{
    [Area("Tournaments")]
    public partial class HomeController : Controller
    {
        TournamentService _tournamentService { get; set; }
        SubscriptionService _subscriptionService { get; set; }

        public HomeController(TournamentService tournamentService, SubscriptionService subscriptionService)
        {
            _tournamentService = tournamentService;
            _subscriptionService = subscriptionService;
        }

        public virtual async Task<IActionResult> Index(Guid TournamentId)
        {
            var tournament = await _tournamentService.Query(new TournamentsIdQuery { Id = TournamentId });
            var users = await _subscriptionService.Query(new UsersSubQuery { TournamentId = TournamentId });

            var model = new IndexViewModel(tournament, users);

            return View(model);
        }
    }
}