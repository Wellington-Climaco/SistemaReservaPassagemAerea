using ReservaPassagem.Domain.Enum;

namespace ReservaPassagem.Application.DTOs;

public record AssentoDTO(string numero, decimal preco, Classe classe);