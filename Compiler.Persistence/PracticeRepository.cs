using Compiler.Application.Practice.GetAllPracticeHeadings;
using Microsoft.EntityFrameworkCore;

namespace Compiler.Persistence;

public class PracticeRepository : IPracticeRepository
{
    private readonly PracticeDbContext _practiceDbContext;

    public PracticeRepository(PracticeDbContext practiceDbContext)
    {
        _practiceDbContext = practiceDbContext;
    }

    public async Task<List<PracticeHeadingDto>> GetAllPracticeHeadingsAsync()
    {
        return await _practiceDbContext.PracticeCards
            .Select(practiceCard => new PracticeHeadingDto 
            {
                Id = practiceCard.Id, 
                Heading = practiceCard.Heading 
            })
            .ToListAsync();
    }
}
