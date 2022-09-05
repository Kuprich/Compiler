using MediatR;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Compiler.Application.IServices;
using Compiler.Application.Features.Compiler.RunAllTests;

namespace Compiler.Application.Compiler.RunTests;

public class RunAllTestsCommandHandler : IRequestHandler<RunAllTestsCommand, CompiledInformationResponse>
{
    private readonly ICompilerService _compilerService;
    private readonly ITestRunnerService _testRunnerService;

    public RunAllTestsCommandHandler(ICompilerService compilerService, ITestRunnerService testRunnerService)
    {
        _compilerService = compilerService;
        _testRunnerService = testRunnerService;
    }
    public Task<CompiledInformationResponse> Handle(RunAllTestsCommand request, CancellationToken cancellationToken)
    {
        CSharpCompilation compilation = _compilerService.CreateCompilationObject(new[] { request.MainClassText!, request.TestClassText! });

        List<Diagnostic> CompilationResult = _compilerService.CompileSourceCode(compilation);

        List<string> compilationResult = CompilationResult.Select(d => d.ToString()).ToList();

        if (compilationResult.Any())
            return Task.FromResult(new CompiledInformationResponse
            {
                Errors = compilationResult,
            });

        List<TestResult> testResult = _testRunnerService.RunAllTestsFromAssembly(_compilerService.Assembly!);

        return Task.FromResult(new CompiledInformationResponse
        {
            Errors = new List<string>(),
            TestResult = testResult
        });
    }
}
