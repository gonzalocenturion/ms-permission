using KafkaFlow;
using KafkaFlow.Serializer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Permission.Application.Abstraction.EventBus;
using Permission.Domain.Events;
using Permission.Domain.Repository;
using Permission.Infrastructure.Database;
using Permission.Infrastructure.EventBus;
using Permission.Infrastructure.Repository;

namespace Permission.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration)
                .AddConfigurationServices()
                .AddKakfaBus(configuration);

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("Database");

        services.AddDbContextPool<PermissionDbContext>(
            options => options
                .UseSqlServer(connectionString, mssqlOpt =>
                    mssqlOpt.MigrationsHistoryTable(HistoryRepository.DefaultTableName)));

        return services;
    }

    private static IServiceCollection AddConfigurationServices(this IServiceCollection services)
    {
        services.AddTransient<IPermissionRepository, PermissionRepository>();
        services.AddTransient<IWrapperRepository, WrapperRepository>();
        services.AddSingleton<IEventBus, KafkaEventBus>();

        return services;
    }

    private static IServiceCollection AddKakfaBus(this IServiceCollection services, IConfiguration configuration)
    {
        var kafkaHost = configuration.GetSection("KafkaHost").Value;
        services.AddKafka(kafka => kafka
           .AddCluster(cluster => cluster
               .WithBrokers(new[] { kafkaHost })
               .AddProducer<OperationProducer>(producer => producer.DefaultTopic("permission-topics")
                                                                   .AddMiddlewares(m => m.AddSerializer<JsonCoreSerializer>()
               )
           )));

        return services;
    }
}