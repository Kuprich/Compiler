namespace Compiler.Client.Infrastructure.Managers.CompilerManager;

public class CompilerManager
{
    private readonly HttpClient _httpClient;

    public CompilerManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public async Task<IResult<CompiledInformationResponse>> GetDataAsync()
    //{
    //    //var response = await _httpClient.GetAsync(Routes.CompilerEndpoints.RunAllTests);
    //    //var data = await response.ToResult<DashboardDataResponse>();
    //    ////return data;
    //}
}
