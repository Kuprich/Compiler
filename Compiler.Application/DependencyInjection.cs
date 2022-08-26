using Compiler.Application.IServices;
using Compiler.Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Compiler.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ICompilerService, CompilerService>();
        services.AddTransient<ITestRunnerService, TestRunnerService>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}
