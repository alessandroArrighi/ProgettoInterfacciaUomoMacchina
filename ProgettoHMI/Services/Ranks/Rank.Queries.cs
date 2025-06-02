using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Ranks
{
    public class RanksInfoQuery
    {
        
    }

    public class RanksInfoDTO
    {
        public IEnumerable<Rank> Ranks { get; set; }

        public class Rank
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int MinPoints { get; set; }
            public int MaxPoints { get; set; }
            public string Description { get; set; }
            public string ImgRank { get; set; }
        }
    }
    
    public partial class RanksService
    {
        public async Task<RanksInfoDTO> Query(RanksInfoQuery qry)
        {
            var ranks = await _dbContext.Ranks
                .Where(x => x.Id != -1)
                .Select(x => new RanksInfoDTO.Rank
                {
                    Id = x.Id,
                    Name = x.Name,
                    MinPoints = x.MinPoints,
                    MaxPoints = x.MaxPoints,
                    Description = x.Description,
                    ImgRank = x.ImgRank
                })
                .ToListAsync();
            return new RanksInfoDTO
            {
                Ranks = ranks
            };
        }


    }
}