using Compiler.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compiler.Persistence;

public class PracticeRepository : IPracticeRepository
{
    private readonly PracticeDbContext _practiceDbContext;

    public PracticeRepository(PracticeDbContext practiceDbContext)
    {
        _practiceDbContext = practiceDbContext;
    }

    public async Task<List<PracticeCard>> GetAllPracticeCardsAsync()
    {
        return await _practiceDbContext.PracticeCards.ToListAsync();
    }
}
