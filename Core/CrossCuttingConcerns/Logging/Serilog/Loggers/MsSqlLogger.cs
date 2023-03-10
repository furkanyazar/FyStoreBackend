using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MsSqlLogger : LoggerServiceBase
{
    public MsSqlLogger(IConfiguration configuration)
    {
        var logConfig =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string conString = logConfig.ConnectionString;
        string tableName = logConfig.TableName;

        Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(tableName: tableName,
                                 connectionString: conString,
                                 autoCreateSqlTable: true)
            .CreateLogger();
    }
}