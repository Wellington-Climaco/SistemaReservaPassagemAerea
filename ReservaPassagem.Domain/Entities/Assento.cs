using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.Enum;

namespace ReservaPassagem.Domain.Entities;

public class Assento : EntityBase
{
    protected Assento()
    {
        
    }
    public Assento(string numero, decimal preco, Classe classe,Voo voo)
    {
        Numero = numero;
        Preco = preco;
        Classe = classe;
        Voo = voo;
    }

    public string Numero { get; private set; }
    public decimal Preco { get; private set; }
    public Classe Classe { get; private set; }
    public bool Disponivel { get; private set; } = true;
    public Voo Voo { get; private set; }
    public Guid VooId { get; set; }
    public Reserva? Reserva { get; set; }
    public Guid ReservaId { get; set; }

    
    void AssentoReservado()
    {
        Disponivel = false;
    }
    
}