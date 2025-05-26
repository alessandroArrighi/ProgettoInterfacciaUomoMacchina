using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoHMI.Services.Tournament
{
    public class Tournament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Club { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public int Rank { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        BeforeStart,
        Start,
        End,
    }
}