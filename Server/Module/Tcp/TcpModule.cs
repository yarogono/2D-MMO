using Autofac;
using Logging;

namespace Tcp;

public class TcpModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ServerLogger>().As<IServerLogger>().SingleInstance();
        Console.WriteLine("TCP Module Ready");
    }
}
