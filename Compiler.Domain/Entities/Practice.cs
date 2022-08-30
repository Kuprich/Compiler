using Compiler.Domain.Entities.ValueObjects;

namespace Compiler.Domain.Entities;

public class Practice : EntityBase
{
    public string Heading { get; set; }
    public string Description { get; set; }
    public ProjectData ProjectData { get; set; }
}



