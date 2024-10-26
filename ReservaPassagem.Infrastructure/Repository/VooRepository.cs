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

    public Task<Voo> DisableVoo(Guid id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<Voo> ActiveVoo(Guid id)
    {
        var voo = await _context.Voos.FirstOrDefaultAsync(x => x.Id == id);
        
        if (voo != null)
            voo.AtivarVoo();

        await _context.SaveChangesAsync();
        
        return voo;
    }

    public async Task<Voo?> GetVooByNumber(string number)
    {
        var voo =  _context.Voos.AsNoTracking().FirstOrDefault(x=>x.NumeroVoo == number);

        return voo;
    }

    public Task<Voo> GetAllVoo()
    {
        throw new NotImplementedException();
    }

    public Task<Voo> GetVooByCityOrigin(string origin)
    {
        throw new NotImplementedException();
    }

    public Task<Voo> GetVooByCityDestination(string destination)
    {
        throw new NotImplementedException();
    }
}