using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProgettoHMI.Services.Shared.Users
{
    public class AddOrUpdateUserCommand
    {
        public Guid? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Rank { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxID { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string ImgProfile { get; set; }
    }

    public partial class SharedService
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
                    Password = cmd.Password,
                    Name = cmd.Name,
                    Surname = cmd.Surname,
                    Rank = cmd.Rank,
                    PhoneNumber = cmd.PhoneNumber,
                    TaxID = cmd.TaxID,
                    Address = cmd.Address,
                    Nationality = cmd.Nationality,
                    ImgProfile = cmd.ImgProfile
                };
               // Console.Write(user)
                _dbContext.Users.Add(user);
            }

            user.Name = cmd.Name;
            user.Surname = cmd.Surname;

            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
    }
}