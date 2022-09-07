using Compiler.Application.Services.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using NUnit.Framework;
using System.Reflection;

namespace Compiler.Application.Services;

public class CompilerService : ICompilerService
{
    public Assembly? Assembly { get; private set; }

    public CSharpCompilation CreateCompilationObject(string[] textFiles)
    {
        SyntaxTree[] syntaxTrees = textFiles.Select(file => CSharpSyntaxTree.ParseText(file)).ToArray();

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
            assemblyName: assemblyName,
            syntaxTrees: syntaxTrees,
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        return compilation;
    }

    public List<string> CompileSourceCode(CSharpCompilation compilation)
    {
        List<string> result = new();

        using (var memoryStream = new MemoryStream())
        {
            EmitResult emitResult = compilation.Emit(memoryStream);

            if (!emitResult.Success)
            {
                IEnumerable<Diagnostic> failures = emitResult.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError ||
                diagnostic.Severity == DiagnosticSeverity.Error);

                result.AddRange(failures.Select(failure => failure.ToString()).ToList());
            }

            else
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                Assembly = Assembly.Load(memoryStream.ToArray());
            }

        }

        return result;

    }
}
