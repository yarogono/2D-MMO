using Autofac;

namespace Tcp;

public class TcpModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TcpServer>().SingleInstance();
    }
}
