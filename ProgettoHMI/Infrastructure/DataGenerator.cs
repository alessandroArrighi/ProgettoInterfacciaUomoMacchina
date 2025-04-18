﻿using System;
using System.Linq;
using ProgettoHMI.Services;
using ProgettoHMI.Services.Shared;

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
                });

            context.SaveChanges();
        }
    }
}
