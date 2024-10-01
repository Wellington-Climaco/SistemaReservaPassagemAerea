using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaPassagem.Domain.Entities.Base;

namespace ReservaPassagem.Infrastructure.Extensions;

public static class EntityTypeBuilderExtension
{
    public static void ConfigEntityBase<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : EntityBase
    {
        builder.HasKey(x => x.Id);

        builder.Property(entity => entity.Id)
            .IsRequired()
            .ValueGeneratedNever();
    }
}