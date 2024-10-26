using ReservaPassagem.Application.Request;
using ReservaPassagem.Application.Response;
using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Application.Mapper;

public static class VooMapper
{
    public static Voo MapToEntity(this VooRequest vooRequest)
    {
        var entity = new Voo(vooRequest.CidadeOrigem, vooRequest.PaisOrigem, vooRequest.CidadeDestino,
            vooRequest.PaisDestino,vooRequest.CompanhiaAerea,vooRequest.TempoVoo.ToString(),vooRequest.QuantidadeAssentos);
        return entity;
    }

    public static VooResponse MapToResponse(this Voo entity)
    {
        var response = new VooResponse(entity.Origem.Cidade, entity.Origem.Pais, entity.Destino.Cidade,
            entity.Destino.Pais, entity.NumeroVoo, $"{entity.TempoVoo} minutos", entity.CompanhiaAerea, entity.QuantidadeAssentos,
            entity.Ativo);

        return response;
    }
}