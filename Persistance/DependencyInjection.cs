using Application.Abstractions.Data;
using Application.Abstractions.IServices;
using Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Service;

namespace Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext>(sp => 
        sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IJwtProviderService, JwtProviderService>();
        return services;

    }
}
