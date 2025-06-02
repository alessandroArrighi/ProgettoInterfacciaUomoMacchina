using System;
using System.Collections;
using System.Linq;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.Services.Users;
//using ProgettoHMI.Services.Players;
//using ProgettoHMI.Services.Tournaments;

namespace ProgettoHMI.web.Features.Home
{
    public class HomeViewModel
    {
        public PlayerViewModel[] Players { get; set; }
        public TournamentViewModel[] Tournaments { get; set; }
        public HomeViewModel() { 
            Players = Array.Empty<PlayerViewModel>();
            Tournaments = Array.Empty<TournamentViewModel>();
        }

        public void setPlayers(UserHomeDTO players)
        {
            Players = players.Users.Select(x => new PlayerViewModel(x)).ToArray();
        }

        public void setTournaments(TournamentsSelectDTO tournaments)
        {
            Tournaments = tournaments.Tournaments.Select(x => new TournamentViewModel(x)).ToArray();
        }
    }
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImgRank { get; set; }
        public string Points { get; set; }
        public string PlayerImg { get; set; }

        public PlayerViewModel() { }

        public PlayerViewModel(UserHomeDTO.User user)
        {
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.ImgRank = user.Rank.ImgRank;
            this.Points = user.Rank.Points.ToString();
            this.PlayerImg = user.ImgProfile;
        }
    }

    public class TournamentViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Img { get; set; }

        public TournamentViewModel(TournamentsSelectDTO.Tournament dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Club = dto.Club;
            this.StartDate = dto.StartDate.ToString("dd/MM/yyyy");
            this.EndDate = dto.EndDate.ToString("dd/MM/yyyy");
            this.Img = dto.Img;
        }
    }
}
