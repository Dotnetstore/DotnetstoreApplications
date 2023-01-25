using Dotnetstore.Business.Repositories;
using Dotnetstore.Business.Services;
using Dotnetstore.Business.Wrappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Business.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IBusinessEntityRepository, BusinessEntityRepository>();
        serviceCollection.AddSingleton<IBusinessEntityService, BusinessEntityService>();
        serviceCollection.AddSingleton<IBusinessEntityWrapper, BusinessEntityWrapper>();

        serviceCollection.AddSingleton<IOwnCompanyRepository, OwnCompanyRepository>();
        serviceCollection.AddSingleton<IOwnCompanyService, OwnCompanyService>();
        serviceCollection.AddSingleton<IOwnCompanyWrapper, OwnCompanyWrapper>();

        serviceCollection.AddDbContextFactory<BusinessContext>(q => q.UseSqlServer(configuration.GetSection("ConnectionStrings:DotnetstoreIntranetConnectionString").Value));
    }
}