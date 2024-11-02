using Microsoft.EntityFrameworkCore;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Interface;
using ReservaPassagem.Infrastructure.Data.Context;

namespace ReservaPassagem.Infrastructure.Repository;

public class VooRepository : IVooRepository
{
    private readonly SistemaContextDb _context;

    public VooRepository(SistemaContextDb context)
    {
        _context = context;
    }
    
    public async Task<Voo> AddVoo(Voo entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<Voo> UpdateVoo(Voo entity)
    {
        entity.UpdateVoo();
        _context.Voos.Update(entity);
        await _context.SaveChangesAsync();
        
        return entity;
    }
    
    public async Task<Voo?> GetVooByNumber(string number)
    {
        var voo =  await _context.Voos.FirstOrDefaultAsync(x=>x.NumeroVoo == number );

        return voo;
    }

    public Task<Voo> GetAllVoo()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Voo>> GetVooByCityOrigin(string origin)
    {
        var voo = await _context.Voos.AsNoTracking().Where(x=>x.Origem.Cidade == origin).ToListAsync();
        return voo;
    }

    public async Task<List<Voo>> GetVooByCityDestination(string destination)
    {
        var voo = await _context.Voos.AsNoTracking().Where(x=>x.Destino.Cidade == destination).ToListAsync();
        return voo;
    }
}