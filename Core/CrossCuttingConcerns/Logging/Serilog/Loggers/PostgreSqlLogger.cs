using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class PostgreSqlLogger : LoggerServiceBase
{
    public PostgreSqlLogger(IConfiguration configuration)
    {
        var logConfig =
            configuration.GetSection("SeriLogConfigurations:PostgreSqlConfiguration").Get<PostgreSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string conString = logConfig.ConnectionString;
        string tableName = logConfig.TableName;

        Logger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(tableName: tableName,
                                connectionString: conString,
                                needAutoCreateTable: true)
            .CreateLogger();
    }
}