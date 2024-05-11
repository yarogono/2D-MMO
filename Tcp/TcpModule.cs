using Autofac;

namespace ChatServer.Tcp;

public class TcpModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<TcpServer>().SingleInstance();
    }
}
