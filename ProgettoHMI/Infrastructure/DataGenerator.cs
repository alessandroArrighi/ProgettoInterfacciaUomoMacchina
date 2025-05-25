using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ProgettoHMI.Services;
using ProgettoHMI.Services.Games;
using ProgettoHMI.Services.Tournament;
using System.Runtime.InteropServices.ComTypes;
using ProgettoHMI.Services.Ranks;
using ProgettoHMI.Services.Users;


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
                    Rank = 2,
                    Points = 1200, 
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
                    Rank = 2,
                    Points = 1800,
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
                    Rank = 1,
                    Points = 2950,
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
                    Status = Services.Tournament.Status.BeforeStart
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
                    Status = Services.Tournament.Status.BeforeStart
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
                    Status = Services.Tournament.Status.BeforeStart
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
                    Status = Services.Tournament.Status.BeforeStart
                }
            );

            context.Games.AddRange(
                new Game
                {
                    GameId = Guid.Parse("00000000-0000-0000-0000-000000000010"),
                    TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DrawPosition = 1,
                    Status = Services.Games.Status.BeforeStart,
                    Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"),
                    Player1Score = [4, 5],
                    Player2Score = [6, 7]
                },
                new Game
                {
                    GameId = Guid.Parse("00000000-0000-0000-0000-000000000020"),
                    TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    DrawPosition = 2,
                    Status = Services.Games.Status.BeforeStart,
                    Player1Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"),
                    Player2Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"),
                    Player1Score = [7, 3, 2],
                    Player2Score = [6, 6, 0]
                },
                new Game
                {
                    GameId = Guid.Parse("00000000-0000-0000-0000-000000000030"),
                    TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    DrawPosition = 1,
                    Status = Services.Games.Status.BeforeStart,
                    Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4dAAA"),
                    Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0BBB"),
                    Player1Score = [],
                    Player2Score = []
                }
            );

            context.Ranks.AddRange(
                new Rank
                {
                    Id = 1,
                    Name = "Bronzo",
                    MinPoints = 0,
                    MaxPoints = 599,
                    Description = "Giocatore che ha appena superato le prime avversità.",
                    ImgRank = "bronze.svg"
                },
                new Rank
                {
                    Id = 2,
                    Name = "Argento",
                    MinPoints = 600,
                    MaxPoints = 1199,
                    Description = "Giocatore capace di sferrare bei solidi colpi, ma fatica a trovare continuità.",
                    ImgRank = "silver.svg"
                },
                new Rank
                {
                    Id = 3,
                    Name = "Oro",
                    MinPoints = 1200,
                    MaxPoints = 2499,
                    Description = "Giocatore che riesce a controllare i propri colpi, con un buon servizio.",
                    ImgRank = "gold.svg"
                },
                new Rank
                {
                    Id = 4,
                    Name = "Diamante",
                    MinPoints = 2500,
                    MaxPoints = 15000,
                    Description = "Giocatore esperto, capace di sferrare vincenti in ogni zona del campo.",
                    ImgRank = "diamond.svg"
                });

            context.SaveChanges();
        }
    }
}
