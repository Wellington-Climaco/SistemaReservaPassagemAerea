using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Domain.Enum;
using ReservaPassagem.Infrastructure.Extensions;

namespace ReservaPassagem.Infrastructure.Data.Mapping;

public class ReservaMap : IEntityTypeConfiguration<Reserva>
{
    public void Configure(EntityTypeBuilder<Reserva> builder)
    {
        builder.ConfigEntityBase();

        builder.Property(r => r.StatusReserva)
            .IsRequired()
            .HasConversion(
                r => r.ToString(),
                r => (StatusReserva)Enum.Parse(typeof(StatusReserva), r))
            .HasMaxLength(30);

        builder.HasOne(r => r.Passageiro)
            .WithMany(r => r.Reservas)
            .HasForeignKey(r => r.PassageiroId)
            .IsRequired();

        builder.HasOne(r => r.Voo)
            .WithMany(r => r.Reservas)
            .HasForeignKey(r => r.VooId)
            .IsRequired();

        builder.HasMany(r => r.Assentos)
            .WithOne(r => r.Reserva)
            .IsRequired();
    }
}