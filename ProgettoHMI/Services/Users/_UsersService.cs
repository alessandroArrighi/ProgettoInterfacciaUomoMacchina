using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Users
{
    public partial class UsersService
    {
        readonly TemplateDbContext _dbContext;

        public UsersService(TemplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
