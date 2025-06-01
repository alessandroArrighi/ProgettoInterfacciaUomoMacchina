using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Tournament;
using ProgettoHMI.Services.Ranks;

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
            public string Name { get; set; }
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

    public class TournamentsSubsQuery
    {
        public Guid IDUser { get; set; }
    }

    public class TournamentsSubsDTO
    {
        public IEnumerable<Tournament> Tournaments { get; set; }
        public class Tournament: TournamentDTO { }
    }

    public partial class SubscriptionService
    {
        public async Task<SubscriptionUserDTO> Query(SubscriptionUserQuery qry)
        {
            var subscriptions = await _dbContext.Subscriptions
                .Where(subs => subs.IDUser == qry.IDUser)
                .Join(
                    _dbContext.Tournaments,
                    subs => subs.IDTournament,
                    t => t.Id,
                    (subs, t) => new SubscriptionUserDTO.Subscription
                    {
                        IDTournament = subs.IDTournament,
                        PointsGained = subs.PointsGained,
                        Name = t.Name
                    }
                )
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

        public async Task<TournamentsSubsDTO> Query(TournamentsSubsQuery qry)
        {
            var tournaments = await _dbContext.Subscriptions
                .Where(x => x.IDUser == qry.IDUser)
                .Join(
                    _dbContext.Tournaments,
                    subs => subs.IDTournament,
                    t => t.Id,
                    (subs, t) => new { subs, t }
                )
                .Join(
                    _dbContext.Ranks,
                    temp => temp.t.Rank,
                    r => r.Id,
                    (temp, r) => new TournamentsSubsDTO.Tournament
                    {
                        Id = temp.t.Id,
                        Name = temp.t.Name,
                        Club = temp.t.Club,
                        StartDate = temp.t.StartDate,
                        EndDate = temp.t.EndDate,
                        Image = temp.t.Image,
                        City = temp.t.City,
                        Rank = new RankDTO
                        {
                            Id = r.Id,
                            Name = r.Name,
                            ImgRank = r.ImgRank
                        },
                        Status = temp.t.Status
                    }
                )
                .ToListAsync();
            return new TournamentsSubsDTO
            {
                Tournaments = tournaments
            };

        }
    }
}

