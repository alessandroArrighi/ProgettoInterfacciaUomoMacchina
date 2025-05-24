using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
//using ProgettoHMI.Services.Players;
//using ProgettoHMI.Services.Shared.Tournaments;

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
            var model = new HomeViewModel();
            var players = new PlayerDTO[]
            {
                new PlayerDTO { Name = "John", Surname = "Doe", Rank = "1", Points = "1500", Img = "/images/john.jpg" },
                new PlayerDTO { Name = "Jane", Surname = "Smith", Rank = "2", Points = "1400", Img = "/images/jane.jpg" }
            };

            var tournaments = new TournamentDTO[]
            {
                new TournamentDTO { TournamentName = "Spring Open", FieldName = "Central Court", Date = "2023-10-15", Img = "/images/spring_open.jpg" },
                new TournamentDTO { TournamentName = "Summer Cup", FieldName = "Court 1", Date = "2023-11-20", Img = "/images/summer_cup.jpg" }
            };

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
