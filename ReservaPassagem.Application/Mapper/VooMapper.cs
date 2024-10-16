using ReservaPassagem.Application.Request;
using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Application.Mapper;

public static class VooMapper
{
    public static Voo MapToEntity(this VooRequest vooRequest)
    {
        var entity = new Voo(vooRequest.cidadeOrigem, vooRequest.paisOrigem, vooRequest.cidadeDestino,
            vooRequest.paisDestino, vooRequest.numeroVoo,
            vooRequest.companhiaAerea,vooRequest.horasVoo.ToString());
        return entity;
    }
}