using System;

namespace ChatServer.Logging;

public class ChatLogger : IChatLogger
{
    public void ConsoleLog(string message)
    {
        Console.WriteLine(message);
    }
}
