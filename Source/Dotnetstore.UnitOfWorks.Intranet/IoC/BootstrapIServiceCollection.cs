using Dotnetstore.UnitOfWorks.Intranet.Interfaces;
using Dotnetstore.UnitOfWorks.Intranet.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.UnitOfWorks.Intranet.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Core.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);
        Business.Repository.EF.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);
        Business.Service.IoC.BootstrapIServiceCollection.Build(ref serviceCollection);

        serviceCollection.AddSingleton<IBusinessWrapper, BusinessWrapper>();
        serviceCollection.AddSingleton<IUnitOfWorks, Services.UnitOfWorks>();
        serviceCollection.AddSingleton<IUnitOfWorkSetupService, SetupService>();
    }
}