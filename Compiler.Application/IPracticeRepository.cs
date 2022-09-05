using Compiler.Application.Features.Practice.GetAllPracticeHeadings;
using Compiler.Application.Features.Practice.GetPracticeCard;

namespace Compiler.Persistence;

public interface IPracticeRepository
{
    Task<List<PracticeHeadingDto>> GetAllPracticeHeadingsAsync();
    Task<PracticeCardDto?> GetPracticeCard(Guid practiceCardId);
}
