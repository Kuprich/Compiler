using Compiler.Application.Practice.GetAllPracticeHeadings;

namespace Compiler.Persistence;

public interface IPracticeRepository
{
    Task<List<PracticeHeadingDto>> GetAllPracticeHeadingsAsync();
}
