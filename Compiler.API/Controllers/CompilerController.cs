using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Emit;
using NUnit.Framework;

namespace Compiler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompilerController : ControllerBase
{
    const string MainClassText = @"
        using System;

        public class NumberGenerator
        {
            public int GenerateNum(
            {
                return 1
            }
        }";

    const string TestClassText = @"
        using System;
        using NUnit.Framework;

        public class Tests
        {
            [SetUp]
            public void Setup()
            { }

            [Test]
            public void Test1()
            {
                NumberGenerator generator = new ();
                Assert.IsTrue(2 == generator.GenerateNum());
            }
        }";


    [HttpGet("[action]")]
    public IActionResult DiagnosticMethod()
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(MainClassText);
        string assemblyName = Path.GetRandomFileName();

        MetadataReference[] references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(asm => !asm.IsDynamic && !string.IsNullOrWhiteSpace(asm.Location))
                .Select(asm => MetadataReference.CreateFromFile(asm.Location))
                .ToArray();

        CSharpCompilation compilation = CSharpCompilation.Create(
            assemblyName,
            syntaxTrees: new[] { syntaxTree },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        List<string> result = new();

        using (var memoryStream = new MemoryStream())
        {
            EmitResult emitResult = compilation.Emit(memoryStream);

            if (!emitResult.Success)
            {
                IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError ||
                diagnostic.Severity == DiagnosticSeverity.Error);

                result.AddRange(
                    failures.Select(
                        diagnostic => $"{diagnostic.Id}: {diagnostic.GetMessage()}"));
            }
        }

        return Ok(result);
    }

    [HttpGet("[action]")]
    public IActionResult RunTests()
    {
        SyntaxTree mainSyntaxTree = CSharpSyntaxTree.ParseText(MainClassText);
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(TestClassText);

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
            syntaxTrees: new[] { syntaxTree, mainSyntaxTree },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        List<string> result = new();

        using (var memoryStream = new MemoryStream())
        {
            EmitResult emitResult = compilation.Emit(memoryStream);

            if (!emitResult.Success)
            {
                IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError ||
                diagnostic.Severity == DiagnosticSeverity.Error);

                result.AddRange(failures.Select(x => x.ToString()));
            }
        }

        return Ok(result);
    }
}
