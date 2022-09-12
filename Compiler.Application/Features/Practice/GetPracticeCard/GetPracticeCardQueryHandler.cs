using Compiler.Persistence;
using Compiler.Shared.Wrapper;
using MediatR;

namespace Compiler.Application.Features.Practice.GetPracticeCard;

public class GetPracticeCardQueryHandler : IRequestHandler<GetPracticeCardQuery, Result<PracticeCardDto>>
{
    private readonly IPracticeRepository _practiceRepository;

    public GetPracticeCardQueryHandler(IPracticeRepository practiceRepository)
    {
        _practiceRepository = practiceRepository;
    }

    public async Task<Result<PracticeCardDto>> Handle(GetPracticeCardQuery request, CancellationToken cancellationToken)
    {
        PracticeCardDto? practiceCard = await _practiceRepository.GetPracticeCard(request.Id);

        if (practiceCard == null)
        {
            return await Result<PracticeCardDto>.FailAsync("Practicee card with current id not found");
        }

        return await Result<PracticeCardDto>.SucceessAsync(practiceCard);
    }
}
