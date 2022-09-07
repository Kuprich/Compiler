using Compiler.Client.Infrastructure.Managers.CompilerManager;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.Client.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddClientInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<CompilerManager>();
        return services;
    }
}
