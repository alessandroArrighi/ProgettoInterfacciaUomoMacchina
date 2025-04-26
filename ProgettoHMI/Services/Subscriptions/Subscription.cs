using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Subscriptions
{
    public class Subscription
    {
        public Guid IDUser { get; set; }
        public string IDTournament { get; set; }
        public int PointsGained { get; set; } = 0;
    }
}
