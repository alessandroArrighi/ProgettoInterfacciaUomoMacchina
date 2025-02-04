using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Features.Register
{
    public partial class RegisterController : Controller
    {
        [HttpGet]
        public virtual IActionResult Register()
        {
            return View();
        }
    }
}
