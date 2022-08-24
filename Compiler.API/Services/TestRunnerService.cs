using Compiler.API.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Reflection;

namespace Compiler.API.Services;

public class TestRunnerService
{
    public static void RunAllTestsFromAssembly(Assembly assembly)
    {

        Type testClass = assembly
            .GetTypes()
            .First(type => type.GetCustomAttributes(typeof(TestFixture)).Any());

        //Type? testClass = assembly.GetType(Constants.TestClassName);
        //testClass.GetCustomAttributes(typeof(TestAttribute)).Any()

        MethodInfo[] testMethodsInfo = testClass
            .GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(method => method.GetCustomAttributes(typeof(Test)).Any())
            .ToArray();

        object? target = Activator.CreateInstance(testClass);

        foreach (var methodInfo in testMethodsInfo)
        {
            if (methodInfo.DeclaringType != testClass)
                continue;

        }
    }
}
