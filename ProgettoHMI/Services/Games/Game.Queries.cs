using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.Services.Games
{
    public class GameSelectQuery
    {
        public Guid TournamentId { get; set; }
    }

    public class GameSelectDTO
    {
        public IEnumerable<Game> Games { get; set; }

        public class UserSelectDTO
        {
            public Guid Id;
            public string Name;
            public string Rank;
        }

        public class Game
        {
            public Guid GameId { get; set; }
            public int DrawPosition { get; set; }
            public string Status { get; set; }
            public Guid Player1Id { get; set; }
            public Guid Player2Id { get; set; }
            public UserSelectDTO Player1 { get; set; }
            public UserSelectDTO Player2 { get; set; }
            public Score Score { get; set; }
        }
    }

    public class GamesPositionQeury
    {
        public int DrawPosition { get; set; }
    }

    public partial class GameService
    {
        public async Task<GameSelectDTO.Game[]> PlayersJoin(IQueryable<Game> queryable)
        {
            var games = await queryable
                .Join(
                    _dbContext.Users,
                    game => game.Player1Id,
                    user => user.Id,
                    (game, user) => new GameSelectDTO.Game
                    {
                        GameId = game.GameId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player2Id = game.Player2Id,
                        Player1 = new GameSelectDTO.UserSelectDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Rank = user.Rank
                        }
                    }
                )
                .Join(
                    _dbContext.Users,
                    game => game.Player2Id,
                    user => user.Id,
                    (game, user) => new GameSelectDTO.Game
                    {
                        GameId = game.GameId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = game.Player1,
                        Player2 = new GameSelectDTO.UserSelectDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Rank = user.Rank
                        }
                    }
                )
                .ToArrayAsync();

            return games;
        }

        public async Task<GameSelectDTO> Query(GameSelectQuery qry)
        {
            var queryable = _dbContext.Games
                .Where(x => qry.TournamentId == x.TournamentId);

            var games = await PlayersJoin(queryable);

            return new GameSelectDTO
            {
                Games = games
            };
        }

        public async Task<GameSelectDTO> Query(GamesPositionQeury qry)
        {
            var queryable = _dbContext.Games
                .Where(x => qry.DrawPosition == x.DrawPosition);

            var games = await PlayersJoin(queryable);

            return new GameSelectDTO
            {
                Games = games
            };
        }
    }
}
