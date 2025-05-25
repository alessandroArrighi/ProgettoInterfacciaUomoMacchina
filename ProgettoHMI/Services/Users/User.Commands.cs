using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Services.Statistics;

namespace ProgettoHMI.Services.Users
{
    public class AddOrUpdateUserCommand
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Rank { get; set; }
        public int Points { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxID { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string ImgProfile { get; set; }
    }

    public partial class UsersService
    {
        public async Task<Guid> Handle(AddOrUpdateUserCommand cmd)
        {
            var user = await _dbContext.Users
                .Where(x => x.Id == cmd.Id)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = cmd.Email,
                    Password = User.EncodePasswordSha256Base64(cmd.Password),
                    Name = cmd.Name,
                    Surname = cmd.Surname,
                    Rank = cmd.Rank,
                    Points = cmd.Points,
                    PhoneNumber = cmd.PhoneNumber,
                    TaxID = cmd.TaxID,
                    Address = cmd.Address,
                    Nationality = cmd.Nationality,
                    ImgProfile = cmd.ImgProfile
                };
                Console.WriteLine("User not found, creating new user: " + user.Id);
                Console.Write(user);
                _dbContext.Users.Add(user);

                var _statisticsService = new StatisticsService(_dbContext);

                var stats = new AddOrUpdateStatisticCommand
                {
                    IDUser = user.Id,
                    MatchesPlayed = 0,
                    MatchesWon = 0,
                    MatchesLost = 0,
                    Aces = 0,
                    DoubleFaults = 0,
                    FirstService = 0,
                    SecondService = 0,
                    Returns = 0
                };
                Console.WriteLine("Creating new statistics for user: " + user.Id);

                await _statisticsService.Handle(stats); // Add stastistics

            }

            user.Name = cmd.Name;
            user.Surname = cmd.Surname;

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}