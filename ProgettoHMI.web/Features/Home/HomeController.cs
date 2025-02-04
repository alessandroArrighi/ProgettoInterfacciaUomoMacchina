using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Players;
using ProgettoHMI.Services.Tournaments;

namespace ProgettoHMI.web.Features.Home
{
    public partial class HomeController : Controller
    {
        public HomeController()
        {
        }

        [HttpGet]
        public virtual IActionResult Index()
        {
            ViewData["ShowHeader"] = false;
            var model = new HomeViewModel();
            var players = PlayersService.Query();
            var tournaments = TournamentService.Query();

            model.setPlayers(players);
            model.setTournaments(tournaments);

            return View(model);
        }

        [HttpGet]
        public virtual IActionResult Prova()
        {
            ViewData["ShowHeader"] = false;
            return View();
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
