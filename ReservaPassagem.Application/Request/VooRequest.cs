using ReservaPassagem.Application.DTOs;

namespace ReservaPassagem.Application.Request;

public record VooRequest(string CidadeOrigem,string PaisOrigem,string CidadeDestino,string PaisDestino,
    int MinutosVoo, string CompanhiaAerea, int QuantidadeAssentos);

   