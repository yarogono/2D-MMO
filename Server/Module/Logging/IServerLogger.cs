namespace Logging;

public interface IServerLogger
{
    public void Info(string message);
    public void Error(string message);
    public void Warn(string message);
}
