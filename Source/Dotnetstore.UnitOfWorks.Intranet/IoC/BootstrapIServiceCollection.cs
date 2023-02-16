using Dotnetstore.UnitOfWorks.Intranet.Interfaces;
using Dotnetstore.UnitOfWorks.Intranet.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.UnitOfWorks.Intranet.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Dotnetstore.Core.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);
        Dotnetstore.Business.Repository.EF.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);
        Dotnetstore.Business.Service.IoC.BootstrapIServiceCollection.Build(ref serviceCollection);

        serviceCollection.AddSingleton<IBusinessWrapper, BusinessWrapper>();
        serviceCollection.AddSingleton<IUnitOfWorks, Services.UnitOfWorks>();
    }
}