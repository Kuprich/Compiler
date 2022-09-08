namespace Compiler.Client.Infrastructure.Managers.CompilerManager;

using Compiler.Application.Features.Compiler.RunAllTests;
using Compiler.Client.Infrastructure.Result;
using System.Net.Http.Json;

public class CompilerManager
{
    private readonly HttpClient _httpClient;

    public CompilerManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Result<CompiledInformationDto>> RunAllTests(RunAllTestsCommand command)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.CompilerEndpoints.RunAllTests, command);

        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<CompiledInformationDto>();

            return Result<CompiledInformationDto>.Succeess(data!);
        }

        var error = await response.Content.ReadFromJsonAsync<ResultError>();


        return Result<CompiledInformationDto>.Fail(error);
    }
}