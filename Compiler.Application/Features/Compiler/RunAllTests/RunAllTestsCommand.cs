using Compiler.Shared.Wrapper;
using MediatR;

namespace Compiler.Application.Features.Compiler.RunAllTests;

public record RunAllTestsCommand(string? MainClassText, string? TestClassText)
    : IRequest<Result<CompiledInformationDto>>;