using Autofac;
using Server.Configuration;
using Logging;
using Tcp;

namespace Server;

public class Program
{

    static void Main(string[] args)
    {
        RunServer();
    }

    static async void RunServer()
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();

        builder.RegisterModule<ConfigurationModule>();
        builder.RegisterModule<LoggingModule>();
        builder.RegisterModule<TcpModule>();

        var container = builder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            var serverLogger = scope.Resolve<ServerLogger>();
            serverLogger.CreateLogger();

            var tcpService = scope.Resolve<TcpServer>();
            TcpServer.Start();

        }

        Engine.SetContainer(container);

        Console.WriteLine("Server Start!");

        Console.ReadLine();
    }
}