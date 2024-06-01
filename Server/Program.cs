using Autofac;
using ChatServer.Configuration;
using Logging;
using Tcp;

namespace ChatServer;

public class Program
{

    static void Main(string[] args)
    {
        Run();
    }

    static async void Run()
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();

        var configuration = builder.RegisterModule<ConfigurationModule>();
        var logger = builder.RegisterModule<LoggingModule>();
        var tcp = builder.RegisterModule<TcpModule>();
    }
}