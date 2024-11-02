namespace ReservaPassagem.Application.Errors.Error;

public record VooErrors(string Mensagem,string TypeError) : AppError(Mensagem, TypeError);