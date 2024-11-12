using FluentValidation;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Validators;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Campo email não pode ser vazio")
            .EmailAddress().WithMessage("Formato de email inválido");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("Campo senha não pode ser vazio")
            .Length(8,20).WithMessage("Campo senha deve ter de 8 caracteres até 20 caracteres");
        
        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("Campo telefone não pode ser vazio")
            .Length(11).WithMessage("Campo telefone deve ter 11 caracteres");
        
        RuleFor(x => x.Telefone)
            .NotEmpty().WithMessage("Campo telefone não pode ser vazio")
            .Length(11).WithMessage("Campo telefone deve ter 11 caracteres");

        RuleFor(x => x.Cargo)
            .NotEmpty().WithMessage("Campo cargo não pode ser vazio");


    }
}