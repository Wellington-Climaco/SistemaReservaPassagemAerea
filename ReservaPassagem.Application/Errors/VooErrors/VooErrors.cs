namespace ReservaPassagem.Application.Errors.VooErrors;

public record VooErrors(string message) : AppError()
{
}