using Compiler.Application.Compiler.RunTests;
using MediatR;
using System.Net.Http;
using System.Net.Http.Json;

namespace Compiler.UI.Common;

internal class Sender
{
    private readonly HttpClient _httpClient;

    public Sender(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
        
    public async Task<TResult?> SendPostAsJsonAsync<TResult>(string requestUri, object request)
    {
        var response = await _httpClient.PostAsJsonAsync(requestUri, request);
        return await ExtractResultFromResponse<TResult>(response);
    }
    public async Task<TResult?> SendGetAsync<TResult>(string requestUri)
    {
        var response = await _httpClient.GetAsync(requestUri);
        return await ExtractResultFromResponse<TResult>(response);
    }
    private async Task<TResult?> ExtractResultFromResponse<TResult>(HttpResponseMessage response)
    {
        try
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TResult>();
            }
            else
            {
                var message = await response.Content.ReadAsStringAsync();
                throw new Exception($"Http status code: {response.StatusCode} Message: {message}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
