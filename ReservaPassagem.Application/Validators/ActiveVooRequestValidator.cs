using FluentValidation;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Validators;

public class ActiveVooRequestValidator : AbstractValidator<ActiveVooRequest>
{
    public ActiveVooRequestValidator()
    {
        RuleFor(x => x.numeroVoo)
            .Length(6).WithMessage("numeroVoo deve ter 6 caracteres.")
            .NotEmpty().WithMessage("Campo numeroVoo não pode ser vazio");
    }
}