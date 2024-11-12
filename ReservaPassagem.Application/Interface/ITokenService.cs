using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Entities.Base;

namespace ReservaPassagem.Application.Interface;

public interface ITokenService
{
    public string GerenteToken(User user);
}