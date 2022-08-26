using System.Reflection;

namespace Compiler.Application.IServices;

public interface ITestRunnerService
{
    List<string> RunAllTestsFromAssembly(Assembly assembly);
    bool RunTest(Action testMethod);
}
