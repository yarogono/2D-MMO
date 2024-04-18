using Autofac;

namespace ChatServer.Logging;

public sealed class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ChatLogger>().As<IChatLogger>().SingleInstance();
    }
}
