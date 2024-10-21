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


        var scope = container.BeginLifetimeScope();

        var configurationModule = scope.Resolve<ServerConfiguration>();
        ServerLogger serverLogger = new ServerLogger(configurationModule);

        var factory = serverLogger.CreateLogger();
            

        var moduleLogger = scope.Resolve<Logger>();
        moduleLogger.CreateLogger(factory);

        var tcpService = scope.Resolve<TcpServer>();
        TcpServer.Start();

        Engine.SetContainer(container);

        moduleLogger.Info("Server Start!");

        Console.ReadLine();
    }
}