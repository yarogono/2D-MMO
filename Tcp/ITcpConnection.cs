using System.Net.Sockets;

namespace ChatServer.Network;

public interface ITcpConnection
{
    Task ExecuteAsync(Socket socket, CancellationToken cancellationToken);
}
