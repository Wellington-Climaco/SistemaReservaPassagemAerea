using ReservaPassagem.Application.Request;

namespace ReservaPassagem.Application.Interface;

public interface IVooService
{
    void AddVoo(VooRequest request);
}