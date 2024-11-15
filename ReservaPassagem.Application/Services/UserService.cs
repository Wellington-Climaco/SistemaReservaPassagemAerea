using FluentResults;
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
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<Result<string>> Login(AuthUserRequest credentials)
    {
        var result = await _userRepository.GetUserByEmail(credentials.Email);
        
        if(result == null)
            return Result.Fail("Email não encontrado.");

        var passwordIsCorrect = result.Senha.VerifyPassword(result.Senha.Hash, credentials.Senha);

        if (!passwordIsCorrect)
            return Result.Fail("Senha incorreta.");

        var token = _tokenService.GerenteToken(result);
        
        return Result.Ok(token);
    }

    public async Task<Result<string>> RegisterUser(RegisterUserRequest user)
    {
        var result = await _userRepository.GetUserByEmail(user.Email);

        if (result != null)
            return Result.Fail("Email já cadastrado no sistema.");

        var entity = user.MapToEntity();

        var entityResult = await _userRepository.RegisterUser(entity);
        
        if(entityResult == null)
            return Result.Fail("Não foi possivel criar o registro.");

        return Result.Ok("Usuário criado com sucesso.");
    }
}