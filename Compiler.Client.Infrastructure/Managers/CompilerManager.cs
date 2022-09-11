using Compiler.Api.Contracts.Compiler;
using Compiler.Application.Features.Compiler.RunAllTests;
using Compiler.Shared.Wrapper;
using System.Net.Http.Json;

namespace Compiler.Client.Infrastructure.Managers;

public class CompilerManager
{
    private readonly HttpClient _httpClient;

    public CompilerManager(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<Result<CompiledInformationDto>?> SendRunAllTests(RunAllTestsRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.CompilerEndpoints.RunAllTests, request);
        return await response.Content.ReadFromJsonAsync<Result<CompiledInformationDto>>();
    }
}
