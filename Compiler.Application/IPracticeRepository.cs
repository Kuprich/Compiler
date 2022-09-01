using Compiler.Domain.Entities;

namespace Compiler.Persistence;

public interface IPracticeRepository
{
    Task<List<PracticeCard>> GetAllPracticeCardsAsync();
}
