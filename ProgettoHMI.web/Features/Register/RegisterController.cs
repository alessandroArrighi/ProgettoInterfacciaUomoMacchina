using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.web.Features.Register
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Alerts]
    [ModelStateToTempData]
    public partial class RegisterController : Controller
    {
        private readonly UsersService _sharedService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public RegisterController(UsersService sharedService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public virtual IActionResult Register(string returnUrl)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrWhiteSpace(returnUrl) == false)
                    return Redirect(returnUrl);

                return RedirectToAction(MVC.Home.Index());
            }

            return View();
        }

        [HttpPost]
        public async virtual Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await _sharedService.Handle(new AddOrUpdateUserCommand
                    {
                        Id = null,
                        Email = model.Email,
                        Password = model.Password,
                        Name = model.Name,
                        Surname = model.Surname,
                        PhoneNumber = model.PhoneNumber,
                        TaxID = model.TaxID,
                        Address = model.Address,
                        Nationality = model.Nationality,
                        ImgProfile = model.ImgProfile
                    });

                    // Redirect to login page after successful registration
                    Console.Write("Ciaoooo");
                    
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return RedirectToAction(MVC.Login.Login());
        }
    }
}
