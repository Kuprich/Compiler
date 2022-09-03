﻿using Compiler.Application.Exceptions;
using Compiler.Application.Practice.GetAllPracticeHeadings;
using Compiler.Application.Practice.GetPracticeCard;
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
            Heading = practiceCard.Heading,
            ProjectData = practiceCard.ProjectData,
        };

        return result;
    }
}
