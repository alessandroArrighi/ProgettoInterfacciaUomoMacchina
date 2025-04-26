using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Statistics
{
    public partial class StatisticsService
    {
        TemplateDbContext _dbContext;
        public StatisticsService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
