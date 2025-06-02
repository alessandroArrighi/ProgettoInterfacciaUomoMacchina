using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.Services.Games
{
    public class GameDTO<T>
    {
        public Guid GameId { get; set; }
        public Guid TournamentId { get; set; }
        public int DrawPosition { get; set; }
        public Status Status { get; set; }
        public T Player1 { get; set; }
        public T Player2 { get; set; }
        public Score Score { get; set; }
    }

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

    public class GameStatusQuery
    {
        public Guid TournamentId { get; set; }
        public Status Status { get; set; }
    }

    public class GameStatusDTO
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
            public User Player1 { get; set; }
            public User Player2 { get; set; }
            public Score Score { get; set; }
        }
    }

    public class GameActivePostionQuery
    {
        public Guid TournamentId { get; set; }
    }

    public partial class GameService
    {
        public async Task<GameDTO<UserDTO>[]> PlayersJoin(IQueryable<Game> queryable)
        {
            var games = await queryable
                .Join(
                    _dbContext.Users,
                    game => game.Player1Id,
                    user => user.Id,
                    (game, user) => new GameDTO<UserDTO>
                    {
                        GameId = game.GameId,
                        TournamentId = game.TournamentId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = new Score(game.Player1Score, game.Player2Score),
                        Player1 = new UserDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Email = user.Email,
                            Password = user.Password,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = user.Rank,
                                Points = user.Points
                            },
                            PhoneNumber = user.PhoneNumber,
                            TaxID = user.TaxID,
                            Address = user.Address,
                            ImgProfile = user.ImgProfile,
                            Nationality = user.Nationality
                        },
                        Player2 = new UserDTO
                        {
                            Id = game.Player2Id
                        }
                    }
                )
                .Join(
                    _dbContext.Ranks,
                    game => game.Player1.Rank.Id,
                    rank => rank.Id,
                    (game, rank) => new GameDTO<UserDTO>
                    {
                        GameId = game.GameId,
                        TournamentId = game.TournamentId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = new UserDTO
                        {
                            Id = game.Player1.Id,
                            Name = game.Player1.Name,
                            Surname = game.Player1.Surname,
                            Email = game.Player1.Email,
                            Password = game.Player1.Password,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = rank.Id,
                                Name = rank.Name,
                                ImgRank = rank.ImgRank,
                                Points = game.Player1.Rank.Points
                            },
                            PhoneNumber = game.Player1.PhoneNumber,
                            TaxID = game.Player1.TaxID,
                            Address = game.Player1.Address,
                            ImgProfile = game.Player1.ImgProfile,
                            Nationality = game.Player1.Nationality
                        },
                        Player2 = game.Player2
                    }
                )
                .Join(
                    _dbContext.Users,
                    game => game.Player2.Id,
                    user => user.Id,
                    (game, user) => new GameDTO<UserDTO>
                    {
                        GameId = game.GameId,
                        TournamentId = game.TournamentId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = game.Player1,
                        Player2 = new UserDTO
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Email = user.Email,
                            Password = user.Password,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = user.Rank,
                                Points = user.Points
                            },
                            PhoneNumber = user.PhoneNumber,
                            TaxID = user.TaxID,
                            Address = user.Address,
                            ImgProfile = user.ImgProfile,
                            Nationality = user.Nationality
                        }
                    }
                )
                .Join(
                    _dbContext.Ranks,
                    game => game.Player2.Rank.Id,
                    rank => rank.Id,
                    (game, rank) => new GameDTO<UserDTO>
                    {
                        GameId = game.GameId,
                        TournamentId = game.TournamentId,
                        DrawPosition = game.DrawPosition,
                        Status = game.Status,
                        Score = game.Score,
                        Player1 = game.Player1,
                        Player2 = new UserDTO
                        {
                            Id = game.Player2.Id,
                            Name = game.Player2.Name,
                            Surname = game.Player2.Surname,
                            Email = game.Player2.Email,
                            Password = game.Player2.Password,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = rank.Id,
                                Name = rank.Name,
                                ImgRank = rank.ImgRank,
                                Points = game.Player1.Rank.Points
                            },
                            PhoneNumber = game.Player2.PhoneNumber,
                            TaxID = game.Player2.TaxID,
                            Address = game.Player2.Address,
                            ImgProfile = game.Player2.ImgProfile,
                            Nationality = game.Player2.Nationality
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
                Games = games.Select(x => new GameSelectDTO.Game
                {
                    GameId = x.GameId,
                    DrawPosition = x.DrawPosition,
                    Status = x.Status,
                    Player1 = new GameSelectDTO.User
                    {
                        Id = x.Player1.Id,
                        Name = x.Player1.Name,
                        Rank = x.Player1.Rank
                    },
                    Player2 = new GameSelectDTO.User
                    {
                        Id = x.Player2.Id,
                        Name = x.Player2.Name,
                        Rank = x.Player2.Rank
                    }
                })
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
                Games = games.Select(x => new GameSelectDTO.Game
                {
                    GameId = x.GameId,
                    DrawPosition = x.DrawPosition,
                    Status = x.Status,
                    Player1 = new GameSelectDTO.User
                    {
                        Id = x.Player1.Id,
                        Name = x.Player1.Name,
                        Rank = x.Player1.Rank
                    },
                    Player2 = new GameSelectDTO.User
                    {
                        Id = x.Player2.Id,
                        Name = x.Player2.Name,
                        Rank = x.Player2.Rank
                    },
                    Score = x.Score
                })
            };
        }

        public async Task<GameStatusDTO> Query(GameStatusQuery qry)
        {
            var queryable = _dbContext.Games
                .Where(x => (qry.TournamentId == x.TournamentId) &&
                            (qry.Status == x.Status));

            var res = await PlayersJoin(queryable);

            return new GameStatusDTO
            {
                Games = res.Select(x => new GameStatusDTO.Game
                {
                    GameId = x.GameId,
                    Player1 = new GameStatusDTO.User
                    {
                        Id = x.Player1.Id,
                        Name = x.Player1.Name,
                        Rank = x.Player1.Rank
                    },
                    Player2 = new GameStatusDTO.User
                    {
                        Id = x.Player2.Id,
                        Name = x.Player2.Name,
                        Rank = x.Player2.Rank
                    },
                    Score = x.Score
                })
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
