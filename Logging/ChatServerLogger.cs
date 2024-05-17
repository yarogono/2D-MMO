namespace ChatServer.Logging;

internal sealed class MangosLogger : IChatServerLogger
{
    public void Error(string message)
    {
        Log(message, ConsoleColor.Red);
    }

    public void Error(Exception exception, string message)
    {
        Log(exception, message, ConsoleColor.Red);
    }

    public void Information(string message)
    {
        Log(message, ConsoleColor.White);
    }

    public void Information(Exception exception, string message)
    {
        Log(exception, message, ConsoleColor.White);
    }

    public void Trace(string message)
    {
        Log(message, ConsoleColor.Gray);
    }

    public void Trace(Exception exception, string message)
    {
        Log(exception, message, ConsoleColor.Gray);
    }

    public void Warning(string message)
    {
        Log(message, ConsoleColor.Yellow);
    }

    public void Warning(Exception exception, string message)
    {
        Log(message, ConsoleColor.Yellow);
    }

    private void Log(string message, ConsoleColor color)
    {
        lock (this)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay}: {message}");
        }
    }

    private void Log(Exception exception, string message, ConsoleColor color)
    {
        lock (this)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"{DateTime.UtcNow.TimeOfDay}: {message}");
            Console.WriteLine(exception);
        }
    }
}