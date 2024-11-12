using ReservaPassagem.Application.Request;
using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Application.Mapper;

public static class UserMapper
{
    public static User MapToEntity(this RegisterUserRequest user)
    {
        var entity = new User(user.Email, user.Senha, user.Telefone, user.Cargo);
        return entity;
    }
}