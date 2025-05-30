using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Games;
using ProgettoHMI.web.Infrastructure;

namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    [Area("Tournaments")]
    [Alerts]
    public partial class DrawController : Controller
    {
        public readonly GameService _gameService;
        private readonly Guid _tournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"); // Example tournament ID

        public DrawController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async virtual Task<ActionResult> Draw()
        {
            var model = new DrawViewModel();

            var qry = new GameActivePostionQuery
            {
                TournamentId = _tournamentId
            };

            model.selectBtn = await _gameService.Query(qry);

            var qry1 = new GamesPositionQeury
            {
                TournamentId = _tournamentId,
                DrawPosition = model.selectBtn
            };

            model.SetUrls(Url);

            model.Games = await _gameService.Query(qry1);

            return View(model);
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetSingleDrawPosition(int position)
        {
            Console.WriteLine($"GetSingleDrawPosition called with position: {position}");
            var qry = new GamesPositionQeury
            {
                TournamentId = _tournamentId,
                DrawPosition = position
            };

            var result = await _gameService.Query(qry);

            var json = Infrastructure.JsonSerializer.ToJsonCamelCase(result);
            Console.WriteLine(json);
            return Content(json, "application/json");
        }
    }
}
