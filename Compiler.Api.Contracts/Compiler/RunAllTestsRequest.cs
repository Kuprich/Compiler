namespace Compiler.Api.Contracts.Compiler;

public record RunAllTestsRequest(
    string? MainClassText,
    string? TestClassText);