namespace Compiler.Application.Compiler.RunTests;

public class CompiledInformationDto
{
    public List<string>? Errors { get; set; }
    public List<TestResult>? TestResult { get; set; }
}
