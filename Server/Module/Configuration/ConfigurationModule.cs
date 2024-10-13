using Autofac;

namespace Server.Configuration;

public class ConfigurationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(context => new ConfigurationLoader().GetServerConfiguration()).SingleInstance();
        Console.WriteLine("Configuration Module Ready");
    }
}