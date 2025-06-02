using System.Collections.Generic;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProgettoHMI.web.Areas.Tournaments.Abstracts;

namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    public class DrawViewModel : BaseGameViewModel
    {
        public IEnumerable<GameSelectDTO.Game> Games { get; set; }
        public int SelectBtn { get; set; }
        public string TournamentId { get; set; }


        [TypeScriptModule("Tournaments.Draw.Server")]
        public class GameViewModel : BaseGameViewModelTs<ScoreSetViewModel>
        {
            public int DrawPosition { get; set; }
            public Status Status { get; set; }
        }

        [TypeScriptModule("Tournaments.Draw.Server")]
        public class UserViewModel : UserViewModelTs { }

        [TypeScriptModule("Tournaments.Draw.Server")]
        public class RankViewModel : RankViewModelTs { }

        [TypeScriptModule("Tournaments.Draw.Server")]
        public class ScoreViewModel : ScoreViewModelTs<ScoreSetViewModel> { }

        [TypeScriptModule("Tournaments.Draw.Server")]
        public class ScoreSetViewModel : ScoreSetViewModelTs { }
    }
}
