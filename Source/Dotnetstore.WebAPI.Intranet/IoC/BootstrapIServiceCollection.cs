namespace Dotnetstore.WebAPI.Intranet.IoC;

internal class BootstrapIServiceCollection
{
    internal static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Dotnetstore.UnitOfWorks.Intranet.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);
    }
}