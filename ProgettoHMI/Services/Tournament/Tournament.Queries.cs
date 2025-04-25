using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.Services.Tournament
{
    public class TournamentsSelectQuery {
        public DateTime StartDate { get; set; }
    }
    public class TournamentsDTO
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

    public class TournamentsIdDTO {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Rank { get; set; }
        public bool Status { get; set; }
    }

    public partial class TournamentService
    {
        public async Task<TournamentsDTO> Query(TournamentsSelectQuery qry)
        {
            var queryable = _dbContext.Tournaments
                .Where(x => DateTime.Compare(x.StartDate, qry.StartDate) == 1);

            return new TournamentsDTO {
                Tournaments = await queryable
                .Select(x => new TournamentsDTO.Tournament {
                    Id = x.Id,
                    Name = x.Name,
                    Club = x.Club,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Img = x.Image
                }).ToArrayAsync()
            };
        }

        public async Task<TournamentsIdDTO> Query(TournamentsIdQuery qry) {
            return await _dbContext.Tournaments
                .Where(x => x.Id == qry.Id)
                .Select(x => new TournamentsIdDTO {
                    Id = x.Id,
                    Name = x.Name,
                    Club = x.Club,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Image = x.Image,
                    City = x.City,
                    Rank = x.Rank,
                    Status = x.Status
                })
                .FirstOrDefaultAsync();
        }
    }
}
