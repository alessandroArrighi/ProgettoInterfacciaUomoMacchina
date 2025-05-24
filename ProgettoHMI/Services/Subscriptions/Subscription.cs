using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoHMI.Services.Subscriptions
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {  get; set; }
        public Guid IDUser { get; set; }
        public Guid IDTournament { get; set; }
        public int PointsGained { get; set; } = 0;
    }
}
