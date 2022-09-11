using Compiler.Application.Features.Practice.GetAllPracticeHeadings;
using Compiler.Application.Features.Practice.GetPracticeCard;
using Compiler.Shared.Wrapper;
using System.Net.Http.Json;

namespace Compiler.Client.Infrastructure.Managers;

public class PracticeManager
{
    private readonly HttpClient _httpClient;
    public PracticeManager(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<Result<PracticesDto>?> SendGetAllPractices()
    {
        var response = await _httpClient.GetAsync(Routes.PracticeEndpoints.GetAllPractices);
        return await response.Content.ReadFromJsonAsync<Result<PracticesDto>>();
    }

    public async Task<Result<PracticeCardDto>?> SendGetPracticeCardAsync(Guid id)
    {
        var response = await _httpClient.GetAsync(Routes.PracticeEndpoints.GetPracticeCard(id));
        return await response.Content.ReadFromJsonAsync<Result<PracticeCardDto>>();
    }
}