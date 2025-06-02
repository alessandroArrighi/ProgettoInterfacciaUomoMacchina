using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var logged = false;

            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                logged = true;
                ViewData["isLogin"] = true;
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var model = new IndexViewModel(tournament, users, logged, userId);

            model.setRegisterUrl(Url, MVC.Tournaments.Home.Register());

            return View(model);
        }

        public virtual async Task<IActionResult> Register(Guid TournamentId, Guid UserId)
        {
            try
            {
                if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
                {
                    var startDate = (await _tournamentService.Query(new TournamentsIdQuery { Id = TournamentId })).StartDate;

                    if (DateTime.Compare(startDate, DateTime.Now) <= 0)
                    {
                        throw new Exception("Tournament already started");
                    }

                    var res = await _subscriptionService.Handle(new AddOrUpdateSubscriptionCommand
                    {
                        IDTournament = TournamentId,
                        IDUser = UserId,
                        PointsGained = 0
                    });

                    return Json(new { UserId = res });
                }
                else
                {
                    throw new Exception("User not loggedIn");
                }
            }
            catch
            {
                return Json(null);
            }

        }
    }
}