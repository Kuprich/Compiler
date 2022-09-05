using MediatR;

namespace Compiler.Application.Features.Compiler.RunAllTests;

public class RunAllTestsCommand : IRequest<CompiledInformationResponse>
{
    public string? MainClassText { get; set; }
    public string? TestClassText { get; set; }
}
