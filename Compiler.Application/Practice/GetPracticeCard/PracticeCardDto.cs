using Compiler.Application.Exceptions;
using Compiler.Domain.Entities.ValueObjects;
using Compiler.Persistence;
using MediatR;

namespace Compiler.Application.Practice.GetPracticeCard;

public class PracticeCardDto
{
    public Guid Id { get; set; }
    public string? Heading { get; set; }
    public string? Description { get; set; }
    public ProjectData? ProjectData { get; set; }
}

public class GetPracticeCardQuery : IRequest<PracticeCardDto>
{
    public Guid Id { get; set; }
}

public class GetPracticeCardQueryHandler : IRequestHandler<GetPracticeCardQuery, PracticeCardDto>
{
    private readonly IPracticeRepository _practiceRepository;

    public GetPracticeCardQueryHandler(IPracticeRepository practiceRepository)
    {
        _practiceRepository = practiceRepository;
    }

    //TODO: подумать над обработкой исключений, возникающих при получении карточки с заданием. 
    public async Task<PracticeCardDto> Handle(GetPracticeCardQuery request, CancellationToken cancellationToken)
    {
        PracticeCardDto? result = await _practiceRepository.GetPracticeCard(request.Id);

        if (result == null)
            throw new EntityNotFoundException("Practice card with current Id not found");

        return result;
    }
}
