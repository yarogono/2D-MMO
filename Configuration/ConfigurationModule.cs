using Autofac;

namespace ChatServer.Configuration;

public class ConfigurationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context => new ConfigurationLoader().GetChatServerConfiguration()).SingleInstance();
    }
}