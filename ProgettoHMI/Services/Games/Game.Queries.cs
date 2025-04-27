using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Games
{
    public class GameSelectQuery {
        public Guid TournamentId { get; set; }
    }

    public class GameSelectDTO {
        public IEnumerable<Game> Games { get; set; }

        public class UserSelectDTO {
            public Guid Id;
            public string Name;
            public string Rank;
        }

        public class Game {
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

    public partial class GameService {
        public async Task<GameSelectDTO> Query(GameSelectQuery qry) {
            var queryable = _dbContext.Games
                .Where(x => qry.TournamentId == x.TournamentId);

            var games = new GameSelectDTO {
                Games = await queryable
                    .Select(x => new GameSelectDTO.Game {
                        GameId = x.GameId,
                        DrawPosition = x.DrawPosition,
                        Status = x.Status,
                        Player1Id = x.Player1Id,
                        Player2Id = x.Player2Id,
                        Player1 = null,
                        Player2 = null
                    }).ToArrayAsync()
            };
            
            return new GameSelectDTO {
                Games = await _dbContext.Users
                    .Join(games.Games,
                          user => user.Id,
                          game => game.Player1Id,
                          (user, game) => 
                          new GameSelectDTO.Game {
                            GameId = game.GameId,
                            DrawPosition = game.DrawPosition,
                            Status = game.Status,
                            Player1Id = game.Player1Id,
                            Player2Id = game.Player2Id,
                            Player1 = new GameSelectDTO.UserSelectDTO {
                                Id = user.Id,
                                Name = user.Name,
                                Rank = user.Rank
                            },
                            Player2 = null,
                            Score = game.Score
                          })
                    .Join(_dbContext.Users,
                          game => game.Player2Id,
                          user => user.Id,
                          (game, user) => 
                          new GameSelectDTO.Game {
                            GameId = game.GameId,
                            DrawPosition = game.DrawPosition,
                            Status = game.Status,
                            Player1Id = game.Player1Id,
                            Player2Id = game.Player2Id,
                            Player1 = game.Player1,
                            Player2 = new GameSelectDTO.UserSelectDTO {
                                Id = user.Id,
                                Name = user.Name,
                                Rank = user.Rank
                            },
                            Score = game.Score
                          }).ToArrayAsync()
            };
        }
    }
}
