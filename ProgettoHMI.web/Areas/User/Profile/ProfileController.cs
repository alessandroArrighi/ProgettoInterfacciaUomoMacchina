using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.User.Profile
{
    [Area("User")]
    public partial class ProfileController: Controller
    {

        public virtual ActionResult Profile()
        {
            
            return View();
        }

    }
}
