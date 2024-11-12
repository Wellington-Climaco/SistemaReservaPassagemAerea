using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReservaPassagem.Domain;
using ReservaPassagem.Domain.Entities;

namespace ReservaPassagem.Infrastructure.Data.Context;

public class SistemaContextDb : DbContext
{
    public SistemaContextDb(DbContextOptions<SistemaContextDb> options) : base(options)
    {
        
    }

    public DbSet<Voo> Voos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Passageiro> Passageiros { get; set; }
    public DbSet<Assento> Assentos { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}