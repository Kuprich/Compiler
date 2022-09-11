using Compiler.Persistence;
using Compiler.Shared.Wrapper;
using MediatR;

namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public class GetAllPracticesQueryHandler : IRequestHandler<GetAllPracticesQuery, Result<PracticesDto>>
{
    private readonly IPracticeRepository _practiceRepository;

    public GetAllPracticesQueryHandler(IPracticeRepository practiceRepository)
    {
        _practiceRepository = practiceRepository;
    }

    public async Task<Result<PracticesDto>> Handle(GetAllPracticesQuery request, CancellationToken cancellationToken)
    {
        var result = await _practiceRepository.GetAllPracticesAsync();

        if (result == null)
        {
            return await Result<PracticesDto>.FailAsync("Practice cards not found");
        }

        return await Result<PracticesDto>.SucceessAsync(result);
    }
}
