using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProgettoHMI.Services;
using ProgettoHMI.Services.Games;
using ProgettoHMI.Services.Shared;
using ProgettoHMI.Services.Tournament;

namespace ProgettoHMI.Infrastructure
{
    public class DataGenerator
    {
        public static void InitializeUsers(TemplateDbContext context)
        {
            if (context.Users.Any())
            {
                return;   // Data was already seeded
            }

            context.Users.AddRange(
                new User
                {
                    Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), // Forced to specific Guid for tests
                    Email = "f.lutterotti@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Prova"
                    Name = "Filippo",
                    Surname = "Lutterotti",
                    Rank = "Gold",
                    PhoneNumber = "1234567890",
                    TaxID = "LTTFPP",
                    Address = "Via Roma 1",
                    Nationality = "Italian",
                    ImgProfile = "..."
                },
                new User
                {
                    Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
                    Email = "a.arrighi@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    Name = "Alessandro",
                    Surname = "Arrighi",
                    Rank = "Gold",
                    PhoneNumber = "1234567890",
                    TaxID = "RRGLSS",
                    Address = "Via Roma 1",
                    Nationality = "Italian",
                    ImgProfile = "..."
                },
                new User
                {
                    Id = Guid.Parse("bfdef48b-c7ea-4227-8333-c635af267354"), // Forced to specific Guid for tests
                    Email = "j.sinner@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    Name = "Jannik",
                    Surname = "Sinner",
                    Rank = "Diamond",
                    PhoneNumber = "1234567890",
                    TaxID = "SNRJNK",
                    Address = "Via Roma 1",
                    Nationality = "Italian",
                    ImgProfile = "..."
                }
            );

            context.Tournaments.AddRange(
                new Tournament
                {
                    Id = Guid.Parse("11000000-0000-0000-0000-000000000000"),
                    Name = "Torneo di Milano",
                    Club = "Circolo di Milano",
                    StartDate = new DateTime(2026, 1, 1, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 7, 18, 0, 0),
                    Image = "...",
                    City = "Milano",
                    Rank = "Diamante",
                    Status = false
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Torneo di Torino",
                    Club = "Circolo di Torino",
                    StartDate = new DateTime(2026, 1, 8, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 14, 18, 0, 0),
                    Image = "...",
                    City = "Torino",
                    Rank = "Oro",
                    Status = false
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Torneo di Bologna",
                    Club = "Circolo di Bologna",
                    StartDate = new DateTime(2026, 1, 15, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 21, 18, 0, 0),
                    Image = "...",
                    City = "Bologna",
                    Rank = "Argento",
                    Status = false
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Torneo di Roma",
                    Club = "Circolo di Roma",
                    StartDate = new DateTime(2026, 1, 22, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 7, 18, 0, 0),
                    Image = "...",
                    City = "Roma",
                    Rank = "Bronzo",
                    Status = false
                }
            );

            context.Games.AddRange(
                new Game
                {
                    GameId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DrawPosition = 1,
                    Status = "false",
                    Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"),
                    Score = new Score([new(7, 6), new(3, 5)])
                },
                new Game
                {
                    GameId = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                    TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DrawPosition = 2,
                    Status = "false",
                    Player1Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"),
                    Player2Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Score = new Score([new(7, 6), new(3, 6), new (2, 0)])
                },
                new Game
                {
                    GameId = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    DrawPosition = 1,
                    Status = "false",
                    Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4dAAA"),
                    Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0BBB"),
                    Score = new Score()
                }
            );

            context.SaveChanges();
        }
    }
}
