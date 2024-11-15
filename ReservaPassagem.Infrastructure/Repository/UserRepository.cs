using Microsoft.EntityFrameworkCore;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Interface;
using ReservaPassagem.Infrastructure.Data.Context;

namespace ReservaPassagem.Infrastructure.Repository;

public class UserRepository : IUserRepository
{
    private readonly SistemaContextDb _context;

    public UserRepository(SistemaContextDb context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserByEmail(string email)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        return result;
    }

    public async Task<User> RegisterUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }
}