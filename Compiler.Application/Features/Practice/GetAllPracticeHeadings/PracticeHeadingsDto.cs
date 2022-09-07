namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public class PracticeHeadingsDto
{
   public List<PracticeHeading>? Headings { get; set; }

    public class PracticeHeading
    {
        public Guid Id { get; set; }
        public string? Heading { get; set; }
    }
}



