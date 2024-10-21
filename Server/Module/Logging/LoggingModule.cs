using Autofac;
using Server.Configuration;

namespace Logging;

public class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Logger>().SingleInstance();
        Console.WriteLine("Logging Module Ready");
    }
}
