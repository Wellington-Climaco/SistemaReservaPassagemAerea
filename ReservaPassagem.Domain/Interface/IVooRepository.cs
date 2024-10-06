using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Domain.Interface;

public interface IVooRepository
{
    Task AddVoo(Voo entity);
    Task<Voo> DisableVoo(Guid id);
    Task<Voo> ActiveVoo(Guid id);
    Task<Voo> GetVooById(Guid id);
    Task<Voo> GetAllVoo();
    Task<Voo> GetVooByCityOrigin(string origin);
    Task<Voo> GetVooByCityDestination(string destination);
}