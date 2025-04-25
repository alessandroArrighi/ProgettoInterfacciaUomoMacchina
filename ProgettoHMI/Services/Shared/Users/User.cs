using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace ProgettoHMI.Services.Shared.Users
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
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




        /// <summary>
        /// Checks if password passed as parameter matches with the Password of the current user
        /// </summary>
        /// <param name="password">password to check</param>
        /// <returns>True if passwords match. False otherwise.</returns>
        public bool IsMatchWithPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;

            var sha256 = SHA256.Create();
            var testPassword = Convert.ToBase64String(sha256.ComputeHash(Encoding.ASCII.GetBytes(password)));

            return Password == testPassword;
        }
    }
}
