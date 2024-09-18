using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.ValueObjects;

namespace ReservaPassagem.Domain;

public class Passageiro : EntityBase
{
    public Passageiro(Nome nome, string email, string telefone, List<Reserva>? reservas)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Reservas = reservas;
    }

    public Nome Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public List<Reserva>? Reservas { get; set; }
}