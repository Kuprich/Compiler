namespace Compiler.Application.Features.Practice.GetAllPracticeHeadings;

public class PracticesDto
{
   public List<PracticeTitle>? Titles { get; set; }

}

public class PracticeTitle
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
}



