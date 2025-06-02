using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoHMI.Services.Tournament;

namespace ProgettoHMI.web.Areas.Tournaments.Abstracts
{
    public interface BaseTournamentViewModel
    {
        public IEnumerable<BaseTournamentViewModelTs> Tournaments { get; set; }
        public string UrlFilters { get; set; }

        public void SetTournaments(TournamentsFiltersDTO tournaments);

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }
    }

    public abstract class BaseTournamentViewModelTs
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RankId { get; set; }
        public string ImgRank { get; set; }
    }

    public class BaseTournamentsFiltersQueryViewModelTs
    {
        public List<string> City { get; set; } = [];
        public List<int> Rank { get; set; } = [];
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}