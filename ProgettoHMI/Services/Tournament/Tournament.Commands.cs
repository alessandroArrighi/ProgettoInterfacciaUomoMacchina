using System;
using System.Data.Common;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable enable

namespace ProgettoHMI.Services.Tournament
{
    public class AddOrUpdateTournamentCommand
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Club { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Image { get; set; }
        public string? City { get; set; }
        public int? Rank { get; set; }
        public Status? Status { get; set; }
    }

    public partial class TournamentService
    {
        public async Task<Guid?> Handle(AddOrUpdateTournamentCommand cmd)
        {
            var tournament = await _dbContext.Tournaments
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (tournament == null)
            {
                try
                {
                    tournament = new Tournament
                    {
                        Id = Guid.NewGuid(),
                        Name = cmd.Name ?? throw new Exception(),
                        Club = cmd.Club ?? throw new Exception(),
                        StartDate = cmd.StartDate ?? throw new Exception(),
                        EndDate = cmd.EndDate ?? throw new Exception(),
                        Image = cmd.Image ?? throw new Exception(),
                        City = cmd.City ?? throw new Exception(),
                        Rank = cmd.Rank ?? throw new Exception(),
                        Status = cmd.Status ?? throw new Exception()
                    };
                    _dbContext.Tournaments.Add(tournament);
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                tournament.Name = cmd.Name ?? tournament.Name;
                tournament.Club = cmd.Club ?? tournament.Club;
                tournament.StartDate = cmd.StartDate ?? tournament.StartDate;
                tournament.EndDate = cmd.EndDate ?? tournament.EndDate;
                tournament.Image = cmd.Image ?? tournament.Image;
                tournament.City = cmd.City ?? tournament.City;
                tournament.Rank = cmd.Rank ?? tournament.Rank;
                tournament.Status = cmd.Status ?? tournament.Status;
            }

            await _dbContext.SaveChangesAsync();

            return tournament.Id;
        }
    }
}