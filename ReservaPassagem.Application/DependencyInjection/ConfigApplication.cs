using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ReservaPassagem.Application.Validators;

namespace ReservaPassagem.Application.DependencyInjection;

public static class ConfigApplication
{
    public static IServiceCollection AddConfigServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<VooRequestValidator>();
        
        return services;
    }
}