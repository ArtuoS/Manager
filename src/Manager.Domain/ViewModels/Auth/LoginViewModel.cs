using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O email não pode ser vázio.")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vázio.")]
        public string Password { get; set; }
    }
}