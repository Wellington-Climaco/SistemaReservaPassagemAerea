using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReservaPassagem.Domain.Interface;
using ReservaPassagem.Infrastructure.Data.Context;
using ReservaPassagem.Infrastructure.Repository;

namespace ReservaPassagem.Infrastructure;

public static class ConfigInfra
{
    public static void ConfigInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddInfraestructure(services,configuration);
        ConfigServices(services);
    }
    public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<SistemaContextDb>(x => x.UseSqlServer(connectionString));
    }
    
    public static void ConfigServices(this IServiceCollection services)
    {
        services.AddScoped<IVooRepository, VooRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}