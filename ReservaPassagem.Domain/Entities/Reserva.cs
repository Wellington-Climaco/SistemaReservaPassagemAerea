using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.Enum;

namespace ReservaPassagem.Domain.Entities;

public class Reserva : EntityBase
{
    protected Reserva()
    {
    }
    public Reserva(Passageiro passageiro, Voo voo, List<Assento> assentos, Guid vooId, Guid passageiroId)
    {
        Passageiro = passageiro;
        Voo = voo;
        Assentos = assentos;
        VooId = vooId;
        PassageiroId = passageiroId;
    }

    public StatusReserva StatusReserva { get; private set; } = StatusReserva.Pendente;
    public Passageiro Passageiro { get; private set; }
    public Guid PassageiroId { get; set; }
    public Voo Voo { get; private set; }
    public Guid VooId { get; private set; }
    public List<Assento> Assentos { get; private set; }
    
}