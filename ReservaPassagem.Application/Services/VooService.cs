using OneOf;
using ReservaPassagem.Application.Errors;
using ReservaPassagem.Application.Errors.Error;
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
            return new VooErrors("Voo já existe no sistema.",ErrorType.AlreadyExists.ToString());
        
        var voo = await _vooRepository.AddVoo(entity);
        
        var response = entity.MapToResponse();

        return response;
    }

    public async Task<OneOf<VooResponse, AppError>> ActiveVoo(string vooNumber)
    {
        var vooEntity = await _vooRepository.GetVooByNumber(vooNumber);

        if (vooEntity == null)
            return new VooErrors("Voo não encontrado.",ErrorType.NotFound.ToString());

        if (vooEntity.Ativo)
            return new VooErrors("Voo já está ativo",ErrorType.Conflict.ToString());

        vooEntity.AtivarVoo();
        await _vooRepository.UpdateVoo(vooEntity);
        
        var response = vooEntity.MapToResponse();
        
        return response;
    }

    public async Task<OneOf<VooResponse, AppError>> DisableVoo(string vooNumber)
    {
        var vooEntity = await _vooRepository.GetVooByNumber(vooNumber);
        
        if(vooEntity is null)
            return new VooErrors("Voo não encontrado",ErrorType.NotFound.ToString());
        
        if(!vooEntity.Ativo)
            return new VooErrors("Voo já está desabilitado.",ErrorType.Conflict.ToString());
        
        vooEntity.DesativarVoo();
        
        await _vooRepository.UpdateVoo(vooEntity);

        var response = vooEntity.MapToResponse();

        return response;
    }

    public async Task<OneOf<List<VooResponse>, AppError>> GetByCityOrigin(string cityOrigin)
    {
        var vooEntity = await _vooRepository.GetVooByCityOrigin(cityOrigin);

        if (vooEntity.Count == 0)
            return new VooErrors("Nenhum voo encontrado com essa cidade de origem",ErrorType.NotFound.ToString());

        var response = vooEntity.MapListEntityToResponse();

        return response;
    }

    public async Task<OneOf<List<VooResponse>, AppError>> GetByCityDestination(string cityDestination)
    {
        var vooEntity = await _vooRepository.GetVooByCityDestination(cityDestination);

        if (vooEntity.Count == 0)
            return new VooErrors("Nenhum voo encontrado com essa cidade de destino.", ErrorType.NotFound.ToString());

        var response = vooEntity.MapListEntityToResponse();

        return response;
    }
    
    
}