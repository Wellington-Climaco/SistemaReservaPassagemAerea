using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ReservaPassagem.Application.Interface;
using ReservaPassagem.Application.Services;
using ReservaPassagem.Application.Validators;

namespace ReservaPassagem.Application.DependencyInjection;

public static class ConfigApplication
{
    public static IServiceCollection AddConfigServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<VooRequestValidator>();
        services.AddScoped<IVooService, VooService>();
        return services;
    }
}