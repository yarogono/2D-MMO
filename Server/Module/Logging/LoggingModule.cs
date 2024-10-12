using Autofac;
using ChatServer.Configuration;

namespace Logging;

public class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context => new ConfigurationLoader().GetChatServerConfiguration()).SingleInstance();
        Console.WriteLine("Logging Module Ready");
    }
}
