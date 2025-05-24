using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Subscriptions
{
    public class AddOrUpdateSubscriptionCommand
    {
        public Guid IDUser { get; set; }
        public Guid IDTournament { get; set; }
        public int PointsGained { get; set; }
    }
    
    public partial class SubscriptionService
    {
        public async Task<Guid> Handle(AddOrUpdateSubscriptionCommand cmd)
        {
            var subscription = await _dbContext.Subscriptions
                .Where(x => x.IDUser == cmd.IDUser && x.IDTournament == cmd.IDTournament)
                .FirstOrDefaultAsync();

            if (subscription == null)
            {
                subscription = new Subscription
                {
                    IDUser = cmd.IDUser,
                    IDTournament = cmd.IDTournament,
                    PointsGained = cmd.PointsGained
                };
                _dbContext.Subscriptions.Add(subscription);
            }
            else
            {
                subscription.PointsGained = cmd.PointsGained;
            }

            await _dbContext.SaveChangesAsync();

            return subscription.IDUser;
        }

    }
}
