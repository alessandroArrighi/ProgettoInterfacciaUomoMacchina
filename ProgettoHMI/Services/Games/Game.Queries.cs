using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.Services.Games
{
    public class GameSelectQuery
    {
        public Guid TournamentId { get; set; }
    }

    public class GameSelectDTO
    {
        public IEnumerable<Game> Games { get; set; }

        public class User
        {
            public Guid Id;
            public string Name;
            public UsersRankDTO.UserRank Rank;
        }

        public class Game
        {
            public Guid GameId { get; set; }
            public int DrawPosition { get; set; }
            public Status Status { get; set; }
            public Guid Player1Id { get; set; }
            public Guid Player2Id { get; set; }
            public User Player1 { get; set; }
            public User Player2 { get; set; }
            public Score Score { get; set; }
        }
    }

    public class GamesPositionQeury
    {
        public Guid TournamentId { get; set; }
        public int DrawPosition { get; set; }
    }

    public class GameActivePostionQuery
    {
        public Guid TournamentId { get; set; }
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
                        Score = new Score(game.Player1Score, game.Player2Score),
                        Player1 = new GameSelectDTO.User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = user.Rank,
                                Points = user.Points
                            }
                        },
                        Player2 = new GameSelectDTO.User
                        {
                            Id = game.Player2Id
                        }
                    }
                )
                .Join(
                    _dbContext.Ranks,
                    game => game.Player1.Rank.Id,
                    rank => rank.Id,
                    (game, rank) => new GameSelectDTO.Game
                    {
                        GameId = game.GameId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = new GameSelectDTO.User
                        {
                            Id = game.Player1.Id,
                            Name = game.Player1.Name,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = rank.Id,
                                Name = rank.Name,
                                ImgRank = rank.ImgRank,
                                Points = game.Player1.Rank.Points
                            }
                        },
                        Player2 = game.Player2
                    }
                )
                .Join(
                    _dbContext.Users,
                    game => game.Player2.Id,
                    user => user.Id,
                    (game, user) => new GameSelectDTO.Game
                    {
                        GameId = game.GameId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = game.Player1,
                        Player2 = new GameSelectDTO.User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = user.Rank,
                                Points = user.Points
                            }
                        }
                    }
                )
                .Join(
                    _dbContext.Ranks,
                    game => game.Player2.Rank.Id,
                    rank => rank.Id,
                    (game, rank) => new GameSelectDTO.Game
                    {
                        GameId = game.GameId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = game.Player1,
                        Player2 = new GameSelectDTO.User
                        {
                            Id = game.Player2.Id,
                            Name = game.Player2.Name,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = rank.Id,
                                Name = rank.Name,
                                ImgRank = rank.ImgRank,
                                Points = game.Player1.Rank.Points
                            }
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
                .Where(x => qry.TournamentId == x.TournamentId
                            && qry.DrawPosition == x.DrawPosition);

            var games = await PlayersJoin(queryable);

            return new GameSelectDTO
            {
                Games = games
            };
        }

        public async Task<int> Query(GameActivePostionQuery qry)
        {
            var firstNotEnded = await _dbContext.Games
                .Where(g => g.TournamentId == qry.TournamentId && g.Status != Status.End)
                .OrderByDescending(g => g.DrawPosition)
                .Select(g => g.DrawPosition)
                .FirstOrDefaultAsync();

            // Se tutte le partite sono End, restituisci 1
            return firstNotEnded == 0 ? 1 : firstNotEnded;
        }

    }
}
