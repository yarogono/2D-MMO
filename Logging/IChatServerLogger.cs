namespace ChatServer.Logging;

public interface IChatServerLogger
{
    void Trace(string message);
    void Trace(Exception exception, string message);

    void Information(string message);
    void Information(Exception exception, string message);

    void Warning(string message);
    void Warning(Exception exception, string message);

    void Error(string message);
    void Error(Exception exception, string message);
}