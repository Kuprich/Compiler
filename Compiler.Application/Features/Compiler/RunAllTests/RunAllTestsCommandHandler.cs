using Compiler.Application.Features.Compiler.RunAllTests;
using Compiler.Application.Services.Interfaces;
using ErrorOr;
using MediatR;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Compiler.Application.Compiler.RunTests;

public class RunAllTestsCommandHandler : IRequestHandler<RunAllTestsCommand, ErrorOr<CompiledInformationDto>>
{
    private readonly ICompilerService _compilerService;
    private readonly ITestRunnerService _testRunnerService;

    public RunAllTestsCommandHandler(ICompilerService compilerService, ITestRunnerService testRunnerService)
    {
        _compilerService = compilerService;
        _testRunnerService = testRunnerService;
    }
    public Task<ErrorOr<CompiledInformationDto>> Handle(RunAllTestsCommand request, CancellationToken cancellationToken)
    {
        CSharpCompilation compilation = _compilerService.CreateCompilationObject(new[] { request.MainClassText!, request.TestClassText! });

        List<string> compilationErrors = _compilerService.CompileSourceCode(compilation);

        ErrorOr<CompiledInformationDto> result = new CompiledInformationDto();

        if (compilationErrors.Any())
        {
            result.Value.Errors = compilationErrors;
            return Task.FromResult(result);
        }

        List<TestResult> testResult = _testRunnerService.RunAllTestsFromAssembly(_compilerService.Assembly!);

        result.Value.TestResult = testResult;

        return Task.FromResult(result);
    }
}
