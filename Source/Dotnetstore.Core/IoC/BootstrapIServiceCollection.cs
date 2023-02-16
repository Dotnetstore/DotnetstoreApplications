using Dotnetstore.Core.Interfaces;
using Dotnetstore.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Core.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var baseAddress = configuration.GetSection("WebAPIs:DotnetstoreIntranet").Value;
        serviceCollection.AddSingleton<IPathService, PathService>();

        serviceCollection.AddHttpClient<IHttpService, HttpService>("HttpService", client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
    }
}