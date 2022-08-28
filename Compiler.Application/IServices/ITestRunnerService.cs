using Compiler.Application.Compiler;
using System.Reflection;

namespace Compiler.Application.IServices;

public interface ITestRunnerService
{
    List<TestResult> RunAllTestsFromAssembly(Assembly assembly);
    TestResult RunTest(Action testMethod);
}
