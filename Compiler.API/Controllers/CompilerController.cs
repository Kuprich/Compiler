using Compiler.API.Models;
using Compiler.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using NUnit.Engine;
using NUnit.Framework;
using NUnitLite;
using System.Reflection;

namespace Compiler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompilerController : ControllerBase
{

    [HttpGet("[action]")]
    public IActionResult RunTests()
    {
        
        CSharpCompilation compilation = CompilerService.CreateCompilationObject(new []{ Constants.MainClassText, Constants.TestClassText });

        List<Diagnostic> CompilationResult = CompilerService.CompileSourceCode(compilation);

        List<string> result = CompilationResult.Select(d => d.ToString()).ToList();


        return Ok(result);

    }
}
