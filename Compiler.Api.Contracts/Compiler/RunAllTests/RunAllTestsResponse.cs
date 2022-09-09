namespace Compiler.Api.Contracts.Compiler.RunAllTests;

public record RunAllTestsResponse(
    List<string>? Errors,
    List<TestResult>? TestResult);

public record TestResult(string? TestName, bool IsPassed, string ErrorValue);
