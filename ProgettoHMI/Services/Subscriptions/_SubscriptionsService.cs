using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Subscriptions
{
    public partial class SubscriptionService
    {
        TemplateDbContext _dbContext;

        public SubscriptionService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
