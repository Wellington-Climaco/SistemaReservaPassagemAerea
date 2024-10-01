using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaPassagem.Domain;
using ReservaPassagem.Infrastructure.Extensions;

namespace ReservaPassagem.Infrastructure.Data.Mapping;

public class PassageiroMap : IEntityTypeConfiguration<Passageiro>
{
    public void Configure(EntityTypeBuilder<Passageiro> builder)
    {
        builder.ConfigEntityBase();
        
        builder.ToTable("Passageiro");

        builder.OwnsOne(passageiro => passageiro.Nome)
            .Property(x=>x.PrimeiroNome)
            .IsRequired()
            .HasColumnName("Primeiro Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
        
        builder.OwnsOne(passageiro => passageiro.Nome)
            .Property(x=>x.UltimoNome)
            .IsRequired()
            .HasColumnName("Ultimo Nome")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50);
        
        builder.Property(passageiro => passageiro.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);
        
        builder.Property(passageiro => passageiro.Telefone)
            .IsRequired()
            .HasColumnName("Telefone")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(20);

        builder.HasMany(passageiro => passageiro.Reservas)
            .WithOne(x => x.Passageiro)
            .HasForeignKey(x => x.PassageiroId)
            .IsRequired();
    }
}