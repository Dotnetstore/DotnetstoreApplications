using MudBlazor.Services;

namespace Dotnetstore.Intranet.WebUI.IoC;

public static class BootstrapIServiceCollection
{
    internal static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Dotnetstore.UnitOfWorks.Intranet.Frontend.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);

        serviceCollection.AddMudServices();
        //serviceCollection.AddHttpClient("DotnetstoreIntranet", httpClient =>
        //{
        //    httpClient.BaseAddress = new Uri(dotnetstoreIntranetBaseAddress);
        //    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
        //});
        serviceCollection.AddLocalization();
    }
}