using Autofac;
using ChatServer.Logging;

public sealed class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MangosLogger>().As<IChatServerLogger>().SingleInstance();
    }
}