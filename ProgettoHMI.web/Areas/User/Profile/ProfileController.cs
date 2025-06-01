using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Statistics;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.web.Areas.User.Profile
{
    [Area("User")]
    public partial class ProfileController: Controller
    {
        private readonly UsersService _usersService;
        private readonly SubscriptionService _subscriptionService;
        private readonly StatisticsService _statisticsService;

        public ProfileController(UsersService usersService, SubscriptionService subscriptionService, StatisticsService statisticsService)
        {
            _usersService = usersService;
            _subscriptionService = subscriptionService;
            _statisticsService = statisticsService;
        }

        public virtual async Task<ActionResult> Index()
        {
            var model = new ProfileViewModel();

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            var user = await _usersService.Query(new UserRankQuery
            {
                Id = Guid.Parse(userId)
            });

            if (user == null)
            {
                return NotFound();
            }
            ViewData["isLogin"] = true;

            model.SetUser(user);

            Console.WriteLine($"User found: {model.User.Name} {model.User.Surname} with points: {model.User.Rank.Points}");

            model.SetSubscription(await _subscriptionService.Query(new SubscriptionUserQuery
            {
                IDUser = Guid.Parse(userId)
            }));

            model.SetStats(await _statisticsService.Query(new StatsUserQuery
            {
                IDUser = Guid.Parse(userId)
            }));

            model.SetTournaments(await _subscriptionService.Query(new TournamentsSubsQuery
            {
                IDUser = Guid.Parse(userId)
            }));

            foreach (var t in model.Tournaments)
            {
                Console.WriteLine($"Tournament found: {t.Name}, Club: {t.Club}, Start: {t.StartDate:dd/MM/yyyy}, End: {t.EndDate:dd/MM/yyyy}, Rank: {t.Rank?.Name}");
            }


            return View(model);
        }

    }
}
