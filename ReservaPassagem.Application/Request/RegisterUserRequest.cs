namespace ReservaPassagem.Application.Request;

public record RegisterUserRequest(string Email, string Senha,string Telefone,string Cargo);