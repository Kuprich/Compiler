using Compiler.Domain.Errors;
using Compiler.Persistence;
using ErrorOr;
using MediatR;

namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public class GetPracticeHeadingsQueryHandler : IRequestHandler<GetPracticeHeadingsQuery, ErrorOr<PracticeHeadingsDto>>
{
    private readonly IPracticeRepository _practiceRepository;

    public GetPracticeHeadingsQueryHandler(IPracticeRepository practiceRepository)
    {
        _practiceRepository = practiceRepository;
    }

    public async Task<ErrorOr<PracticeHeadingsDto>> Handle(GetPracticeHeadingsQuery request, CancellationToken cancellationToken)
    {
        var result = await _practiceRepository.GetPracticeHeadingsAsync();

        if (result == null)
        {
            ErrorOr<PracticeHeadingsDto> error = Errors.PracticeCard.NotFound;
            return error;
        }

        return result;
    }
}
