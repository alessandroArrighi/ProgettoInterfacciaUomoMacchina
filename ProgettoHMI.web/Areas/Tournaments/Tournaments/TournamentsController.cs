using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    [Area("Tournaments")]
    public partial class TournamentsController : Controller
    {
        public virtual IActionResult Index()
        {
            var model = new IndexViewModel("provaName", "Bronze");
            return View(model);
        }

        public virtual IActionResult Draw()
        {
            return View();
        }
    }
}
