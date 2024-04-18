using Autofac;
using ChatServer.Logging;

namespace ExcelToJson;

public class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();

        builder.RegisterModule<LoggingModule>();


        var container = builder.Build();
        var logger = container.Resolve<IChatLogger>();


        logger.ConsoleLog("Chat Server");
    }
}