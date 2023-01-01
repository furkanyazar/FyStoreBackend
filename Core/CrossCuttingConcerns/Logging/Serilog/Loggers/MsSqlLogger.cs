using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Logging.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MsSqlLogger : LoggerServiceBase
{
    public MsSqlLogger(IConfiguration configuration)
    {
        var logConfig =
            configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration").Get<MsSqlConfiguration>()
            ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string conString = configuration.GetConnectionString("FyStoreConnectionString");
        string tableName = logConfig.TableName;

        var colOpts = new ColumnOptions();
        colOpts.Store.Remove(StandardColumn.MessageTemplate);
        colOpts.Store.Remove(StandardColumn.Properties);

        Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(tableName: tableName,
                                 connectionString: conString,
                                 autoCreateSqlTable: true,
                                 columnOptions: colOpts)
            .CreateLogger();
    }
}