using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Infrastructure.Extensions;

namespace ReservaPassagem.Infrastructure.Data.Mapping;

public class VooMap : IEntityTypeConfiguration<Voo>
{
    public void Configure(EntityTypeBuilder<Voo> builder)
    {
        builder.ConfigEntityBase();
        
        builder.Property(v => v.NumeroVoo)
            .IsRequired()
            .HasMaxLength(10);

        builder.OwnsOne(v => v.Origem)
            .Property(v => v.Cidade)
            .IsRequired();
        
        builder.OwnsOne(v => v.Origem)
            .Property(v => v.Pais)
            .IsRequired();

        builder.OwnsOne(v => v.Destino)
            .Property(v => v.Pais)
            .IsRequired();

        builder.OwnsOne(v => v.Destino)
            .Property(v => v.Cidade)
            .IsRequired();

        builder.Property(v => v.HorasVoo)
            .IsRequired();
        
        builder.Property(v => v.CompanhiaAerea)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.HasMany(v => v.Assentos)
            .WithOne(a => a.Voo)
            .HasForeignKey(a => a.VooId);
        
        builder.HasMany(v => v.Reservas)
            .WithOne(r => r.Voo)
            .HasForeignKey(r => r.VooId);
    }
}