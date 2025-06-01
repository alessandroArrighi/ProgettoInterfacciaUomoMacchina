using System.Collections.Generic;
using ProgettoHMI.Services.Statistics;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Users;
using ProgettoHMI.Services.Subscriptions;

namespace ProgettoHMI.web.Areas.User.Profile
{
    public class ProfileViewModel
    {
        public UsersRankDTO.User User { get; set; }
        public IEnumerable<SubscriptionUserDTO.Subscription> Subscription { get; set; }

        public StatsUserDTO.Statistic Stats { get; set; }

        public IEnumerable<TournamentsSubsDTO.Tournament> Tournaments { get; set; }


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

        public void SetTournaments(TournamentsSubsDTO tournaments)
        {
            Tournaments = tournaments.Tournaments;

        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }
}
