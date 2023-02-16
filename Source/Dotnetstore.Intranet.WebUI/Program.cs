using Dotnetstore.Intranet.WebUI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;

Dotnetstore.Intranet.WebUI.IoC.BootstrapIServiceCollection.Build(ref services, builder.Configuration);

await builder.Build().RunAsync();