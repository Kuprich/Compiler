using Compiler.Application.Features.Practice.GetAllPracticeHeadings;
using Compiler.Application.Features.Practice.GetPracticeCard;
using Compiler.Domain.Entities;
using Compiler.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Compiler.Infrastructure;

public class PracticeRepository : IPracticeRepository
{
    private readonly PracticeDbContext _practiceDbContext;

    public PracticeRepository(PracticeDbContext practiceDbContext)
    {
        _practiceDbContext = practiceDbContext;
    }

    public async Task<PracticesDto> GetAllPracticesAsync()
    {
        List<PracticeTitle> titles = await _practiceDbContext.PracticeCards
            .Select(practiceCard => new PracticeTitle
            {
                Id = practiceCard.Id,
                Title = practiceCard.Title,
            })
            .ToListAsync();

        return new PracticesDto
        {
            Titles = titles
        };
    }


    public async Task<PracticeCardDto?> GetPracticeCard(Guid practiceCardId)
    {
        PracticeCard? practiceCard = await _practiceDbContext
            .PracticeCards
            .FirstOrDefaultAsync(practiceCard => practiceCard.Id == practiceCardId);

        if (practiceCard == null) return null;

        PracticeCardDto result = new()
        {
            Id = practiceCard.Id,
            Description = practiceCard.Description,
            Heading = practiceCard.Title,
            ProjectData = practiceCard.ProjectData,
        };

        return result;
    }
}
