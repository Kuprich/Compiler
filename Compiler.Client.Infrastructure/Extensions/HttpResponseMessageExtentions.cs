using Compiler.Client.Infrastructure.Result;
using System.Net.Http.Json;

namespace Compiler.Client.Infrastructure.Extensions;

internal static class HttpResponseMessageExtentions
{
    public static async Task<Result<T>> ToResultAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadFromJsonAsync<T>();

            return Result<T>.Succeess(data);
        }

        var error = await response.Content.ReadFromJsonAsync<ResultError>();

        return Result<T>.Fail(error);
    }
}
