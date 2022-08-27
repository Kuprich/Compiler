using MediatR;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using Compiler.Application.IServices;

namespace Compiler.Application.Compiler.RunTests;

public class RunTestCommandHandler : IRequestHandler<RunTestCommand, CompiledInformationDto>
{
    private readonly ICompilerService _compilerService;
    private readonly ITestRunnerService _testRunnerService;

    public RunTestCommandHandler(ICompilerService compilerService, ITestRunnerService testRunnerService)
    {
        _compilerService = compilerService;
        _testRunnerService = testRunnerService;
    }
    public Task<CompiledInformationDto> Handle(RunTestCommand request, CancellationToken cancellationToken)
    {
        CSharpCompilation compilation = _compilerService.CreateCompilationObject(new[] { request.MainClassText!, request.TestClassText! });

        List<Diagnostic> CompilationResult = _compilerService.CompileSourceCode(compilation);

        List<string> compilationResult = CompilationResult.Select(d => d.ToString()).ToList();

        if (compilationResult.Any())
            return Task.FromResult(new CompiledInformationDto
            {
                Errors = compilationResult,
            });

        List<string> testResult = _testRunnerService.RunAllTestsFromAssembly(_compilerService.Assembly!);

        return Task.FromResult(new CompiledInformationDto
        {
            Errors = { },
            TestResult = testResult
        });
    }
}
