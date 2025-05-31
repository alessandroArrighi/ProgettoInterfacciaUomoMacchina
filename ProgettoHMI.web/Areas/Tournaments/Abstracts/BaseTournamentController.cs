using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProgettoHMI.web.Areas.Tournaments.Abstracts
{
    public interface BaseTournamentController<T>
    {
        public Task<IActionResult> Index();

        public Task<IActionResult> TournamentsFilters([FromBody] T query);
    }
}
