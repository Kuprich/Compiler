namespace Compiler.Client.Infrastructure.Managers.CompilerManager;

using Compiler.Application.Features.Compiler.RunAllTests;
using ErrorOr;
using System.Net.Http.Json;

public class CompilerManager
{
    private readonly HttpClient _httpClient;

    public CompilerManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ErrorOr<CompiledInformationDto>> RunAllTests(RunAllTestsCommand command)
    {
        var response = await _httpClient.PostAsJsonAsync(Routes.CompilerEndpoints.RunAllTests, command);

        CompiledInformationDto? result =  await response.Content.ReadFromJsonAsync<CompiledInformationDto>();

        return result;
    }

    //public async Task<ErrorOr>
    //{
    //    //var response = await _httpClient.GetAsync(Routes.CompilerEndpoints.RunAllTests);
    //    //var data = await response.ToResult<DashboardDataResponse>();
    //    ////return data;
    //}
}
