using Compiler.Application.Features.Compiler.RunAllTests;
using Compiler.Application.Services.Interfaces;
using Compiler.Shared.Wrapper;
using MediatR;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Compiler.Application.Compiler.RunTests;

public class RunAllTestsCommandHandler : IRequestHandler<RunAllTestsCommand, Result<CompiledInformationDto>>
{
    private readonly ICompilerService _compilerService;
    private readonly ITestRunnerService _testRunnerService;

    public RunAllTestsCommandHandler(ICompilerService compilerService, ITestRunnerService testRunnerService)
    {
        _compilerService = compilerService;
        _testRunnerService = testRunnerService;
    }
    public async Task<Result<CompiledInformationDto>> Handle(RunAllTestsCommand command, CancellationToken cancellationToken)
    {
        CSharpCompilation compilation = _compilerService.CreateCompilationObject(new[] { command.MainClassText!, command.TestClassText! });

        List<string> compilationErrors = _compilerService.CompileSourceCode(compilation);

        CompiledInformationDto dto = new();

        if (compilationErrors.Any())
        {
            dto.Errors = compilationErrors;
            return await Result<CompiledInformationDto>.SucceessAsync(dto);
        }

        List<TestResult> testResult = _testRunnerService.RunAllTestsFromAssembly(_compilerService.Assembly!);

        dto.TestResult = testResult;

        return await Result<CompiledInformationDto>.SucceessAsync(dto);
    }
}
