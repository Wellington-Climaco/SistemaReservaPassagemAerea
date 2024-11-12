using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservaPassagem.Domain.Entities;
using ReservaPassagem.Infrastructure.Extensions;

namespace ReservaPassagem.Infrastructure.Data.Mapping;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ConfigEntityBase();
        builder.ToTable("User");
        
        builder.OwnsOne(x => x.Senha)
            .Property(x => x.Hash)
            .IsRequired();
    }
}