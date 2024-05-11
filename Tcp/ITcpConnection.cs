using System.Net.Sockets;

namespace ChatServer.Tcp;

public interface ITcpConnection
{
    Task ExecuteAsync(Socket socket, CancellationToken cancellationToken);
}
