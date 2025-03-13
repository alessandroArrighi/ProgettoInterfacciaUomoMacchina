using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.web.Features.Register
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Alerts]
    [ModelStateToTempData]
    public partial class RegisterController : Controller
    {
        private readonly SharedService _sharedService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public RegisterController(SharedService sharedService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _sharedService = sharedService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public virtual IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async virtual Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await _sharedService.Handle(new AddOrUpdateUserCommand
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Name = model.Name,
                        Surname = model.Surname,
                        PhoneNumber = model.PhoneNumber,
                        CodiceFiscale = model.TaxID,
                        Indirizzo = model.Indirizzo,
                        Nazionalita = model.Nazionalita,
                        ImgProfilo = model.ImgProfilo
                    });

                    // Redirect to login page after successful registration
                    return RedirectToAction("Login", "Login");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            return View(model);
        }
    }
}
