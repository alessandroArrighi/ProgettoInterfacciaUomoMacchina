using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Ranks
{
    public partial class RanksService
    {
        TemplateDbContext _dbContext;

        public RanksService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
