using Autofac;

namespace ChatServer.Network;

public class TcpModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TcpServer>().SingleInstance();
    }
}
