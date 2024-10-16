using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Mapper;
using ReservaPassagem.Application.Request;
using ReservaPassagem.Domain.Interface;

namespace ReservaPassagem.Application.Services;

public class VooService : IVooService
{
    private readonly IVooRepository _vooRepository;

    public VooService(IVooRepository vooRepository)
    {
        _vooRepository = vooRepository;
    }

    public void AddVoo(VooRequest request)
    {
        var entity = request.MapToEntity();
        
        _vooRepository.AddVoo(entity);
    }
}