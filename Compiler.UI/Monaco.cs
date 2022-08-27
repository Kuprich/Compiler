using Microsoft.JSInterop;

namespace Compiler.UI;

public class Monaco
{
    private readonly IJSRuntime _jsRuntime;

    public Monaco(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public async Task InitializeAsync(string elementId, string initialCode, string language) =>
        await _jsRuntime.InvokeAsync<object>("monacoInterop.initialize", elementId, initialCode, language);

    public async Task<string> GetCodeAsync(string elementId) => await _jsRuntime.InvokeAsync<string>("monacoInterop.getCode", elementId);

    public async Task SetCodeAsync(string elementId, string code) => await _jsRuntime.InvokeVoidAsync("monacoInterop.setCode", elementId, code);
}
