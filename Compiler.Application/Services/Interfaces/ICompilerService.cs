using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;

namespace Compiler.Application.Services.Interfaces;

public interface ICompilerService
{
    Assembly? Assembly { get; }
    List<string> CompileSourceCode(CSharpCompilation compilation);
    CSharpCompilation CreateCompilationObject(string[] textFiles);
}
