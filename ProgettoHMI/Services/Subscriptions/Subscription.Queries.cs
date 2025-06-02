using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.Services.Subscriptions
{
    public class SubscriptionUserQuery
    {
        public Guid IDUser { get; set; }
    }

    public class SubscriptionUserDTO
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public class Subscription
        {
            public Guid IDTournament { get; set; }
            public int PointsGained { get; set; }
            public int Point {  get; set; }
        }
    }

    public class SubscriptionTournamentQuery
    {
        public Guid IDTournament { get; set; }
    }

    public class SubscriptionTournamentDTO
    {
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public class Subscription
        {
            public Guid IDUser { get; set; }
            public int PointsGained { get; set; }
        }
    }

    public class UsersSubQuery
    {
        public Guid TournamentId;
    }

    public class UsersSubDTO
    {
        public IEnumerable<User> Users { get; set; }

        public class User
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public UsersRankDTO.UserRank Rank { get; set; }
            public string ImgProfile { get; set; }
        }
    }

    public partial class SubscriptionService
    {
        public async Task<SubscriptionUserDTO> Query(SubscriptionUserQuery qry)
        {
            var subscriptions = await _dbContext.Subscriptions
                .Where(subs => subs.IDUser == qry.IDUser)
                .Select(subs => new SubscriptionUserDTO.Subscription
                {
                    IDTournament = subs.IDTournament,
                    PointsGained = subs.PointsGained
                })
                .ToListAsync();

            var actualPoints = await _dbContext.Users
                .Where(user => user.Id == qry.IDUser)
                .Select(user => user.Points)
                .FirstOrDefaultAsync();

            int currentPoints = actualPoints;
            foreach (var sub in subscriptions) // Prendo i vari punteggi nel tempo
            {
                sub.Point = currentPoints;
                currentPoints -= sub.PointsGained;
            }

            return new SubscriptionUserDTO
            {
                Subscriptions = subscriptions
            };
        }

        public async Task<SubscriptionTournamentDTO> Query(SubscriptionTournamentQuery qry)
        {
            var subscriptions = await _dbContext.Subscriptions
                .Where(x => x.IDTournament == qry.IDTournament)
                .Select(x => new SubscriptionTournamentDTO.Subscription
                {
                    IDUser = x.IDUser,
                    PointsGained = x.PointsGained
                })
                .ToListAsync();

            return new SubscriptionTournamentDTO
            {
                Subscriptions = subscriptions
            };
        }

        public async Task<UsersSubDTO> Query(UsersSubQuery qry)
        {
            var queryable = _dbContext.Subscriptions
                .Where(x => x.IDTournament == qry.TournamentId);

            var users = await queryable.Join(
                        _dbContext.Users,
                        sub => sub.IDUser,
                        user => user.Id,
                        (sub, user) => new UsersSubDTO.User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = 1,
                                Points = user.Points
                            },
                            ImgProfile = user.ImgProfile
                        }
                    )
                    .Join(
                        _dbContext.Ranks,
                        user => user.Rank.Id,
                        rank => rank.Id,
                        (user, rank) => new UsersSubDTO.User
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Rank = new UsersRankDTO.UserRank
                            {
                                Id = rank.Id,
                                Name = rank.Name,
                                ImgRank = rank.ImgRank,
                                Points = user.Rank.Points
                            }
                        }
                    )
                    .ToArrayAsync();

            var res = new UsersSubDTO
            {
                Users = users
            };

            return res;
        }
    }
}

