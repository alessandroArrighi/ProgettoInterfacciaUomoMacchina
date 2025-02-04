using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Features.SignIn
{
    public partial class SignInController : Controller
    {
        public SignInController()
        {
        }

        [HttpGet]
        public virtual IActionResult SignIn()
        {
            return View();
        }
    }
}
