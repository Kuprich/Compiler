using ErrorOr;
using MediatR;

namespace Compiler.Application.Features.Compiler.RunAllTests;

public class RunAllTestsCommand : IRequest<ErrorOr<CompiledInformationDto>>
{
    public string? MainClassText { get; set; }
    public string? TestClassText { get; set; }
}
