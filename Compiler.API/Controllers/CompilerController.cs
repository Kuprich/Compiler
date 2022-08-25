using Compiler.API.Models;
using Compiler.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Compiler.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompilerController : ControllerBase
{
    private readonly ICompilerService _compilerService;
    private readonly ITestRunnerService _testRunnerService;

    public CompilerController(ICompilerService compilerService, ITestRunnerService testRunnerService)
    {
        _compilerService = compilerService;
        _testRunnerService = testRunnerService;
    }

    [HttpGet("[action]")]
    public IActionResult RunTests()
    {

        CSharpCompilation compilation = _compilerService.CreateCompilationObject(new[] { Constants.MainClassText, Constants.TestClassText });

        List<Diagnostic> CompilationResult = _compilerService.CompileSourceCode(compilation);

        List<string> compilationResult = CompilationResult.Select(d => d.ToString()).ToList();

        if (compilationResult.Any())
            return Ok(compilationResult);

        List<string> testResult = _testRunnerService.RunAllTestsFromAssembly(_compilerService.Assembly!);

        return Ok(testResult);

    }
}
