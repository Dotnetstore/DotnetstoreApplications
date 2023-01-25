using Dotnetstore.UnitOfWorks.Intranet.Interfaces;
using Dotnetstore.UnitOfWorks.Intranet.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.UnitOfWorks.Intranet.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Dotnetstore.Business.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);

        serviceCollection.AddSingleton<IBusinessWrapper, BusinessWrapper>();
        serviceCollection.AddSingleton<IUnitOfWorks, Services.UnitOfWorks>();
    }
}