using System;
using System.ComponentModel.DataAnnotations;
using ProgettoHMI.web.Infrastructure;
using ProgettoHMI.Services.Shared;

namespace ProgettoHMI.web.Areas.Example.Users
{
    [TypeScriptModule("Example.Users.Server")]
    public class EditViewModel
    {
        public EditViewModel()
        {
        }

        public Guid? Id { get; set; }
        public string Email { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Display(Name = "Nickname")]
        public string NickName { get; set; }

        public string ToJson()
        {
            return Infrastructure.JsonSerializer.ToJsonCamelCase(this);
        }

        public void SetUser(UserDetailDTO userDetailDTO)
        {
            if (userDetailDTO != null)
            {
                Id = userDetailDTO.Id;
                Email = userDetailDTO.Email;
                Name = userDetailDTO.Name;
                Surname = userDetailDTO.Surname;
                NickName = userDetailDTO.NickName;
            }
        }

        public AddOrUpdateUserCommand ToAddOrUpdateUserCommand()
        {
            return new AddOrUpdateUserCommand
            {
                Id = Id,
                Email = Email,
                Name = Name,
                Surname = Surname,

            };
        }
    }
}