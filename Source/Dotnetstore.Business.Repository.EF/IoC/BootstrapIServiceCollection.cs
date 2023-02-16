using Dotnetstore.Business.Repository.EF.Contexts;
using Dotnetstore.Business.Repository.EF.Services;
using Dotnetstore.Core.Interfaces;
using Dotnetstore.Intranet.Contract.Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Business.Repository.EF.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton<IOwnCompanyRepository, OwnCompanyRepository>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var pathService = serviceProvider.GetService<IPathService>();

        if (pathService is null)
        {
            return;
        }

        if (Convert.ToBoolean(configuration.GetSection("Databases:SQL:IsActive").Value))
        {
            serviceCollection.AddDbContextFactory<BusinessContext>(q =>
                q.UseSqlServer(configuration.GetSection("Databases:SQL:ConnectionString").Value));
        }

        if (Convert.ToBoolean(configuration.GetSection("Databases:SQLite:IsActive").Value))
        {
            serviceCollection.AddDbContextFactory<BusinessContext>(q =>
                q.UseSqlite("Data Source=" +
                    Path.Combine(
                        pathService.DatabaseFileFolder,
                        configuration.GetSection("Databases:SQLite:ConnectionString").Value)));
        }
    }
}