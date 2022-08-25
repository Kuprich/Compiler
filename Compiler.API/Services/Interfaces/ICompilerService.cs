using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace Compiler.API.Services.Interfaces;

public interface ICompilerService
{
    Assembly? Assembly { get; }
    List<Diagnostic> CompileSourceCode(CSharpCompilation compilation);
    CSharpCompilation CreateCompilationObject(string[] textFiles);
}
