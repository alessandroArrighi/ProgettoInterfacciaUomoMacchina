using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Subscriptions
{
    public class SubscriptionUserQuery
    {
        public Guid IDUser { get; set; }
    }

    public class SubscriptionUserDTO
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public class Subscription
        {
            public Guid IDTournament { get; set; }
            public int PointsGained { get; set; }
        }
    }

    public class SubscriptionTournamentQuery
    {
        public Guid IDTournament { get; set; }
    }

    public class SubscriptionTournamentDTO
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public class Subscription
        {
            public Guid IDUser { get; set; }
            public int PointsGained { get; set; }
        }
    }

    public partial class SubscriptionService
    {
        public async Task<SubscriptionUserDTO> Query(SubscriptionUserQuery qry)
        {
            var subscriptions = await _dbContext.Subscriptions
                .Where(x => x.IDUser == qry.IDUser)
                .Select(x => new SubscriptionUserDTO.Subscription
                {
                    IDTournament = x.IDTournament,
                    PointsGained = x.PointsGained
                })
                .ToListAsync();

            return new SubscriptionUserDTO
            {
                Subscriptions = subscriptions
            };
        }

        public async Task<SubscriptionTournamentDTO> Query(SubscriptionTournamentQuery qry)
        {
            var subscriptions = await _dbContext.Subscriptions
                .Where(x => x.IDTournament == qry.IDTournament)
                .Select(x => new SubscriptionTournamentDTO.Subscription
                {
                    IDUser = x.IDUser,
                    PointsGained = x.PointsGained
                })
                .ToListAsync();

            return new SubscriptionTournamentDTO
            {
                Subscriptions = subscriptions
            };
        }
    
}

