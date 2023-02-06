using Dotnetstore.Core.Interfaces;
using Dotnetstore.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnetstore.Core.IoC;

public static class BootstrapIServiceCollection
{
    public static void Build(ref IServiceCollection serviceCollection, string baseAddress)
    {
        //serviceCollection.AddSingleton<IHttpService, HttpService>();

        serviceCollection.AddHttpClient<IHttpService, HttpService>("HttpService", client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });
    }
}