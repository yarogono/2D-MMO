using Autofac;

namespace Logging;

public class LoggingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context => new ConfigurationLoader().GetChatServerConfiguration()).SingleInstance();
    }
}
