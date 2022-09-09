using Compiler.Api.Contracts.Compiler.RunAllTests;
using Compiler.Client.Infrastructure.Extensions;
using Compiler.Client.Infrastructure.Result;
using System.Net.Http.Json;

namespace Compiler.Client.Infrastructure.Managers;

public class CompilerManager
{
    private readonly HttpClient _httpClient;

    public CompilerManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<RunAllTestsResponse>> RunAllTests(RunAllTestsRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.CompilerEndpoints.RunAllTests, request);

        return await response.ToResultAsync<RunAllTestsResponse>();
    }
}