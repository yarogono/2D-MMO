using Autofac;
using Server.Configuration;

namespace Logging;

public class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context => new ConfigurationLoader().GetServerConfiguration()).SingleInstance();
        Console.WriteLine("Logging Module Ready");
    }
}
