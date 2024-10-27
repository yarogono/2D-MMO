using Autofac;

namespace Logging;

public class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ServerLogger>().As<IServerLogger>().SingleInstance();
        Console.WriteLine("Logging Module Ready");
    }
}
