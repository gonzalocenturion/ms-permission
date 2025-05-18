using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace Permission.API.Extensions;

public static class LoggerConfigurationExtensions
{
    public static void ApplySerilogConfiguration(this LoggerConfiguration logger, IConfiguration configuration) 
    {
        logger.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
        {
            AutoRegisterTemplate = true,
            IndexFormat = "permission-service",
            NumberOfShards = 2,
            NumberOfReplicas = 1,
            MinimumLogEventLevel = Serilog.Events.LogEventLevel.Information,
            ModifyConnectionSettings = x => x.BasicAuthentication(configuration["ElasticConfiguration:User"], configuration["ElasticConfiguration:Password"])
        }).ReadFrom.Configuration(configuration);              
    }
}