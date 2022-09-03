using Compiler.Application.Practice.GetAllPracticeHeadings;
using Compiler.Application.Practice.GetPracticeCard;

namespace Compiler.Persistence;

public interface IPracticeRepository
{
    Task<List<PracticeHeadingDto>> GetAllPracticeHeadingsAsync();
    Task<PracticeCardDto?> GetPracticeCard(Guid practiceCardId);
}
