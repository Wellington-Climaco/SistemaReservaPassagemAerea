using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaPassagem.Infrastructure.Data.Context;

namespace ReservaPassagem.Infrastructure;

public static class ConfigInfra
{
    public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<SistemaContextDb>(x => x.UseSqlServer(connectionString));
    }
}