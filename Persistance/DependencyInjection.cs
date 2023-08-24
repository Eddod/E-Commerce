using Application.Abstractions.Data;
using Application.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext>(sp => 
        sp.GetRequiredService<ApplicationDbContext>());

        services.AddTransient<IPasswordService, PasswordService>();
        return services;

    }
}
