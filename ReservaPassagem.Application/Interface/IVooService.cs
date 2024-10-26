using OneOf;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Response;

namespace ReservaPassagem.Application.Interface;

public interface IVooService
{
    Task<OneOf<VooResponse,AppError>> AddVoo(VooRequest request);
    Task<OneOf<VooResponse, AppError>> ActiveVoo(string vooNumber);
}