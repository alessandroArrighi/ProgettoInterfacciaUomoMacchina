using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    public class TournamentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
