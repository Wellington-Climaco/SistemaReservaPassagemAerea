using OneOf;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Errors.VooErrors;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Mapper;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Response;
using ReservaPassagem.Domain.Interface;

namespace ReservaPassagem.Application.Services;

public class VooService : IVooService
{
    private readonly IVooRepository _vooRepository;

    public VooService(IVooRepository vooRepository)
    {
        _vooRepository = vooRepository;
    }

    public async Task<OneOf<VooResponse,AppError>> AddVoo(VooRequest request)
    {
        var entity = request.MapToEntity();
        
        var vooExist = await _vooRepository.GetVooByNumber(entity.NumeroVoo);

        if (vooExist != null)
            return new VooErrors("Voo já existe no sistema.");
        
        var voo = await _vooRepository.AddVoo(entity);
        
        var response = entity.MapToResponse();

        return response;
    }

    public async Task<OneOf<VooResponse, AppError>> ActiveVoo(string vooNumber)
    {
        var vooEntity = await _vooRepository.GetVooByNumber(vooNumber);

        if (vooEntity == null)
            return new VooErrors("Voo não encontrado.");

        if (vooEntity.Ativo)
            return new VooErrors("Voo já está ativo");

        vooEntity.AtivarVoo();
        await _vooRepository.UpdateVoo(vooEntity);
        
        var response = vooEntity.MapToResponse();
        
        return response;
    }
}