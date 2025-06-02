using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Users;
using ProgettoHMI.Services.Ranks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;

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

        public RegisterController(UsersService usersService, RanksService ranksService, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _usersService = usersService;
            _ranksService = ranksService;
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

            var model = new RegisterViewModel
            {
                Ranks = _ranksService.Query(new RanksInfoQuery()).GetAwaiter().GetResult()
            };

            return View(model);
        }

        [HttpPost]
        public async virtual Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
                        ImgProfile = model.ImgProfile,
                        Rank = model.RankId,
                    });
                    
                    return await AutoLogin(model);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(string.Empty, e.Message);
                    Alerts.AddError(this, e.Message);
                    // togliere tutti gli errori input
                }
            }
            Alerts.AddError(this, "Si è verificato un errore durante la registrazione. Inserisci i dati correttamente!");
            return RedirectToAction(MVC.Register.Register());
        }

        private async Task<IActionResult> AutoLogin(RegisterViewModel model)
        {
            var utente = await _usersService.Query(new CheckLoginCredentialsQuery
            {
                Email = model.Email,
                Password = model.Password
            });

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, utente.Id.ToString()),
                new Claim(ClaimTypes.Email, utente.Email)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMonths(3),
                IsPersistent = false,
            });
            Alerts.AddSuccess(this, "Complimenti, ti sei registrato correttamente!");

            return RedirectToAction(MVC.Home.Index());
        }

    }
}
