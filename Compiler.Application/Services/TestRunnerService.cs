using Compiler.Application.Compiler;
using Compiler.Application.IServices;
using NUnit.Framework;
using System.Reflection;

namespace Compiler.Application.Services;

public class TestRunnerService : ITestRunnerService
{
    public List<TestResult> RunAllTestsFromAssembly(Assembly assembly)
    {
        Type testClass = assembly
            .GetTypes()
            .First(type => type.GetCustomAttributes(typeof(TestFixtureAttribute)).Any());

        MethodInfo[] testMethodsInfo = testClass
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(method => method.GetCustomAttributes(typeof(TestAttribute)).Any())
            .ToArray();

        object? target = Activator.CreateInstance(testClass);

        List<TestResult> result = new();

        foreach (var methodInfo in testMethodsInfo)
        {
            if (methodInfo.DeclaringType != testClass)
                continue;

            Action testMethod = (Action)methodInfo.CreateDelegate(typeof(Action), target);

            var testResult = RunTest(testMethod);
            testResult.TestName = methodInfo.Name;

            result.Add(testResult);
        }

        return result;
    }

    public TestResult RunTest(Action testMethod)
    {
        try
        {
            testMethod();
            return new TestResult(
                isPassed: true);
        }
        catch (Exception ex)
        {
            return new TestResult(
                errorValue: ex.Message);
        }
    }


}
