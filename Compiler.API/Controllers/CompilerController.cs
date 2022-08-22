using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Emit;

namespace Compiler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompilerController : ControllerBase
{
    const string classText = @"
        using System;

        public class Writer
        {
            public void Write(string message
            {
                Console.WriteLine(message);
            }
        }";

    [HttpGet]
    public IActionResult DiagnosticMethod()
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(classText);
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

    public IActionResult
}
