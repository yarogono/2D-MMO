using Microsoft.Extensions.Logging;

namespace Logging;

public class ServerLogger : IServerLogger
{
    private ILogger<ServerLogger> _logger;

    public void CreateLogger(ILoggerFactory loggerFactory)
    {
        if (_logger != null)
            return;

        _logger = loggerFactory.CreateLogger<ServerLogger>();
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
