using System;
using System.Collections;
using ProgettoHMI.Services.Players;
using ProgettoHMI.Services.Tournaments;

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

        public void setPlayers(PlayerDTO[] players)
        {
            this.Players = new PlayerViewModel[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                this.Players[i] = new PlayerViewModel(players[i]);
            }
        }

        public void setTournaments(TournamentDTO[] tournaments)
        {
            this.Tournaments = new TournamentViewModel[tournaments.Length];
            for (int i = 0; i < tournaments.Length; i++)
            {
                this.Tournaments[i] = new TournamentViewModel(tournaments[i]);
            }
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

        public PlayerViewModel(PlayerDTO dto)
        {
            this.Name = dto.Name;
            this.Surname = dto.Surname;
            this.Rank = dto.Rank;
            this.Points = dto.Points;
            this.Img = dto.Img;
        }
    }

    public class TournamentViewModel
    {
        public string TournamentName { get; set; }
        public string FieldName { get; set; }
        public string Date { get; set; }
        public string Img { get; set; }

        public TournamentViewModel(TournamentDTO dto) {
            this.TournamentName = dto.TournamentName;
            this.FieldName = dto.FieldName;
            this.Date = dto.Date;
            this.Img = dto.Img;
        }
    }
}
