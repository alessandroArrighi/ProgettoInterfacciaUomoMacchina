using System.ComponentModel.DataAnnotations;

namespace ProgettoHMI.web.Features.Register
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Name*")]
        [DataType(DataType.EmailAddress)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname*")]
        [DataType(DataType.EmailAddress)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }


    }
}
