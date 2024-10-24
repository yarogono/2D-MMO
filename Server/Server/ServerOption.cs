using Microsoft.Extensions.Logging;

namespace Server
{
    public class ServerOption
    {
        public int Port { get; set; } = 7777;
        public int MaxConnectionCount { get; set; } = 500;
        public int ReceiveBufferSize { get; set; } = 4096;
        public int MaxPacketSize { get; set; } = 1024;

        public void WriteConsole()
        {
            Console.WriteLine("[ ServerOption ]\n" +
                                $"Port: {Port}\n" +
                                $"MaxConnectionCount: {MaxConnectionCount}\n" +
                                $"ReceiveBufferSize: {ReceiveBufferSize}\n" +
                                $"MaxPacketSize: {MaxPacketSize}\n" +
                                "Server Start!");
        }
    }
}
