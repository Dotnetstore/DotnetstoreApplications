using Dotnetstore.WebAPI.Intranet.Interfaces;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

services.AddCors(q =>
{
    q.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

Dotnetstore.WebAPI.Intranet.IoC.BootstrapIServiceCollection.Build(ref services, builder.Configuration);
var serviceProvider = services.BuildServiceProvider();
var setupService = serviceProvider.GetService<ISetupService>();

setupService.AddFolders();
await setupService.RunSetupAsync();

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(q =>
{
    q.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Dotnetstore Intranet API",
        Version = "v1",
        Description = "An API for Dotnetstore Intranet",
        TermsOfService = new Uri("https://www.google.se/"),
        Contact = new OpenApiContact
        {
            Name = "Hans Sjödin",
            Email = "hasse29@hotmail.com",
            Url = new Uri("https://www.dotnetstore.se/")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://mit-license.org/")
        }
    });
    q.ResolveConflictingActions(qq => qq.First());

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    q.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(q =>
    {
        q.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotnetstore Intranet API V1");
    });
}

app.UseCors(myAllowSpecificOrigins);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();