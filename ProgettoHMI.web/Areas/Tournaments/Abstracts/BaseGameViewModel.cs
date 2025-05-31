using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoHMI.Services.Games;

namespace ProgettoHMI.web.Areas.Tournaments.Abstracts
{
    public abstract class BaseGameViewModel
    {
        public string UrlRaw { get; set; }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetUrls(IUrlHelper url, IActionResult action)
        {
            this.UrlRaw = url.Action(action);
        }
    }

    public abstract class BaseGameViewModelTs
    {
        public Guid GameId { get; set; }
        public UserViewModelTs Player1 { get; set; }
        public UserViewModelTs Player2 { get; set; }
        public Score Score { get; set; }
    }

    public abstract class UserViewModelTs
    {
        public Guid Id;
        public string Name;
        public RankViewModelTs Rank;
    }

    public abstract class RankViewModelTs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgRank { get; set; }
    }

    public abstract class ScoreViewModelTs
    {
        public List<ScoreSetViewModelTs> Set { get; set; }
    }

    public abstract class ScoreSetViewModelTs
    {
        public int Score1;
        public int Score2;

        public ScoreSetViewModelTs(int S1, int S2)
        {
            Score1 = S1;
            Score2 = S2;
        }
    }
}
