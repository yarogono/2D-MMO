using Autofac;
using Server.Configuration;
using Logging;
using Server;
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

        var configuration = builder.RegisterModule<ConfigurationModule>();
        var logger = builder.RegisterModule<LoggingModule>();
        var tcp = builder.RegisterModule<TcpModule>();

        var container = builder.Build();

        Engine.SetContainer(container);

        Console.WriteLine("Server Start!");
    }
}