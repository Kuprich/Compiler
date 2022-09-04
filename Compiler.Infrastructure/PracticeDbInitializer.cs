using Compiler.Domain.Entities;
using Compiler.Domain.Entities.ValueObjects;

namespace Compiler.Infrastructure;

public class PracticeDbInitializer
{

    private static List<PracticeCard> GetSomePractices() =>
        Enumerable.Range(0, 5)
            .Select(i => new PracticeCard
            {
                Heading = $"Practice card Heading ({i})",
                Description = $"Practice card Description ({i})",
                ProjectData = new ProjectData()
                {
                    MainClassText = $"Some main class text{i}",
                    TestClassText = $"Some test class text{i}",
                }
            })
            .ToList();



    public static async Task InitializeAsync(PracticeDbContext dbContext)
    {
        await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();

        await dbContext.PracticeCards.AddRangeAsync(GetSomePractices());

        await dbContext.SaveChangesAsync();
    }
}
