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

        public void setTournaments(TournamentsDTO tournaments)
        {
            Tournaments = tournaments.Tournaments.Select(x => new TournamentViewModel(x)).ToArray();
        }
    }
    public class PlayerViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Rank { get; set; }
        public string Points { get; set; }
        public string Img { get; set; }

        public PlayerViewModel() { }

        public PlayerViewModel(UserHomeDTO.User user)
        {
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.Rank = user.Rank.Name;
            this.Points = user.Rank.Points.ToString();
            this.Img = user.ImgProfile;
        }
    }

    public class TournamentViewModel
    {
        public string Name { get; set; }
        public string Club { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Img { get; set; }

        public TournamentViewModel(TournamentsDTO.Tournament dto)
        {
            this.Name = dto.Name;
            this.Club = dto.Club;
            this.StartDate = dto.StartDate.ToString("dd/MM/yyyy");
            this.EndDate = dto.EndDate.ToString("dd/MM/yyyy");
            this.Img = dto.Img;
        }
    }
}
