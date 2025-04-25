using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Shared;
using ProgettoHMI.Services;

namespace ProgettoHMI.Services.Games
{
    public class GameSelectQuery {
        public Guid TournamentId { get; set; }
    }

    public class GameSelectDTO {
        public IEnumerable<Game> Games { get; set; }

        public class Game {
            public Guid GameId { get; set; }
            public int DrawPosition { get; set; }
            public string Status { get; set; }
            public User Player1 { get; set; }
            public User Player2 { get; set; }
            public Score Score { get; set; }

        }
    }

    public partial class GameService {

        public async Task<GameSelectDTO> Query(GameSelectQuery qry) {
            var queryable = _dbContext.Games
                .Where(x => qry.TournamentId == x.TournamentId);
            
            return new GameSelectDTO {
                Games = await queryable
                .Select(x => new GameSelectDTO.Game {
                    GameId = x.GameId,
                    DrawPosition = x.DrawPosition,
                    Status = x.Status,
                    Player1 = x.Player1,
                    Player2 = x.Player2,
                    Score = x.Score
                }).ToArrayAsync()
            };
        }
    }
}
