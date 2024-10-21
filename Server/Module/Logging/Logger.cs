using Microsoft.Extensions.Logging;

namespace Logging;

public class Logger : IServerLogger
{
    private ILogger<Logger> _logger;

    public void CreateLogger(ILoggerFactory loggerFactory)
    {
        if (_logger != null)
            return;

        _logger = loggerFactory.CreateLogger<Logger>();
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
