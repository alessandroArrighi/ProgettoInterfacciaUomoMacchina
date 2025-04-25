using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Shared.Subscriptions
{
    public class Subscription
    {
        public Guid IDUser { get; set; }
        public string IDTournament { get; set; }
        public int PointsGained { get; set; } = 0;
    }
}
