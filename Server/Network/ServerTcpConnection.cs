using ChatServer.Tcp;
using System.Net.Sockets;

namespace Server.Network;

public class ServerTcpConnection : ITcpConnection
{
    public Task ExecuteAsync(Socket socket, CancellationToken cancellationToken)
    {
        return null;
    }
}
