using Autofac;
using Tcp.Listener;

namespace Server
{
    internal class ServerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameListener>().As<IGameListener>().SingleInstance();
            builder.RegisterType<NetworkService>().As<INetworkService>().InstancePerLifetimeScope();
        }
    }
}
