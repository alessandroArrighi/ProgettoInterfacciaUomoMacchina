using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Users;
using ProgettoHMI.Services.Ranks;

namespace ProgettoHMI.web.Features.Register
{
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    [Alerts]
    [ModelStateToTempData]
    public partial class RegisterController : Controller
    {
        private readonly UsersService _usersService;
        private readonly RanksService _ranksService;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public RegisterController(UsersService usersService, RanksService ranksService ,IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _usersService = usersService;
            _ranksService = ranksService;
            _sharedLocalizer = sharedLocalizer;
        }

        [HttpGet]
        public virtual IActionResult Register(string returnUrl, RegisterViewModel model)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                if (string.IsNullOrWhiteSpace(returnUrl) == false)
                    return Redirect(returnUrl);

                return RedirectToAction(MVC.Home.Index());
            }

            model.Ranks = _ranksService.Query(new RanksInfoQuery { }).GetAwaiter().GetResult();

            return View(model);
        }

        [HttpPost]
        public async virtual Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("Registering user...");
                    Console.WriteLine("Email: " + model.Email);
                    Console.WriteLine("Password: " + model.Password);
                    Console.WriteLine("Name: " + model.Name);
                    Console.WriteLine("Surname: " + model.Surname);
                    Console.WriteLine("PhoneNumber: " + model.PhoneNumber);
                    Console.WriteLine("TaxID: " + model.TaxID);
                    Console.WriteLine("Address: " + model.Address);
                    Console.WriteLine("ImgProfile: " + model.ImgProfile);

                    var userId = await _usersService.Handle(new AddOrUpdateUserCommand
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

                    return RedirectToAction(MVC.Login.Login());
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    // metttere dei messaggi di errore
                    // togliere tutti gli errori input
                }
            }
            return RedirectToAction(MVC.Register.Register());
        }
    }
}
