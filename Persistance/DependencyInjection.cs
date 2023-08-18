using Application.Abstractions.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext>(sp => 
        sp.GetRequiredService<ApplicationDbContext>());

        return services;

    }
}
