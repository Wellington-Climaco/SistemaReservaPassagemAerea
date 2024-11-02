using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.ValueObjects;

namespace ReservaPassagem.Domain.Entities;

public class Voo : EntityBase
{
    protected Voo()
    {
    }
    public Voo(string cidadeOrigem,string paisOrigem,string cidadeDestino,string paisDestino,
        string companhiaAerea, string tempoVoo,int quantidadeAssentos)
    {
        CompanhiaAerea = companhiaAerea;
        TempoVoo = tempoVoo;
        Origem = new Origem(cidadeOrigem,paisOrigem);
        Destino = new Destino(cidadeDestino,paisDestino);
        QuantidadeAssentos = quantidadeAssentos;
    }

    public string NumeroVoo { get; private set; } = Guid.NewGuid().ToString("N").Substring(0,6).ToUpper();
    public Origem Origem { get; private set; }
    public Destino Destino { get; private set; }
    public string TempoVoo { get; private set; }
    public bool Ativo { get; private set; } = false;
    public string CompanhiaAerea { get; private set; }
    public int QuantidadeAssentos { get; private set; }
    public List<Assento>? Assentos { get; private set; } = new();
    public List<Reserva>? Reservas { get; private set; } = new();


    public void AtivarVoo()
    {
        if(!Ativo)
            Ativo = true;
    }
    
    public void DesativarVoo()
    {
        if(Ativo)
            Ativo = false;
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