using ChatServer.Logging;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Autofac.Core.Lifetime;

namespace ChatServer.Network;

public class TcpServer
{
    private readonly IChatLogger _logger;

    public TcpServer(IChatLogger logger)
    {
        _logger = logger;
    }

    public async Task RunAsync(string endpoint, CancellationToken cancellationToken = default)
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(IPEndPoint.Parse(endpoint));
        socket.Listen(10);

        _logger.ConsoleLog($"Tcp server was started on {endpoint}");

        while (!cancellationToken.IsCancellationRequested)
        {
            HandleClientConnection(await socket.AcceptAsync(cancellationToken), cancellationToken);
        }
    }

    private async void HandleClientConnection(Socket socket, CancellationToken cancellationToken)
    {
        if (socket.RemoteEndPoint is not IPEndPoint endpoint)
        {
            _logger.ConsoleLog("Unable to get remote endpoint");
            return;
        }

        _logger.ConsoleLog($"Tcp client was conntected {endpoint}");
        try
        {
            //using var scope = lifetimeScope.BeginLifetimeScope();
            //var tcpConnection = scope.Resolve<ITcpConnection>();
            //await tcpConnection.ExecuteAsync(socket, cancellationToken);
        }
        catch (SocketException exception) when (exception.SocketErrorCode == SocketError.ConnectionAborted)
        {
            _logger.ConsoleLog("Connection aborted");
        }
        catch (Exception e)
        {
            _logger.ConsoleLog($"{e} Unhandled exception");
        }
        finally
        {
            socket.Dispose();
        }

        _logger.ConsoleLog($"Tcp client was disconected");
    }
}
