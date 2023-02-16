using Dotnetstore.UnitOfWorks.Intranet.Frontend.Businesses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.UnitOfWorks.Intranet.Frontend.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        Dotnetstore.Core.IoC.BootstrapIServiceCollection.Build(ref serviceCollection, configuration);

        serviceCollection.AddSingleton<IUnitOfWork, UnitOfWork>();

        serviceCollection.AddSingleton<IBusinessService, BusinessService>();
        serviceCollection.AddSingleton<IOwnCompanyService, OwnCompanyService>();
    }
}