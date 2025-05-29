using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    [Area("Tournaments")]
    [Alerts]
    public partial class DrawController : Controller
    {
        public virtual IActionResult Draw()
        {
            return View();
        }
    }
}
