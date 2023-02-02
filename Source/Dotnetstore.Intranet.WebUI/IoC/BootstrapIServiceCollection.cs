using MudBlazor.Services;

namespace Dotnetstore.Intranet.WebUI.IoC;

public static class BootstrapIServiceCollection
{
    internal static void Build(ref IServiceCollection serviceCollection)
    {
        serviceCollection.AddMudServices();
    }
}