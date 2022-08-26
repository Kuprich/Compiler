using Compiler.Application.IServices;
using NUnit.Framework;
using System.Reflection;

namespace Compiler.Application.Services;

public class TestRunnerService : ITestRunnerService
{
    public List<string> RunAllTestsFromAssembly(Assembly assembly)
    {
        Type testClass = assembly
            .GetTypes()
            .First(type => type.GetCustomAttributes(typeof(TestFixtureAttribute)).Any());

        MethodInfo[] testMethodsInfo = testClass
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(method => method.GetCustomAttributes(typeof(TestAttribute)).Any())
            .ToArray();

        object? target = Activator.CreateInstance(testClass);

        List<string> result = new();

        foreach (var methodInfo in testMethodsInfo)
        {
            if (methodInfo.DeclaringType != testClass)
                continue;

            Action testMethod = (Action)methodInfo.CreateDelegate(typeof(Action), target);

            bool testResult = RunTest(testMethod);

            result.Add(testResult ? $"{methodInfo.Name} - Passed" : $"{methodInfo.Name} - failed");
        }

        return result;
    }

    public bool RunTest(Action testMethod)
    {
        try
        {
            testMethod();
            return true;

        }
        catch (Exception)
        {
            return false;
        }
    }
}
