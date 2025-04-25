using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Shared.Ranks
{
    public class Rank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
        public string Description { get; set; }
    }
}
