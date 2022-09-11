using Compiler.Domain.Entities.ValueObjects;

namespace Compiler.Application.Features.Practice.GetPracticeCard;

public class PracticeCardDto
{
    public Guid Id { get; set; }
    public string? Heading { get; set; }
    public string? Description { get; set; }
    public ProjectData? ProjectData { get; set; }
}
