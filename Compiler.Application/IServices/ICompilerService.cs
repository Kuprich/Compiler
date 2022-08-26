using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace Compiler.Application.IServices;

public interface ICompilerService
{
    Assembly? Assembly { get; }
    List<Diagnostic> CompileSourceCode(CSharpCompilation compilation);
    CSharpCompilation CreateCompilationObject(string[] textFiles);
}
