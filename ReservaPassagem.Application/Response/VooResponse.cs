namespace ReservaPassagem.Application.Response;

public record VooResponse(
    string CidadeOrigem,
    string PaisOrigem,
    string CidadeDestino,
    string PaisDestino,
    string NumeroVoo,
    string TempoVoo,
    string CompanhiaAerea,
    int QuantidadeAssentos,
    bool Ativo);
