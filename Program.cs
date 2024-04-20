using Autofac;
using ChatServer.Logging;
using ChatServer.Network;

namespace ExcelToJson;

public class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();

        builder.RegisterModule<LoggingModule>();
        builder.RegisterModule<TcpModule>();

        var container = builder.Build();
        var logger = container.Resolve<IChatLogger>();
        var tcpServer = container.Resolve<TcpServer>();

        logger.ConsoleLog("Start Chat Server");
    }
}