using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Permission.Domain.Repository;
using Permission.Infrastructure.Database;
using Permission.Infrastructure.Repository;

namespace Permission.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration)
                .AddConfigurationServices();

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
        return services;
    }
}