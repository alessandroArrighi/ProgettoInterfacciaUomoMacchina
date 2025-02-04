using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Players
{
    public class PlayerDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Rank { get; set; }
        public string Points { get; set; }
        public string Img { get; set; }
    }

    public class PlayersService
    {

        public static PlayerDTO[] Query()
        {
            var players = new List<PlayerDTO>();
            players.Add(new PlayerDTO { Name = "Mario", Surname = "Rossi", Rank = "1", Points = "100", Img = "mario.jpg" });
            players.Add(new PlayerDTO { Name = "Luigi", Surname = "Verdi", Rank = "2", Points = "90", Img = "luigi.jpg" });
            players.Add(new PlayerDTO { Name = "Giovanni", Surname = "Bianchi", Rank = "3", Points = "80", Img = "giovanni.jpg" });
            players.Add(new PlayerDTO { Name = "Paolo", Surname = "Neri", Rank = "4", Points = "70", Img = "paolo.jpg" });

            return players.ToArray();
        }
    }
}