using Autofac;
using ChatServer.Configuration;
using ChatServer.Logging;
using ChatServer.Tcp;

namespace ChatServer;

public class Program
{

    static void Main(string[] args)
    {
        Run();
    }

    // Autofac DI를 사용해서 서버에 필요한 객체들을 모듈화
    // ContainerBuilder를 사용해서 DI 컨테이너 설정
    // 서버에 필요한 객체를 모듈화해서 의존성을 해결
    static async void Run()
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();

        builder.RegisterModule<LoggingModule>();
        builder.RegisterModule<TcpModule>();
        builder.RegisterModule<ConfigurationModule>();

        var container = builder.Build();
        var configuration = container.Resolve<ChatServerConfiguration>();
        var logger = container.Resolve<IChatServerLogger>();
        var tcpServer = container.Resolve<TcpServer>();

        //logger.CreateLogger();

        logger.Information("Start Chat Server");

        await tcpServer.RunAsync(configuration.ChatServerEndpoint);
    }
}