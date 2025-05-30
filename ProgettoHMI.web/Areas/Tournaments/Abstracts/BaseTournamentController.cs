using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.Tournaments.Abstracts
{
    public interface BaseTournamentController
    {
        public Task<IActionResult> Index();

        public Task<IActionResult> TournamentsFilters([FromBody] BaseTournamentsFiltersQueryViewModelTs query);
    }
}
