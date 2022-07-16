using Blazor.Extensions.Logging;
using Blazored.SessionStorage;
using Havit.Blazor.Components.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using UI;
using UI.Interfaces;

JsonConvert.DefaultSettings =
    () => new JsonSerializerSettings
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Converters = { new StringEnumConverter() }
    };

var refitSettings = new RefitSettings
{
    ContentSerializer = new NewtonsoftJsonContentSerializer()
};

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHxServices();

builder.Services.AddLogging(x => x.AddBrowserConsole()
    .SetMinimumLevel(LogLevel.Trace));

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddRefitClient<IAccountApi>(refitSettings).ConfigureHttpClient(ConfigureHttpClient);

await builder.Build().RunAsync();

void ConfigureHttpClient(IServiceProvider serviceProvider, HttpClient httpClient)
{
    httpClient.BaseAddress = new Uri("http://localhost:5000/api");
}