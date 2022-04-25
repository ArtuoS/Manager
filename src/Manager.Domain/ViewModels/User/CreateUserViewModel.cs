using System.ComponentModel.DataAnnotations;

namespace Manager.Domain.ViewModels.User
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vázio.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caractéres.")]
        [MaxLength(80, ErrorMessage = "O nome não pode ter mais de 80 caractéres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vázio.")]
        [MinLength(6, ErrorMessage = "O email deve ter no mínimo 3 caractéres.")]
        [MaxLength(180, ErrorMessage = "O email não pode ter mais de 80 caractéres.")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vázio.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 3 caractéres.")]
        [MaxLength(180, ErrorMessage = "A senha não pode ter mais de 80 caractéres.")]
        public string Password { get; set; }
    }
}