using FluentResults;
using OneOf;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Interface;

public interface IUserService
{
     Task<Result<string>> Login(AuthUserRequest credentials);
     Task<Result<string>> RegisterUser(RegisterUserRequest user);
}