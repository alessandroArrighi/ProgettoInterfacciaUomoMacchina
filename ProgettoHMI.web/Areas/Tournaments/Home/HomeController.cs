using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Tournament;

namespace ProgettoHMI.web.Areas.Tournaments.Home
{
    [Area("Tournaments")]
    public partial class HomeController : Controller
    {
        TournamentService _tournamentService { get; set; }

        public HomeController(TournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }
    }
}