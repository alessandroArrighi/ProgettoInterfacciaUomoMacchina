using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Home
{
    public class IndexViewModel
    {
        public TournamentViewModel Tournament { get; set; }
        public SubUserViewModel[] Users { get; set; }
        public bool IsLogged { get; set; }
        public string UserId { get; set; }
        public string RegisterUrl { get; set; }

        public IndexViewModel(TournamentsIdDTO tournament, UsersSubDTO users, bool isLogged, string userId)
        {
            Tournament = new TournamentViewModel
            {
                Id = tournament.Id,
                Name = tournament.Name,
                RankId = tournament.Rank.Id,
                RankName = tournament.Rank.Name,
                ImgRank = tournament.Rank.ImgRank,
                Club = tournament.Club,
                StartDate = tournament.StartDate,
                EndDate = tournament.EndDate,
                Image = tournament.Image,
                City = tournament.City,
                Status = tournament.Status
            };

            Users = users.Users.Select(x => new SubUserViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Rank = new RankViewModel
                {
                    Id = x.Rank.Id,
                    Name = x.Rank.Name,
                    ImgRank = x.Rank.ImgRank,
                    Points = x.Rank.Points
                },
                ImgProfile = x.ImgProfile
            }).ToArray();

            IsLogged = isLogged;
            UserId = userId;
        }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void setRegisterUrl(IUrlHelper url, IActionResult action)
        {
            this.RegisterUrl = url.Action(action);
        }
    }

    [TypeScriptModule("Tournaments.Home.Server")]
    public class TournamentViewModel : BaseTournamentViewModelTs
    {
        public string Club { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public Status Status { get; set; }
        public string RankName { get; set; }
    }

    [TypeScriptModule("Tournaments.Home.Server")]
    public class RankViewModel : RankViewModelTs
    {
        public int Points { get; set; }
    }

    [TypeScriptModule("Tournaments.Home.Server")]
    public class SubUserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public RankViewModel Rank { get; set; }
        public string ImgProfile { get; set; }
    }
}