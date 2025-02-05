using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    [Area("Tournaments")]
    public partial class TournamentsController : Controller
    {
        public virtual IActionResult Index()
        {
            return View();
        }
    }
}
