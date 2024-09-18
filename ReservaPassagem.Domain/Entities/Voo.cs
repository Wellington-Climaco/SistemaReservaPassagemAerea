using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.ValueObjects;

namespace ReservaPassagem.Domain.Entities;

public class Voo : EntityBase
{
    public Voo(string cidadeOrigem,string paisOrigem,string cidadeDestino,string paisDestino,
        string numeroVoo, DateTime partida, DateTime chegada, string companhiaAerea, List<Assento> assentos)
    {
        NumeroVoo = numeroVoo;
        Partida = partida;
        Chegada = chegada;
        CompanhiaAerea = companhiaAerea;
        Assentos = assentos;
        Origem = new Origem(cidadeOrigem,paisOrigem);
        Destino = new Destino(cidadeDestino,paisDestino);
    }
    
    public string NumeroVoo { get; private set; }
    public Origem Origem { get; private set; }
    public Destino Destino { get; private set; }
    public DateTime Partida { get; private set; }
    public DateTime Chegada { get; private set; }
    public string CompanhiaAerea { get; private set; }
    public List<Assento> Assentos { get; private set; }
    
    
    
}