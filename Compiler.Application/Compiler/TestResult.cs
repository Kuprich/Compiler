namespace Compiler.Application.Compiler;

public struct TestResult
{
    public string? TestName { get; set; } = null!;
    public bool IsPassed { get; set; } = false;
    public string ErrorValue { get; set; } = null!;

    public TestResult(bool isPassed)
    {
        IsPassed = isPassed;
    }

    public TestResult(string errorValue)
    {
        IsPassed = false;
        ErrorValue = errorValue;
    }
}
