using System;
using System.Collections.Generic;
using System.Linq;
using ProgettoHMI.Services.Subscriptions;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;

namespace ProgettoHMI.web.Areas.Tournaments.Home
{
    public class IndexViewModel
    {
        TournamentViewModel Tournament { get; set; }
        IEnumerable<SubUserViewModel> Users { get; set; }

        public IndexViewModel(TournamentsIdDTO tournament, UsersSubDTO users)
        {
            Tournament = new TournamentViewModel
            {
                Id = tournament.Id,
                Name = tournament.Name,
                RankId = tournament.Rank.Id,
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
        }
    }

    public class TournamentViewModel : BaseTournamentViewModelTs
    {
        public string Club { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public Status Status { get; set; }
    }

    public class RankViewModel : RankViewModelTs
    {
        public int Points { get; set; }
    }

    public class SubUserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public RankViewModel Rank { get; set; }
        public string ImgProfile { get; set; }
    }
}