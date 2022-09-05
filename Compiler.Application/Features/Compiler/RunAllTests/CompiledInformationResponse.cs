namespace Compiler.Application.Features.Compiler.RunAllTests;

public class CompiledInformationResponse
{
    public List<string>? Errors { get; set; }
    public List<TestResult>? TestResult { get; set; }
}
