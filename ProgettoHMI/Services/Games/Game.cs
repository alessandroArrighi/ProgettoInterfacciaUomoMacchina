using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Security.AccessControl;
using System.Security.Cryptography;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.Services.Games
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GameId { get; set; }
        public Guid TournamentId { get; set; }
        public int DrawPosition {get; set; }
        public string Status { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }

        [NotMapped]
        public Score Score { get; set; }
    }

    public class Score
    {
        private const int LEN = 5;
        public List<ScoreSet> Set;

        public Score()
        {
            Set = new List<ScoreSet>();
        }

        public Score(List<ScoreSet> sets)
        {
            Set = sets;
        }
    }

    public struct ScoreSet {
        public int Score1;
        public int Score2;

        public ScoreSet(int S1, int S2) {
            Score1 = S1;
            Score2 = S2;
        }
    }
}