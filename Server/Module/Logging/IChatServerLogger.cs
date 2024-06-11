namespace Logging;

public interface IChatServerLogger
{
    public void Info(string message);
    public void Error(string message);
    public void Warn(string message);
}
