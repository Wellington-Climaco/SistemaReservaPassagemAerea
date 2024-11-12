using OneOf;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Mapper;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Domain.Interface;

namespace ReservaPassagem.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public string Login()
    {
        throw new NotImplementedException();
    }

    public async Task<OneOf<string,AppError>> RegisterUser(RegisterUserRequest user)
    {
        var result = _userRepository.GetUserByEmail(user.Email);
        
        if (result == null)
            return new AppError("Email já cadastrado no sistema.",ErrorType.AlreadyExists.ToString());

        var entity = user.MapToEntity();

        var entityResult = await _userRepository.RegisterUser(entity);

        return "Usuário criado com sucesso.";
    }
}