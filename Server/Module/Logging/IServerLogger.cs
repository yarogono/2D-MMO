using Microsoft.Extensions.Logging;

namespace Logging;

public interface IServerLogger
{
    public void CreateLogger(ILoggerFactory loggerFactory);
    public void Info(string message);
    public void Error(string message);
    public void Warn(string message);
}
