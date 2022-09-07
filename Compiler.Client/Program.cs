using Compiler.Client;
using Compiler.Client.Common;
using Compiler.Client.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<Monaco>();
builder.Services.AddTransient<Sender>();
builder.Services.AddClientInfrastructure();

await builder.Build().RunAsync();
