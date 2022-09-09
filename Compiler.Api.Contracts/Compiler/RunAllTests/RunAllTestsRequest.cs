namespace Compiler.Api.Contracts.Compiler.RunAllTests;

public record RunAllTestsRequest(
    string? MainClassText,
    string? TestClassText);