using Compiler.Application.Features.Practice.GetAllPracticeHeadings;
using Compiler.Application.Features.Practice.GetPracticeCard;

namespace Compiler.Persistence;

public interface IPracticeRepository
{
    Task<PracticeHeadingsDto> GetPracticeHeadingsAsync();
    Task<PracticeCardDto?> GetPracticeCard(Guid practiceCardId);
}
