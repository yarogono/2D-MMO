using Microsoft.Extensions.Logging;
using System.Net;
using System.Numerics;
using Tcp;

namespace Server.Session
{
    public class ClientSession : PacketSession
    {
        public int SessionId { get; set; }

        public ClientSession(ILogger<Tcp.Session> logger) : base(logger)
        {
        }

        public override void OnConnected(EndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public override void OnDisconnected(EndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public override void OnRecvPacket(ArraySegment<byte> buffer)
        {
        }

        public override void OnSend(int numOfBytes)
        {
            Console.WriteLine($"Transferred bytes: {numOfBytes}");
        }
    }
}
