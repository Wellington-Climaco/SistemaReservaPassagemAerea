using ReservaPassagem.Application.DTOs;

namespace ReservaPassagem.Application.Request;

public record VooRequest(string cidadeOrigem,string paisOrigem,string cidadeDestino,string paisDestino,
    string numeroVoo,TimeSpan horasVoo, string companhiaAerea, List<AssentoDTO> assento);

   