using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ProgettoHMI.Services.Games;
using ProgettoHMI.web.Infrastructure;
using System.Collections.Generic;

namespace ProgettoHMI.web.Areas.Tournaments.Draw
{
    [Area("Tournaments")]
    [Alerts]
    public partial class DrawController : Controller
    {
        public readonly GameService _gameService;

        public DrawController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async virtual Task<ActionResult> Draw(Guid TournamentId)
        {
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                ViewData["isLogin"] = true;
            }

            var model = new DrawViewModel();

            var qry = new GameActivePostionQuery
            {
                TournamentId = TournamentId
            };

            model.SelectBtn = await _gameService.Query(qry);

            var qry1 = new GamesPositionQeury
            {
                TournamentId = TournamentId,
                DrawPosition = model.SelectBtn
            };

            model.SetUrls(Url, MVC.Tournaments.Draw.GetSingleDrawPosition());
            var games = await _gameService.Query(qry1);
            model.Games = games.Games;
            model.TournamentId = TournamentId.ToString();
            return View(model);
        }

        [HttpGet]
        public async virtual Task<IActionResult> GetSingleDrawPosition(int position, Guid tournamentId)
        {
            Console.WriteLine($"GetSingleDrawPosition called with position: {position}");
            Console.WriteLine($"TournamentId: {tournamentId}");
            var qry = new GamesPositionQeury
            {
                TournamentId = tournamentId,
                DrawPosition = position
            };

            var result = await _gameService.Query(qry);;

            foreach ( var item in result.Games ) {
                Console.WriteLine($"GameId: {item.GameId}, DrawPosition: {item.DrawPosition}, Status: {item.Status}");
            }

            var res = Infrastructure.JsonSerializer.ToJsonCamelCase(result.Games.Select(static x => new DrawViewModel.GameViewModel
            {
                GameId = x.GameId,
                DrawPosition = x.DrawPosition,
                Status = x.Status,
                Player1 = new DrawViewModel.UserViewModel
                {
                    Id = x.Player1.Id,
                    Name = x.Player1.Name,
                    Rank = new DrawViewModel.RankViewModel
                    {
                        Id = x.Player1.Rank.Id,
                        Name = x.Player1.Rank.Name,
                        ImgRank = x.Player1.Rank.ImgRank
                    }
                },
                Player2 = new DrawViewModel.UserViewModel
                {
                    Id = x.Player2.Id,
                    Name = x.Player2.Name,
                    Rank = new DrawViewModel.RankViewModel
                    {
                        Id = x.Player2.Rank.Id,
                        Name = x.Player2.Rank.Name,
                        ImgRank = x.Player2.Rank.ImgRank
                    }
                },
                Score = new DrawViewModel.ScoreViewModel
                {
                    Set = x.Score.Set.Select(set => new DrawViewModel.ScoreSetViewModel
                    {
                        Score1 = set.Score1,
                        Score2 = set.Score2
                    }).ToList()
                }

            }));

            return Content(res, "application/json");
        }
    }
}
