using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Shared.Subscriptions
{
    public partial class SubscriptionsService
    {
        TemplateDbContext _dbContext;

        public SubscriptionsService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
