using Compiler.Shared.Wrapper;
using MediatR;

namespace Compiler.Application.Features.Practice.GetPracticeCard;

public class GetPracticeCardQuery : IRequest<Result<PracticeCardDto>>
{
    public Guid Id { get; set; }
}
