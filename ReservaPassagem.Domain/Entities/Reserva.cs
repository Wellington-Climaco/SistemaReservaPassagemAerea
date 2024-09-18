using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.Enum;

namespace ReservaPassagem.Domain.Entities;

public class Reserva : EntityBase
{
    public Reserva(Passageiro passageiro, Voo voo, List<Assento> assentos)
    {
        Passageiro = passageiro;
        Voo = voo;
        Assentos = assentos;
    }

    public StatusReserva StatusReserva { get; private set; } = StatusReserva.Pendente;
    public Passageiro Passageiro { get; private set; }
    public Voo Voo { get; private set; }
    public List<Assento> Assentos { get; private set; }
    
}