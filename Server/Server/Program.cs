using Autofac;
using Server.Configuration;
using Logging;
using Tcp;
using Server.Data;

namespace Server;

public class Program
{
    internal static ServerOption ServerOpt { get; private set; }

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
        builder.RegisterModule<ServerModule>();

        var container = builder.Build();
        Engine.SetContainer(container);

        var configurationModule = Engine.Resolve<ServerConfiguration>();
        GameServerLogger serverLogger = new GameServerLogger(configurationModule);

        var factory = serverLogger.CreateLogger();

        var moduleLogger = Engine.Resolve<IServerLogger>();
        moduleLogger.CreateLogger(factory);


        DataManager.LoadData();

        ServerOpt = new();

        var networkService = container.Resolve<INetworkService>();
        networkService.Star();

        ServerOpt.WriteConsole();
        Console.ReadLine();
    }
}