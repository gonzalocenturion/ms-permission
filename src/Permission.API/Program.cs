using Permission.API;
using Permission.API.Extensions;
using Permission.APIExtensions;
using Permission.Application;
using Permission.Infrastructure;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


builder.Services
    .AddApplication()
    .AddPresentation()
    .AddInfraestructure(builder.Configuration);

builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

WebApplication app = builder.Build();

app.MapEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.MapControllers();

await app.RunAsync();

namespace Permission.API
{
    public partial class Program;
}