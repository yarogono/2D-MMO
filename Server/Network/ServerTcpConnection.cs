using ChatServer.Tcp;
using System.Net.Sockets;

namespace Server.Network;

internal class ServerTcpConnection : ITcpConnection
{
    public Task ExecuteAsync(Socket socket, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
