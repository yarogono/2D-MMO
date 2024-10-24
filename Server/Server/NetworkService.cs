using Server;
using System.Net;
using Tcp.Listener;

public class NetworkService : INetworkService
{
    IListener ClientListener;

    public NetworkService(IListener listener)
    {
        ClientListener = listener;
    }

    public void Star()
    {
        string host = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(host);
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint endPoint = new IPEndPoint(ipAddr, Program.ServerOpt.Port);

        //ClientListener.Init(endPoint, () => { return SessionManager.Instance.Generate(); }, Program.ServerOpt.MaxConnectionCount);
    }

}
