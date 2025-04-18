using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.Services.Tournament
{
    public class TournamentsSelectQuery {
        public DateTime Date { get; set; }
    }
    public class TournamentsDTO
    {
        IEnumerable<Tournament> Tournaments { get; set; }

        public class Tournament {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Field { get; set; }
            public DateTime Date { get; set; }
            public string Img { get; set; }
        }
    }
}
