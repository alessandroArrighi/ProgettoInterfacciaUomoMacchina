using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Security;
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
        public int DrawPosition { get; set; }
        public Status Status { get; set; }
        public Guid Player1Id { get; set; }
        public Guid Player2Id { get; set; }
        public int[] Player1Score { get; set; }
        public int[] Player2Score { get; set; }
    }

    public enum Status
    {
        BeforeStart,
        Start,
        End,
    }

    public class Score
    {
        private const int LEN = 5;
        public List<ScoreSet> Set { get; set; }

        public Score()
        {
            Set = new List<ScoreSet>();
        }

        public Score(int[] p1, int[] p2) : this()
        {
            if (p1.Length != p2.Length)
            {
                throw new Exception();
            }

            for (int i = 0; i < p1.Length; ++i)
            {
                Set.Add(new(p1[i], p2[i]));
            }
        }

        public static int[] ScoreToArray(Score score, int playerIndex)
        {
            if (playerIndex < 0 || playerIndex > 2)
            {
                throw new Exception("Index must be an integer equal to 0 or 1");
            }

            int[] res = new int[score.Set.Count];
            int i = 0;

            foreach (var s in score.Set)
            {
                if (playerIndex == 0)
                {
                    res[i] = s.Score1;
                }

                if (playerIndex == 1)
                {
                    res[i] = s.Score2;
                }

                ++i;
            }

            return res;
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