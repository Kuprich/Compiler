using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using NUnit.Framework;
using System.Linq.Expressions;
using System.Reflection;
using UnitTestRunner;

const string classText = @"
    using System;

    public class Writer
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }";

SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(classText);

//SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"
//    using System;
//    using NUnit.Framework;

//    namespace RoslynCompileSample
//    {
//        public class Writer
//        {
//            public void Write(string message)
//            {
//                Console.WriteLine(message);
//            }
//        }
//        public class Tests
//        {
//            [SetUp]
//            public void Setup()
//            {
//            }

//            [Test]
//            public void Test1()
//            {
//                Assert.IsTrue(1 == 3);
//            }
//        }
//        }");

string assemblyName = Path.GetRandomFileName();


MetadataReference[] references = AppDomain.CurrentDomain.GetAssemblies()
        .Where(asm => !asm.IsDynamic && !string.IsNullOrWhiteSpace(asm.Location))
        .Select(asm => MetadataReference.CreateFromFile(asm.Location))
        .Concat(new[]
        {
            // add your app/lib specifics, e.g.:                      
            MetadataReference.CreateFromFile(typeof(NUnitAttribute).Assembly.Location),
        })
        .ToArray();


CSharpCompilation compilation = CSharpCompilation.Create(
    assemblyName,
    syntaxTrees: new[] { syntaxTree },
    references: references,
    options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

using (var ms = new MemoryStream())
{
    EmitResult result = compilation.Emit(ms);

    if (!result.Success)
    {
        IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
        diagnostic.IsWarningAsError ||
        diagnostic.Severity == DiagnosticSeverity.Error);

        foreach (Diagnostic diagnostic in failures)
        {
            Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
        }
    }
    else
    {

        ms.Seek(0, SeekOrigin.Begin);
        Assembly assembly = Assembly.Load(ms.ToArray());

        Type? testClass = assembly.GetType("Writer");

        if (testClass != null)
        {
            object? obj = Activator.CreateInstance(testClass);

            //MethodInfo? mInfo = testClass.GetMethod("Write");

            testClass.InvokeMember(
                "Write",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                obj, 
                args: new object[] {"Hello Wrold"});

            //TestRunner runner = new TestRunner();

            ////Type delegateType;

            //var typeArgs = mInfo!
            //   .GetParameters()
            //   .Select(p => p.ParameterType)
            //   .ToList();

            //if (mInfo.ReturnType == typeof(void))
            //{
            //    delegateType = Expression.GetActionType(typeArgs.ToArray());
            //}
            //else
            //{
            //    typeArgs.Add(mInfo.ReturnType);
            //    delegateType = Expression.GetFuncType(typeArgs.ToArray());
            //}

            //    var d = Delegate.CreateDelegate(typeof(Action), null, mInfo);

            //Action action = (Action)d;

            //runner.RunTestClass(obj?.GetType());

            //return;

            //type.InvokeMember(
            //    "Test1",
            //    BindingFlags.Default | BindingFlags.InvokeMethod,
            //    null,
            //    obj, args: Array.Empty<object>());
        }

    }
}

