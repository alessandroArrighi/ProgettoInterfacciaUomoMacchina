using System.ComponentModel.DataAnnotations;

namespace ProgettoHMI.web.Features.Register
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome*")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cognome*")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Email*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono*")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Codice Fiscale*")]
        public string TaxID { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Indirizzo (facoltativo)")]
        public string Address { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Nazionalità (facoltativo)")]
        public string Nationality { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Immagine del profilo (facoltativo)")]
        public string ImgProfile { get; set; }

    }
}
