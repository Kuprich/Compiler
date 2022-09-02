using Compiler.Application.Practice.GetAllPracticeHeadings;
using Compiler.Persistence;
using MediatR;

namespace Compiler.Application.Practice.GetAllPractices;

public class GetAllPracticeHeadingsQueryHandler : IRequestHandler<GetAllPracticeHeadingsQuery, List<PracticeHeadingDto>>
{
    private readonly IPracticeRepository _practiceRepository;

    public GetAllPracticeHeadingsQueryHandler(IPracticeRepository practiceRepository)
    {
        _practiceRepository = practiceRepository;
    }
    public async Task<List<PracticeHeadingDto>> Handle(GetAllPracticeHeadingsQuery request, CancellationToken cancellationToken)
    {
        return await _practiceRepository.GetAllPracticeHeadingsAsync();
    }
}
