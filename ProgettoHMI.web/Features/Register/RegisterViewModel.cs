using System.ComponentModel.DataAnnotations;
using ProgettoHMI.Services.Ranks;

namespace ProgettoHMI.web.Features.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [Display(Name = "Nome*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome*")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "L’email è obbligatoria")]
        [EmailAddress(ErrorMessage = "Formato email non valido")]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria")]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Il telefono è obbligatorio")]
        [Phone(ErrorMessage = "Numero di telefono non valido")]
        [Display(Name = "Telefono*")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [Display(Name = "Codice Fiscale*")]
        public string TaxID { get; set; }

        // … campi facoltativi …
        [Display(Name = "Indirizzo (facoltativo)")]
        public string Address { get; set; }

        [Display(Name = "Nazionalità (facoltativo)")]
        public string Nationality { get; set; }

        [Display(Name = "Immagine del profilo (facoltativo)")]
        public string ImgProfile { get; set; }

        [Required(ErrorMessage = "La selezione del rank è richiesta!")]
        public int RankId { get; set; }

        public RanksInfoDTO Ranks { get; set; }
    }
}
