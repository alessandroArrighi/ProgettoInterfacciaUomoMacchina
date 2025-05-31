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
                    Rank = 3,
                    Points = 1200, 
                    PhoneNumber = "1234567890",
                    TaxID = "LTTFPP",
                    Address = "Via Roma 1",
                    Nationality = "Italian",
                    ImgProfile = "monfils.jpg"
                },
                new User
                {
                    Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), // Forced to specific Guid for tests
                    Email = "a.arrighi@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    Name = "Alessandro",
                    Surname = "Arrighi",
                    Rank = 1,
                    Points = 1800,
                    PhoneNumber = "1234567890",
                    TaxID = "RRGLSS",
                    Address = "Via Roma 1",
                    Nationality = "Italian",
                    ImgProfile = "monfils.jpg"
                },
                new User
                {
                    Id = Guid.Parse("bfdef48b-c7ea-4227-8333-c635af267354"), // Forced to specific Guid for tests
                    Email = "j.sinner@test.it",
                    Password = "Uy6qvZV0iA2/drm4zACDLCCm7BE9aCKZVQ16bg80XiU=", // SHA-256 of text "Test"
                    Name = "Jannik",
                    Surname = "Sinner",
                    Rank = 4,
                    Points = 2950,
                    PhoneNumber = "1234567890",
                    TaxID = "SNRJNK",
                    Address = "Via Roma 1",
                    Nationality = "Italian",
                    ImgProfile = "monfils.jpg"
                },
                new User
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Email = string.Empty,
                    Password = string.Empty,
                    Name = "TBD",
                    Surname = string.Empty,
                    Rank = -1,
                    Points = -1,
                    PhoneNumber = string.Empty,
                    TaxID = string.Empty,
                    Address = string.Empty,
                    Nationality = string.Empty,
                    ImgProfile = "user.jpg"
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
                    Image = "wimbledon.jpg",
                    City = "Milano",
                    Rank = 4,
                    Status = Services.Tournament.Status.BeforeStart
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Name = "Torneo di Torino",
                    Club = "Circolo di Torino",
                    StartDate = new DateTime(2026, 1, 8, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 14, 18, 0, 0),
                    Image = "wimbledon.jpg",
                    City = "Torino",
                    Rank = 2,
                    Status = Services.Tournament.Status.BeforeStart
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Name = "Torneo di Bologna",
                    Club = "Circolo di Bologna",
                    StartDate = new DateTime(2026, 1, 15, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 21, 18, 0, 0),
                    Image = "wimbledon.jpg",
                    City = "Bologna",
                    Rank = 1,
                    Status = Services.Tournament.Status.BeforeStart
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                    Name = "Torneo di Roma",
                    Club = "Circolo di Roma",
                    StartDate = new DateTime(2026, 1, 22, 15, 0, 0),
                    EndDate = new DateTime(2026, 1, 7, 18, 0, 0),
                    Image = "wimbledon.jpg",
                    City = "Roma",
                    Rank = 3,
                    Status = Services.Tournament.Status.BeforeStart
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000004"),
                    Name = "Torneo di Napoli",
                    Club = "Circolo di Napoli",
                    StartDate = DateTime.Now.AddDays(7),
                    EndDate = DateTime.Now.AddDays(14),
                    Image = "wimbledon.jpg",
                    City = "Napoli",
                    Rank = 4,
                    Status = Services.Tournament.Status.BeforeStart
                },
                new Tournament
                {
                    Id = Guid.Parse("00000000-0000-0000-0000-000000000005"),
                    Name = "Torneo di Palermo",
                    Club = "Circolo di Palermo",
                    StartDate = DateTime.Now.AddDays(14),
                    EndDate = DateTime.Now.AddDays(21),
                    Image = "wimbledon.jpg",
                    City = "Palermo",
                    Rank = 2,
                    Status = Services.Tournament.Status.BeforeStart
                }
            );

            context.Games.AddRange(
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000051"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [4, 4, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000052"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [3, 2, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000053"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [7, 6, 6], Player2Score = [5, 4, 3] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000054"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [0, 1, 2] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000055"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 6, 6], Player2Score = [4, 6, 3, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000056"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 2, 6, 7], Player2Score = [4, 6, 4, 5] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000057"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [4, 4, 3] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000058"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 6, 6], Player2Score = [3, 6, 3, 5] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000059"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [1, 4, 2] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-00000000005A"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [7, 6, 6], Player2Score = [6, 3, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-00000000005B"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 6, 6], Player2Score = [3, 6, 3, 5] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-00000000005C"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [3, 4, 3], Player2Score = [6, 6, 6] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-00000000005D"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [1, 4, 3] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-00000000005E"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [2, 2, 2] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-00000000005F"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [4, 5, 3] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000060"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 5, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 7, 4, 5], Player2Score = [3, 6, 6, 6, 7] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000042"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [1, 2, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000043"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [7, 6, 6], Player2Score = [5, 4, 3] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000044"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 6, 6], Player2Score = [3, 6, 3, 5] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000045"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [0, 0, 2] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000046"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [3, 4, 2] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000047"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 7, 4, 5], Player2Score = [3, 6, 6, 6, 7] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000048"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 4, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 7, 6], Player2Score = [5, 5, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000031"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 3, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 6, 6], Player2Score = [3, 4, 3] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000032"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 3, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 7, 4, 5], Player2Score = [3, 6, 6, 6, 7] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000033"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 3, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [5, 4, 5], Player2Score = [6, 6, 6] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000034"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 3, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 7, 6], Player2Score = [4, 5, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000010"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 2, Status = Services.Games.Status.End, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player1Score = [6, 4, 7, 4, 5], Player2Score = [3, 6, 6, 6, 7] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000020"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 2, Status = Services.Games.Status.Start, Player1Id = Guid.Parse("a030ee81-31c7-47d0-9309-408cb5ac0ac7"), Player2Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player1Score = [7, 6, 0], Player2Score = [3, 4, 4] },
                new Game { GameId = Guid.Parse("00000000-0000-0000-0000-000000000030"), TournamentId = Guid.Parse("00000000-0000-0000-0000-000000000003"), DrawPosition = 1, Status = Services.Games.Status.BeforeStart, Player1Id = Guid.Parse("3de6883f-9a0b-4667-aa53-0fbc52c4d300"), Player2Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Player1Score = [], Player2Score = [] }
            );

            context.Ranks.AddRange(
                new Rank
                {
                    Id = -1,
                    Name = string.Empty,
                    MinPoints = -1,
                    MaxPoints = -1,
                    Description = string.Empty,
                    ImgRank = string.Empty
                },
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
