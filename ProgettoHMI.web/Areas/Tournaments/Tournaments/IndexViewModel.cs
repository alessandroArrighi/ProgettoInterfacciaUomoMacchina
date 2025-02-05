using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    [TypeScriptModule("Tournaments.Tournaments.Server")]
    public class IndexViewModel
    {
        public IEnumerable<TournamentListViewModel> Tournaments { get; set; }

        public IndexViewModel(string name, string rank)
        {
            this.Tournaments = new List<TournamentListViewModel>
            {
                new TournamentListViewModel
                {
                    Name = name,
                    Rank = rank
                },
                new TournamentListViewModel
                {
                    Name = "provaName2",
                    Rank = "Gold"
                },
                new TournamentListViewModel
                {
                    Name = "provaName3",
                    Rank = "Silver"
                },
                new TournamentListViewModel
                {
                    Name = "provaName4",
                    Rank = "Bronze"
                },
                new TournamentListViewModel
                {
                    Name = "provaName5",
                    Rank = "Gold"
                },
                new TournamentListViewModel
                {
                    Name = "provaName6",
                    Rank = "Diamond"
                }
            };
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }

    [TypeScriptModule("Tournaments.Tournaments.Server")]
    public class TournamentListViewModel
    {
        public string Name { get; set; }
        public string Rank { get; set; }
    }
}
