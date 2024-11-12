using System.Security.Cryptography;
using ReservaPassagem.Domain.Entities.Base;
using ReservaPassagem.Domain.ValueObjects;

namespace ReservaPassagem.Domain.Entities;

public class User : EntityBase
{
    protected User()
    {
        
    }
    public User(string email,string senha,string telefone,string role)
    {
        Email = email;
        Senha = new Senha(senha);
        Telefone = telefone;
        Role = role;
    }
    
    public string Email { get; private set; }
    public Senha Senha { get; private set; }
    public string Telefone { get; private set; }
    public string Role { get; private set; }
}