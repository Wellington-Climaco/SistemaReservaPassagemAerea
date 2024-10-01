using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Enum;
using ReservaPassagem.Infrastructure.Extensions;

namespace ReservaPassagem.Infrastructure.Data.Mapping;

public class AssentoMap : IEntityTypeConfiguration<Assento>
{
    public void Configure(EntityTypeBuilder<Assento> builder)
    {
        builder.ConfigEntityBase();
        
        builder.Property(a => a.Numero)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(a => a.Preco)
            .IsRequired();

        builder.Property(a => a.Classe)
            .HasConversion(
                a => a.ToString(), 
                a => (Classe)Enum.Parse(typeof(Classe),a))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(a => a.Disponivel)
            .HasConversion(
                a => a ? "true" : "false",
                a => a == "true"
            )
            .IsRequired();
        
        builder.HasOne(a => a.Voo)
            .WithMany(v => v.Assentos)
            .HasForeignKey(a => a.VooId);
    }
}