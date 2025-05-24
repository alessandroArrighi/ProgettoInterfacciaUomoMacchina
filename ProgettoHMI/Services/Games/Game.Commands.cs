
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace ProgettoHMI.Services.Games
{
    public class AddOrUpdateGameCommand
    {
        public Guid? GameId { get; set; }
        public Guid? TournamentId { get; set; }
        public int? DrawPosition { get; set; }
        public Status? Status { get; set; }
        public Guid? Player1Id { get; set; }
        public Guid? Player2Id { get; set; }
        public Score? Score { get; set; }
    }

    public partial class GameService
    {
        public async Task<Guid?> Handle(AddOrUpdateGameCommand cmd)
        {
            var game = await _dbContext.Games
                .Where(x => x.GameId == cmd.GameId)
                .FirstOrDefaultAsync();

            if (game == null)
            {
                try
                {
                    game = new Game
                    {
                        GameId = Guid.NewGuid(),
                        TournamentId = cmd.TournamentId ?? throw new Exception(),
                        DrawPosition = cmd.DrawPosition ?? throw new Exception(),
                        Status = cmd.Status ?? throw new Exception(),
                        Player1Id = cmd.Player1Id ?? throw new Exception(),
                        Player2Id = cmd.Player2Id ?? throw new Exception(),
                        Player1Score = Score.ScoreToArray(cmd.Score, 0) ?? throw new Exception(),
                        Player2Score = Score.ScoreToArray(cmd.Score, 1) ?? throw new Exception()
                    };
                    _dbContext.Games.Add(game);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                game.TournamentId = cmd.TournamentId ?? game.TournamentId;
                game.DrawPosition = cmd.DrawPosition ?? game.DrawPosition;
                game.Status = cmd.Status ?? game.Status;
                game.Player1Id = cmd.Player1Id ?? game.Player1Id;
                game.Player2Id = cmd.Player2Id ?? game.Player2Id;
                game.Player1Score = Score.ScoreToArray(cmd.Score, 0) ?? game.Player1Score;
                game.Player2Score = Score.ScoreToArray(cmd.Score, 1) ?? game.Player2Score;
            }

            await _dbContext.SaveChangesAsync();

            return game.GameId;
        }
    }
}