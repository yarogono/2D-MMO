using Logging;
using System.Net;
using Tcp;

namespace Server.Session
{
    public class ClientSession : PacketSession
    {
        public int SessionId { get; set; }

        private readonly IServerLogger _logger;

        public ClientSession(IServerLogger logger) : base(logger)
        {
        }

        public override void OnConnected(EndPoint endPoint)
        {
            _logger.Info($"OnConnected : {endPoint}");
            //GameLogic.Instance.PushAfter(5000, Ping);
        }

        public override void OnDisconnected(EndPoint endPoint)
        {
            SessionManager.Instance.Remove(this);

            _logger.Info($"OnDisconnected : {endPoint}");
        }

        public override void OnRecvPacket(ArraySegment<byte> buffer)
        {
            //PacketManager.Instance.OnRecvPacket(this, buffer);
        }

        public override void OnSend(int numOfBytes)
        {
            _logger.Info($"Transferred bytes: {numOfBytes}");
        }
    }
}
