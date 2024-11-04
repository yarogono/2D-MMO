using Server;
using Server.Session;
using System.Net;
using Tcp.Listener;

public class NetworkService : INetworkService
{
    private readonly IGameListener ClientListener;

    public NetworkService(IGameListener listener)
    {
        ClientListener = listener;
    }

    public void Star()
    {
        string host = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(host);
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint endPoint = new IPEndPoint(ipAddr, Program.ServerOpt.Port);

        ClientListener.Init(endPoint, () => { return SessionManager.Instance.Generate(); }, Program.ServerOpt.MaxConnectionCount);
    }

}
