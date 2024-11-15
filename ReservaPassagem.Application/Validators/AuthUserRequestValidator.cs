using FluentValidation;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Validators;

public class AuthUserRequestValidator : AbstractValidator<AuthUserRequest>
{
    public AuthUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Campo email não pode ser vazio")
            .EmailAddress().WithMessage("Formato de email inválido");
        
        RuleFor(x=>x.Senha)
            .NotEmpty().WithMessage("Campo email não pode ser vazio")
            .Length(8,20).WithMessage("Campo senha deve ter de 8 caracteres até 20 caracteres");
    }
}