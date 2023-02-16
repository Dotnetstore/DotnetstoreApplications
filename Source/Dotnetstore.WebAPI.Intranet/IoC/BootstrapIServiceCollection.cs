using Dotnetstore.WebAPI.Intranet.Interfaces;
using Dotnetstore.WebAPI.Intranet.Services;

namespace Dotnetstore.WebAPI.Intranet.IoC;

internal class BootstrapIServiceCollection
{
    internal static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Dotnetstore.UnitOfWorks.Intranet.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);

        serviceCollection.AddSingleton<ISetupService, SetupService>();
    }
}