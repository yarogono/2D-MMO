using Autofac;
using ChatServer.Configuration;
using ChatServer.Logging;
using ChatServer.Network;

namespace ExcelToJson;

public class Program
{
    static async void Main(string[] args)
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();

        builder.RegisterModule<LoggingModule>();
        builder.RegisterModule<TcpModule>();
        builder.RegisterModule<ConfigurationModule>();

        var container = builder.Build();
        var configuration = container.Resolve<ChatServerConfiguration>();
        var logger = container.Resolve<IChatLogger>();
        var tcpServer = container.Resolve<TcpServer>();

        logger.ConsoleLog("Start Chat Server");

        await tcpServer.RunAsync(configuration.ChatServerEndpoint);
    }
}