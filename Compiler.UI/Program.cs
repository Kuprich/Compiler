using Compiler.UI;
using Compiler.UI.Common;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7069") });
builder.Services.AddScoped<Monaco>();
builder.Services.AddTransient<Sender>();

await builder.Build().RunAsync();
