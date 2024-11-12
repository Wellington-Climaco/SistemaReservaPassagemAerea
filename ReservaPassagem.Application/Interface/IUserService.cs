using OneOf;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Interface;

public interface IUserService
{
     string Login();
     Task<OneOf<string,AppError>> RegisterUser(RegisterUserRequest user);
}