using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgettoHMI.Infrastructure;
using ProgettoHMI.Services.Ranks;

namespace ProgettoHMI.Services.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UsersRankDTO.UserRank Rank { get; set; }
        public string PhoneNumber { get; set; }
        public string TaxID { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string ImgProfile { get; set; }
    }

    // Prendere i giocatori in ordine di rank
    public class UsersRankQuery
    {
        public int count { get; set; }
    }

    public class UsersRankDTO
    {
        public IEnumerable<User> Users { get; set; }

        public class User
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public UserRank Rank { get; set; }
            public string Nationality { get; set; }
        }

        public class UserRank : RankDTO
        {
            public int Points { get; set; }
        }
    }

    public class UserRankQuery
    {
        public Guid Id { get; set; }
    }

    public class UserRankDTO
    {
        public UsersRankDTO.User User { get; set; }
    }



    public class UserStatsQuery
    {
        public Guid Id { get; set; }
    }

    public class UserStatsDTO
    {
        public Guid Id { get; set; }
        public int Points { get; set; }
        public int Rank { get; set; }
        public string ImgProfile { get; set; }
    }

    public class UserDetailQuery
    {
        public Guid Id { get; set; }
    }

    public class UserDetailDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NickName { get; set; }
    }

    public class UserHomeDTO
    {
        public IEnumerable<User> Users;

        public class User
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public UsersRankDTO.UserRank Rank { get; set; }
            public string ImgProfile { get; set; }
        }
    }

    public class CheckLoginCredentialsQuery
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public partial class UsersService
    {
        /// <summary>
        /// Returns users for a select field
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        //public async Task<UsersSelectDTO> Query(UsersSelectQuery qry)
        //{
        //    var queryable = _dbContext.Users
        //        .Where(x => x.Id != qry.IdCurrentUser);

        //    if (string.IsNullOrWhiteSpace(qry.Filter) == false)
        //    {
        //        queryable = queryable.Where(x => x.Email.Contains(qry.Filter, StringComparison.OrdinalIgnoreCase));
        //    }

        //    return new UsersSelectDTO
        //    {
        //        Users = await queryable
        //        .Select(x => new UsersSelectDTO.User
        //        {
        //            Id = x.Id,
        //            Email = x.Email
        //        })
        //        .ToArrayAsync(),
        //        Count = await queryable.CountAsync(),
        //    };
        //}


        public async Task<IEnumerable<UserDTO>> RankJoin(IQueryable<User> users)
        {
            var res = await users.Join(
                    _dbContext.Ranks,
                    user => user.Rank,
                    rank => rank.Id,
                    (user, rank) => new UserDTO
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Surname = user.Surname,
                        Email = user.Email,
                        Password = user.Password,
                        Rank = new UsersRankDTO.UserRank
                        {
                            Id = rank.Id,
                            Name = rank.Name,
                            ImgRank = rank.ImgRank,
                            Points = user.Points
                        },
                        PhoneNumber = user.PhoneNumber,
                        TaxID = user.TaxID,
                        Address = user.Address,
                        ImgProfile = user.ImgProfile,
                        Nationality = user.Nationality
                    }
                )
                .ToListAsync();

            return res;
        }

        // public async Task<List<UsersRankDTO.User>> RankJoin(IQueryable<User> users)
        // {
        //     var res = await users.Join(
        //             _dbContext.Ranks,
        //             user => user.Rank,
        //             rank => rank.Id,
        //             (user, rank) => new UsersRankDTO.User
        //             {
        //                 Id = user.Id,
        //                 Name = user.Name,
        //                 Surname = user.Surname,
        //                 Rank = new UsersRankDTO.UserRank
        //                 {
        //                     Id = rank.Id,
        //                     Name = rank.Name,
        //                     ImgRank = rank.ImgRank,
        //                     Points = user.Points
        //                 },
        //                 Nationality = user.Nationality
        //             }
        //         )
        //         .ToListAsync();

        //     return res;
        // }

        /// <summary>
        /// Returns the detail of the user who matches the Id passed in the qry parameter
        /// </summary>
        /// <param name="qry"></param>
        /// <returns></returns>
        public async Task<UserDetailDTO> Query(UserDetailQuery qry)
        {
            return await _dbContext.Users
                .Where(user => user.Id == qry.Id)
                .Select(user => new UserDetailDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Surname = user.Surname,
                    NickName = user.Name.Substring(0, 1) + ". " + user.Surname
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Check if credentials passed in the query are valid for a user present in the database
        /// </summary>
        /// <param name="qry"></param>
        /// <returns>User data if user has been found and credentials are valid</returns>
        /// <exception cref="LoginException">Invalid credentials</exception>
        public async Task<UserDetailDTO> Query(CheckLoginCredentialsQuery qry)
        {
            var user = await _dbContext.Users
                .Where(x => x.Email == qry.Email)
                .FirstOrDefaultAsync();

            if (user == null || user.IsMatchWithPassword(qry.Password) == false)
                throw new LoginException("Email o password errate");

            return new UserDetailDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            };
        }


        public async Task<UsersRankDTO> Query(UsersRankQuery qry) // prendere il Rank per pi utenti (ordine per Points)
        {
            var users = _dbContext.Users
                .Where(user => user.Points > 0)
                .OrderByDescending(user => user.Points)
                .ThenBy(user => user.Name)
                .Take(qry.count);

            var res = await RankJoin(users);

            return new UsersRankDTO
            {
                Users = res.Select(x => new UsersRankDTO.User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Rank = new UsersRankDTO.UserRank
                    {
                        Id = x.Rank.Id,
                        Name = x.Rank.Name,
                        ImgRank = x.Rank.ImgRank,
                        Points = x.Rank.Points
                    },
                    Nationality = x.Nationality
                })
            };
        }

        public async Task<UserRankDTO> Query(UserRankQuery qry) // prendere il Rank per un singolo utente
        {
            var user = _dbContext.Users
                .Where(user => user.Id == qry.Id);

            var res = await RankJoin(user);

            return new UserRankDTO
            {
                User = res.Select(x => new UsersRankDTO.User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Rank = new UsersRankDTO.UserRank
                    {
                        Id = x.Rank.Id,
                        Name = x.Rank.Name,
                        ImgRank = x.Rank.ImgRank,
                        Points = x.Rank.Points
                    },
                    Nationality = x.Nationality
                })
                .FirstOrDefault()
            };
        }

        public async Task<UserHomeDTO> Query()
        {
            var users = _dbContext.Users
                .OrderByDescending(x => x.Points)
                .Take(10);

            var res = await RankJoin(users);

            return new UserHomeDTO
            {
                Users = [.. res.Select(x => new UserHomeDTO.User
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Rank = new UsersRankDTO.UserRank
                    {
                        Id = x.Rank.Id,
                        Name = x.Rank.Name,
                        ImgRank = x.Rank.ImgRank,
                        Points = x.Rank.Points
                    },
                    ImgProfile = x.ImgProfile
                })]
            };
        }
    }
}
