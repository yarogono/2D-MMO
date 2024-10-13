using Server.Configuration;
using Microsoft.Extensions.Logging;
using ZLogger;
using ZLogger.Providers;

namespace Logging;

public class ServerLogger : IServerLogger
{
    private readonly ServerConfiguration _chatServerConfiguration;

    private ILogger<ServerLogger> _logger;

    public void CreateLogger()
    {
        if (_logger != null)
            return;

        ILoggerFactory factory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Trace);
            logging.AddZLoggerFile(_chatServerConfiguration.LogFilePath);
            logging.AddZLoggerRollingFile(options =>
            {
                // File name determined by parameters to be rotated
                options.FilePathSelector = (timestamp, sequenceNumber) => $"logs/{timestamp.ToLocalTime():yyyy-MM-dd}_{sequenceNumber:000}.log";
                // The period of time for which you want to rotate files at time intervals.
                options.RollingInterval = RollingInterval.Day;
                // Limit of size if you want to rotate by file size. (KB)
                options.RollingSizeKB = 1024;
            });
            // Add ZLogger provider to ILoggingBuilder
            logging.AddZLoggerConsole(options =>
            {
                options.UseJsonFormatter(formatter =>
                {
                    formatter.IncludeProperties = IncludeProperties.ParameterKeyValues;
                });
            });
            // Output Structured Logging, setup options
            // logging.AddZLoggerConsole(options => options.UseJsonFormatter());
        });

        _logger = factory.CreateLogger<ServerLogger>();
    }

    public void Error(string message)
    {
        Console.WriteLine(message);
    }

    public void Info(string message)
    {
        Console.WriteLine(message);
    }

    public void Warn(string message)
    {
        Console.WriteLine(message);
    }
}
