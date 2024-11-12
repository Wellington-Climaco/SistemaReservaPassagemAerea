using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }

    public static IServiceCollection ConfigAuthentication(this IServiceCollection services)
    {
        AuthenticationBuilder authenticationBuilder = services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });
        
        return services;
    }

    private static void ConfigureJwtBearer(this AuthenticationBuilder authenticationBuilder,IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration.GetSection("Secret").ToString() ?? string.Empty);
        authenticationBuilder.AddJwtBearer(x =>
        {
            authenticationBuilder.AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        });
    }
}