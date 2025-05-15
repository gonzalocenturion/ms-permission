using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Permission.Infrastructure.Database;

namespace Permission.Infrastructure;

public static class ServiceExtension
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabase(configuration);

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
}