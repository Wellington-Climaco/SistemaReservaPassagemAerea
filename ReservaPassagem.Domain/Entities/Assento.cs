using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.Enum;

namespace ReservaPassagem.Domain.Entities;

public class Assento : EntityBase
{
    public Assento(string numero, decimal preco, Classe classe,Voo voo, Reserva? reserva)
    {
        Numero = numero;
        Preco = preco;
        Classe = classe;
        Voo = voo;
        Reserva = reserva;
    }

    public string Numero { get; private set; }
    public decimal Preco { get; private set; }
    public Classe Classe { get; private set; }
    public bool Disponivel { get; private set; } = true;
    public Voo Voo { get; private set; } 
    public Reserva? Reserva { get; set; }

    
    void AssentoReservado()
    {
        Disponivel = false;
    }
    
}