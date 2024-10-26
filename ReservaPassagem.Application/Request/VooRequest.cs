using ReservaPassagem.Application.DTOs;

namespace ReservaPassagem.Application.Request;

public record VooRequest(string CidadeOrigem,string PaisOrigem,string CidadeDestino,string PaisDestino,
    int TempoVoo, string CompanhiaAerea, int QuantidadeAssentos);

   