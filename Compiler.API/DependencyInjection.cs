using Compiler.API.Services;
using Compiler.API.Services.Interfaces;

namespace Compiler.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddTransient<ICompilerService, CompilerService>();
        services.AddTransient<ITestRunnerService, TestRunnerService>();

        return services;
    }
}
