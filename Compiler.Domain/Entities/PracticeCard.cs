using Compiler.Domain.Entities.ValueObjects;

namespace Compiler.Domain.Entities;

public class PracticeCard : EntityBase
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ProjectData? ProjectData { get; set; }
}



