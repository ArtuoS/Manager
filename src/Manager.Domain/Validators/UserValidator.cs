using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")
                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("O nome não pode ser nulo")
                .NotEmpty()
                .WithMessage("O nome não pode ser vázio.")
                .MinimumLength(3)
                .WithMessage("O nome deve ter no mínimo 3 caractéres.")
                .MaximumLength(80)
                .WithMessage("O nome não pode ter mais de 80 caractéres.");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("O email não pode ser nulo")
                .NotEmpty()
                .WithMessage("O email não pode ser vázio.")
                .MinimumLength(6)
                .WithMessage("O email deve ter no mínimo 6 caractéres.")
                .MaximumLength(180)
                .WithMessage("O email não pode ter mais de 180 caractéres.")
                .Matches(@"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i")
                .WithMessage("Email inválido.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode ser nulo")
                .NotEmpty()
                .WithMessage("A senha não pode ser vázio.")
                .MinimumLength(3)
                .WithMessage("A senha deve ter no mínimo 3 caractéres.")
                .MaximumLength(80)
                .WithMessage("A senha não pode ter mais de 80 caractéres.");
        }
    }
}