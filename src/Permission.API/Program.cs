using KafkaFlow;
using Permission.API;
using Permission.API.Extensions;
using Permission.APIExtensions;
using Permission.Application;
using Permission.Infrastructure;
using Serilog;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfraestructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

WebApplication app = builder.Build();

app.MapEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.ApplyMigrations();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.MapControllers();

var kafkaBus = app.Services.CreateKafkaBus();
await kafkaBus.StartAsync();

await app.RunAsync();

namespace Permission.API
{
    public partial class Program;
}