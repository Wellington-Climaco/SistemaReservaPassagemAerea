using FluentValidation;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Validators;

public class VooRequestValidator : AbstractValidator<VooRequest>
{
    public VooRequestValidator()
    {
        RuleFor(x => x.CidadeOrigem)
            .NotEmpty().WithMessage("Campo cidadeOrigem não pode ser vazio.")
            .Length(3, 50);

        RuleFor(x => x.PaisOrigem)
            .NotEmpty().WithMessage("Campo paisOrigem não pode ser vazio.")
            .MinimumLength(3);
        
        RuleFor(x => x.CidadeDestino)
            .NotEmpty().WithMessage("Campo cidadeDestino não pode ser vazio.")
            .Length(3, 50);

        RuleFor(x => x.PaisDestino)
            .NotEmpty().WithMessage("Campo paisDestino não pode ser vazio.")
            .MinimumLength(3);
        
        RuleFor(x => x.TempoVoo)
            .GreaterThan(30).WithMessage("Tempo de voo precisa ser maior que 30 minutos");
        
        RuleFor(x => x.CompanhiaAerea)
            .NotEmpty().WithMessage("Campo companhiaAerea não pode ser vazio.")
            .MinimumLength(3);
        
    }
}