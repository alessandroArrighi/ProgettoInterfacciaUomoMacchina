using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoHMI.Services.Ranks
{
    public class Rank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPoints { get; set; }
        public int MaxPoints { get; set; }
        public string ImgRank { get; set; }
        public string Description { get; set; }
    }

    public class RankDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImgRank { get; set; }
    }
}
