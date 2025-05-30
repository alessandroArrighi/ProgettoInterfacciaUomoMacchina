﻿using System;
using System.Collections.Generic;
using System.Linq;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Tournaments
{
    [TypeScriptModule("Tournaments.Tournaments.Server")]
    public class IndexViewModel : BaseTournamentViewModel
    {
        public IEnumerable<BaseTournamentViewModelTs> Tournaments { get; set; }

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
    public class TournamentViewModel : BaseTournamentViewModelTs {}


    [TypeScriptModule("Tournaments.Tournaments.Server")]
    public class TournamentsFiltersQueryViewModel : BaseTournamentsFiltersQueryViewModelTs{}
}
