using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Response;
using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Application.Mapper;

public static class VooMapper
{
    public static Voo MapToEntity(this VooRequest vooRequest)
    {
        TimeSpan horasVoo = TimeSpan.FromMinutes(vooRequest.TempoVoo);
        var entity = new Voo(vooRequest.CidadeOrigem, vooRequest.PaisOrigem, vooRequest.CidadeDestino,
            vooRequest.PaisDestino,vooRequest.CompanhiaAerea,horasVoo.ToString(@"hh\:mm"),vooRequest.QuantidadeAssentos);
        return entity;
    }

    public static VooResponse MapToResponse(this Voo entity)
    {
        var response = new VooResponse(entity.Origem.Cidade, entity.Origem.Pais, entity.Destino.Cidade,
            entity.Destino.Pais, entity.NumeroVoo,entity.TempoVoo, entity.CompanhiaAerea, entity.QuantidadeAssentos,
            entity.Ativo);

        return response;
    }

    public static List<VooResponse> MapListEntityToResponse(this List<Voo> entities)
    {
        var response = new List<VooResponse>();
        
        response = entities.Select(x => x.MapToResponse()).ToList();
        
        return response;
    }
}