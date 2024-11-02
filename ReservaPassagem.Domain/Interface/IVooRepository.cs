using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Domain.Interface;

public interface IVooRepository
{
    Task<Voo> AddVoo(Voo entity);
    Task<Voo> UpdateVoo(Voo entity);
    Task<Voo?> GetVooByNumber(string number);
    Task<Voo> GetAllVoo();
    Task<List<Voo>> GetVooByCityOrigin(string origin);
    Task<List<Voo>> GetVooByCityDestination(string destination);
}