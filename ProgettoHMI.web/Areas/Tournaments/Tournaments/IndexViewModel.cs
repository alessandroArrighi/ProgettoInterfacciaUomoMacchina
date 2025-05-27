using System;
using System.Collections.Generic;
using System.Linq;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    [TypeScriptModule("Tournaments.Tournaments.Server")]
    public class IndexViewModel
    {
        public IEnumerable<TournamentViewModel> Tournaments { get; set; }

        public IndexViewModel() { }

        public void SetTournaments(TournamentsFiltersDTO tournaments)
        {
            Tournaments = tournaments.Tournaments.Select(t => new TournamentViewModel
            {
                Id = t.Id,
                Name = t.Name,
                RankId = t.Rank.Id,
                ImgRank = t.Rank.ImgRank
            });
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }

    [TypeScriptModule("Tournaments.Tournaments.Server")]
    public class TournamentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RankId { get; set; }
        public string ImgRank { get; set; }
    }
}
