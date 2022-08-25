using System.Reflection;

namespace Compiler.API.Services.Interfaces;

public interface ITestRunnerService
{
    List<string> RunAllTestsFromAssembly(Assembly assembly);
    bool RunTest(Action testMethod);
}
