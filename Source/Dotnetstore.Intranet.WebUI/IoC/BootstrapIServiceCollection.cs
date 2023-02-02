using Microsoft.Net.Http.Headers;
using MudBlazor.Services;

namespace Dotnetstore.Intranet.WebUI.IoC;

public static class BootstrapIServiceCollection
{
    internal static void Build(ref IServiceCollection serviceCollection, string dotnetstoreIntranetBaseAddress)
    {
        serviceCollection.AddMudServices();
        serviceCollection.AddHttpClient("DotnetstoreIntranet", httpClient =>
        {
            httpClient.BaseAddress = new Uri(dotnetstoreIntranetBaseAddress);
            httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        });
        serviceCollection.AddLocalization();
    }
}