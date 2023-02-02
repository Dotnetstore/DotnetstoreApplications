using Dotnetstore.Intranet.WebUI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;

//services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
Dotnetstore.Intranet.WebUI.IoC.BootstrapIServiceCollection.Build(ref services, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();