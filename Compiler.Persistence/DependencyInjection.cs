using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqliteDb");
        services.AddDbContext<PracticeDbContext>(opt =>
        {
            opt.UseSqlite(connectionString);
        });

        services.AddScoped<IPracticeRepository, PracticeRepository>();

        return services;
    }
}
