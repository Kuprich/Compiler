using Compiler.Shared.Wrapper;
using MediatR;

namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public record GetAllPracticesQuery : IRequest<Result<PracticesDto>>;
