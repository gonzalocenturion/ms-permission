using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Permission.API.Infrastructure;
using Permission.Domain.Enums;
using System.Reflection;

namespace Permission.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
            c.UseInlineDefinitionsForEnums();

            c.MapType<PermissionTypes>(() => new OpenApiSchema
            {
                Type = "string",
                Enum = Enum.GetNames(typeof(PermissionTypes))
                           .Select(n => new OpenApiString(n))
                           .Cast<IOpenApiAny>()
                           .ToList()
            });
        });

        services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
        {
            options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
        });

        services.AddControllers();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}