namespace ChatServer.Logging;

public interface IChatLogger
{
    void CreateLogger();
    void ConsoleLog(string message);
    void Error(string message);
}
