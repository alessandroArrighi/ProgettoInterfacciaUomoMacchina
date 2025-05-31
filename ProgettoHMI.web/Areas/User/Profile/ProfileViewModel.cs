using System.Collections.Generic;
using ProgettoHMI.Services.Statistics;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.web.Areas.User.Profile
{
    public class ProfileViewModel
    {
        public UsersRankDTO.User User { get; set; }
        public IEnumerable<SubscriptionUserDTO.Subscription> Subscription { get; set; }

        public StatsUserDTO.Statistic Stats { get; set; }


        public void SetUser(UserRankDTO user)
        {
            User = user.User;
        }

        public void SetSubscription(SubscriptionUserDTO subs)
        {
            Subscription = subs.Subscriptions;
        }

        public void SetStats(StatsUserDTO stats)
        {
            Stats = stats.Stats;
        }
    }
}
