using Dotnetstore.Business.Service.OwnCompanies;
using Dotnetstore.Intranet.Contract.Business;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Business.Service.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IOwnCompanyService, OwnCompanyService>();
        serviceCollection.AddSingleton<IOwnCompanyWrapper, OwnCompanyWrapper>();
    }
}