using System.Net.Sockets;
using System.Net;
using Autofac;
using ChatServer.Logging;

namespace ChatServer.Tcp;

public class TcpServer
{
    private readonly IChatServerLogger _logger;
    private readonly ILifetimeScope _lifetimeScope;

    public TcpServer(IChatServerLogger logger, ILifetimeScope lifetimeScope)
    {
        _logger = logger;
        _lifetimeScope = lifetimeScope;
    }

    public async Task RunAsync(string endpoint, int backlog = 10, CancellationToken cancellationToken = default)
    {
        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Bind(IPEndPoint.Parse(endpoint));
        socket.Listen(backlog);

        _logger.Information($"Tcp server was started on {endpoint}");

        while (!cancellationToken.IsCancellationRequested)
        {
            HandleClientConnection(await socket.AcceptAsync(cancellationToken), cancellationToken);
        }
    }

    private async void HandleClientConnection(Socket socket, CancellationToken cancellationToken)
    {
        if (socket.RemoteEndPoint is not IPEndPoint endpoint)
        {
            _logger.Error("Unable to get remote endpoint");
            return;
        }

        _logger.Information($"Tcp client was conntected {endpoint}");
        try
        {
            using var scope = _lifetimeScope.BeginLifetimeScope();
            var tcpConnection = scope.Resolve<ITcpConnection>();
            await tcpConnection.ExecuteAsync(socket, cancellationToken);
        }
        catch (SocketException exception) when (exception.SocketErrorCode == SocketError.ConnectionAborted)
        {
            _logger.Error("Connection aborted");
        }
        catch (Exception e)
        {
            _logger.Error($"{e} Unhandled exception");
        }
        finally
        {
            socket.Dispose();
        }

        _logger.Information($"Tcp client was disconected");
    }
}