using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoHMI.Services.Ranks;
using ProgettoHMI.Services.Shared;
using ProgettoHMI.Services.Users;

namespace ProgettoHMI.Services.Tournament
{
    public class TournamentDTO {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public RankDTO Rank { get; set; }
        public Status Status { get; set; }
    }

    public class TournamentsSelectQuery
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class TournamentsSelectDTO
    {
        public IEnumerable<Tournament> Tournaments { get; set; }

        public class Tournament {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Club { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Img { get; set; }
        }
    }

    public class TournamentsIdQuery {
        public Guid Id { get; set; }
    }

    public class TournamentsIdDTO : TournamentDTO { }

    public class TournamentsFiltersQuery
    {
        public List<string> City { get; set; } = [];
        public List<int> Rank { get; set; } = [];
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class TournamentsFiltersDTO
    {
        public IEnumerable<Tournament> Tournaments { get; set; }
        public class Tournament
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public RankDTO Rank { get; set; }
        }
    }

    public class TournamentFiltersStatusQuery
    {
        public List<string> City { get; set; } = [];
        public List<int> Rank { get; set; } = [];
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status Status;
    }

    public partial class TournamentService
    {
        public async Task<IEnumerable<TournamentDTO>> RanksJoin(IQueryable<Tournament> queryable)
        {
            var res = await queryable.Select(x => new TournamentDTO
            {
                Id = x.Id,
                Name = x.Name,
                Club = x.Club,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Image = x.Image,
                City = x.City,
                Rank = new RankDTO
                {
                    Id = x.Rank
                },
                Status = x.Status
            })
            .Join(
                _dbContext.Ranks,
                tournament => tournament.Rank.Id,
                rank => rank.Id,
                (tournament, rank) => new TournamentDTO
                {
                    Id = tournament.Id,
                    Name = tournament.Name,
                    Club = tournament.Club,
                    StartDate = tournament.StartDate,
                    EndDate = tournament.EndDate,
                    Image = tournament.Image,
                    City = tournament.City,
                    Rank = new RankDTO
                    {
                        Id = rank.Id,
                        Name = rank.Name,
                        ImgRank = rank.ImgRank
                    },
                    Status = tournament.Status
                }
            )
            .ToArrayAsync();

            return res;
        }

        // Query to get all tournaments between the current date and the specified start date
        public async Task<TournamentsSelectDTO> Query(TournamentsSelectQuery qry)
        {
            var queryable = _dbContext.Tournaments
                // Take the record if x.StartDate is bigger that the qry.StartDate and smaller than qry.EndDate
                .Where(x => DateTime.Compare(x.StartDate, qry.StartDate) == 1 && DateTime.Compare(qry.EndDate, x.StartDate) == 1);

            return new TournamentsSelectDTO
            {
                Tournaments = await queryable
                .Select(x => new TournamentsSelectDTO.Tournament
                {
                    Id = x.Id,
                    Name = x.Name,
                    Club = x.Club,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Img = x.Image
                }).ToArrayAsync()
            };
        }

        public async Task<TournamentsIdDTO> Query(TournamentsIdQuery qry)
        {
            var queryable = _dbContext.Tournaments
                .Where(x => x.Id == qry.Id);

            var res = await RanksJoin(queryable);

            return res.Select(x => new TournamentsIdDTO
            {
                Id = x.Id,
                Name = x.Name,
                Club = x.Club,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Image = x.Image,
                City = x.City,
                Rank = x.Rank,
                Status = x.Status
            }).FirstOrDefault();
        }

        public async Task<TournamentsFiltersDTO> Query(TournamentsFiltersQuery qry)
        {
            var queryable = _dbContext.Tournaments
                .Where(x => (qry.City.Count == 0 || qry.City.Contains(x.City)) &&
                            (qry.Rank.Count == 0 || qry.Rank.Contains(x.Rank)) &&
                            (DateTime.Compare(x.StartDate, qry.StartDate ?? x.StartDate) >= 0) &&
                            (DateTime.Compare(qry.EndDate ?? x.StartDate, x.StartDate) >= 0));

            var res = await RanksJoin(queryable);

            return new TournamentsFiltersDTO
            {
                Tournaments = res.Select(x => new TournamentsFiltersDTO.Tournament
                {
                    Id = x.Id,
                    Name = x.Name,
                    Rank = x.Rank
                })
            };
        }

        public async Task<TournamentsFiltersDTO> Query(TournamentFiltersStatusQuery qry)
        {
            var queryable = _dbContext.Tournaments
                .Where(x => (qry.Status == x.Status) &&
                            (qry.City.Count == 0 || qry.City.Contains(x.City)) &&
                            (qry.Rank.Count == 0 || qry.Rank.Contains(x.Rank)) &&
                            (DateTime.Compare(x.StartDate, qry.StartDate ?? x.StartDate) >= 0) &&
                            (DateTime.Compare(qry.EndDate ?? x.StartDate, x.StartDate) >= 0));

            var res = await RanksJoin(queryable);

            return new TournamentsFiltersDTO
            {
                Tournaments = res.Select(x => new TournamentsFiltersDTO.Tournament
                {
                    Id = x.Id,
                    Name = x.Name,
                    Rank = x.Rank
                })
            };
        }
    }
}
