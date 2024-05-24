using Autofac;

namespace ChatServer;

public class Program
{

    static void Main(string[] args)
    {
        Run();
    }

    static async void Run()
    {
        Console.Title = "Chat Server";

        var builder = new ContainerBuilder();
    }
}