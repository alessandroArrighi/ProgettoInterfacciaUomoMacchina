using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.Services.Users;
using ProgettoHMI.web.Infrastructure;
//using ProgettoHMI.Services.Players;
//using ProgettoHMI.Services.Shared.Tournaments;

namespace ProgettoHMI.web.Features.Home
{
    [Alerts]
    public partial class HomeController : Controller
    {
        private readonly UsersService _playerService;
        private readonly TournamentService _tournamentService;
        public HomeController(UsersService playerService, TournamentService tournamentsService)
        {
            _playerService = playerService;
            _tournamentService = tournamentsService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            var players = await _playerService.Query();
            var tournaments = await _tournamentService.Query(new TournamentsSelectQuery
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            });

            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                ViewData["isLogin"] = true;
            }

            model.setPlayers(players);
            model.setTournaments(tournaments);

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult ChangeLanguageTo(string cultureName)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cultureName)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), Secure = true }    // Secure assicura che il cookie sia inviato solo per connessioni HTTPS
            );

            return Redirect(Request.GetTypedHeaders().Referer.ToString());
        }
    }
}
