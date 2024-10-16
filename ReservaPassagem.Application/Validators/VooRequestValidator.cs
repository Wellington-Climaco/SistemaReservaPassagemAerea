using FluentValidation;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Validators;

public class VooRequestValidator : AbstractValidator<VooRequest>
{
    public VooRequestValidator()
    {
        RuleFor(x => x.cidadeOrigem)
            .NotEmpty().WithMessage("Campo cidadeOrigem não pode ser vazio.")
            .Length(3, 50);

        RuleFor(x => x.paisOrigem)
            .NotEmpty().WithMessage("Campo paisOrigem não pode ser vazio.")
            .MinimumLength(3);
        
        RuleFor(x => x.cidadeDestino)
            .NotEmpty().WithMessage("Campo cidadeDestino não pode ser vazio.")
            .Length(3, 50);

        RuleFor(x => x.paisDestino)
            .NotEmpty().WithMessage("Campo paisDestino não pode ser vazio.")
            .MinimumLength(3);
        
        RuleFor(x => x.numeroVoo)
            .NotEmpty().WithMessage("Campo numeroVoo não pode ser vazio.")
            .MinimumLength(3);

        RuleFor(x => x.horasVoo)
            .GreaterThan(TimeSpan.FromMinutes(40)).WithMessage("Tempo de voo precisa ser maior que ");
        
        RuleFor(x => x.companhiaAerea)
            .NotEmpty().WithMessage("Campo companhiaAerea não pode ser vazio.")
            .MinimumLength(3);
        
        
    }
}