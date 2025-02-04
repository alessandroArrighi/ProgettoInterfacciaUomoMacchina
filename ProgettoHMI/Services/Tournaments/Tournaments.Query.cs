using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoHMI.Services.Tournaments
{
    public class TournamentDTO
    {
        public string TournamentName { get; set; }
        public string FieldName { get; set; }
        public string Date { get; set; }
        public string Img { get; set; }
    }

    public class TournamentService
    {
        public static TournamentDTO[] Query()
        {
            var tournaments = new List<TournamentDTO>();
            tournaments.Add(new TournamentDTO { TournamentName = "Torneo1", FieldName = "Campo1", Date = "01/01/2022", Img = "torneo1.jpg" });
            tournaments.Add(new TournamentDTO { TournamentName = "Torneo2", FieldName = "Campo2", Date = "02/01/2022", Img = "torneo2.jpg" });
            tournaments.Add(new TournamentDTO { TournamentName = "Torneo3", FieldName = "Campo3", Date = "03/01/2022", Img = "torneo3.jpg" });
            tournaments.Add(new TournamentDTO { TournamentName = "Torneo4", FieldName = "Campo4", Date = "04/01/2022", Img = "torneo4.jpg" });
            return tournaments.ToArray();
        }
    }
}
