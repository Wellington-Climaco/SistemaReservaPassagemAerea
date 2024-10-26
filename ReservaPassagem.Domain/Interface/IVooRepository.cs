using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Domain.Interface;

public interface IVooRepository
{
    Task<Voo> AddVoo(Voo entity);
    Task<Voo> UpdateVoo(Voo entity);
    Task<Voo> DisableVoo(Guid id);
    Task<Voo> ActiveVoo(Guid id);
    Task<Voo?> GetVooByNumber(string number);
    Task<Voo> GetAllVoo();
    Task<Voo> GetVooByCityOrigin(string origin);
    Task<Voo> GetVooByCityDestination(string destination);
}