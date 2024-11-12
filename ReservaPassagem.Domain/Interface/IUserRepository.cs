using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Domain.Interface;

public interface IUserRepository
{
    public Task<User> GetUserByEmail(string email);
    
    public Task<User> RegisterUser(User user);
}