using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.ValueObjects;

namespace ReservaPassagem.Domain.Entities;

public class Voo : EntityBase
{
    protected Voo(string horasVoo)
    {
        HorasVoo = horasVoo;
    }
    public Voo(string cidadeOrigem,string paisOrigem,string cidadeDestino,string paisDestino,
        string numeroVoo, string companhiaAerea, string horasVoo)
    {
        NumeroVoo = numeroVoo;
        CompanhiaAerea = companhiaAerea;
        HorasVoo = horasVoo;
        Origem = new Origem(cidadeOrigem,paisOrigem);
        Destino = new Destino(cidadeDestino,paisDestino);
    }
    
    public string NumeroVoo { get; private set; }
    public Origem Origem { get; private set; }
    public Destino Destino { get; private set; }
    public string HorasVoo { get; private set; }
    public bool Ativo { get; private set; } = false;
    public string CompanhiaAerea { get; private set; }
    public int QuantidadeAssentos { get; private set; }
    public List<Assento> Assentos { get; private set; }
    public List<Reserva>? Reservas { get; private set; } = new();


    public void AtivarVoo()
    {
        Ativo = true;
    }

    public void AdicionaReserva(Reserva reserva)
    {
        Reservas.Add(reserva);
    }

    public void AdicionaAssento(Assento assento)
    {
        if (Assentos.Count() >= QuantidadeAssentos)
            throw new ArgumentOutOfRangeException("Numero de assentos máximo já atingido");
            
        Assentos.Add(assento);
    }
}