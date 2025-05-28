using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    [Area("Tournaments")]
    public partial class DrawController : Controller
    {
        public virtual IActionResult Draw()
        {
            return View();
        }
    }
}
