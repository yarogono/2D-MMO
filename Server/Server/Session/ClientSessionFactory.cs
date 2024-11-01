using Microsoft.Extensions.Logging;

namespace Server.Session
{
    internal class ClientSessionFactory : IClientSessionFactory
    {
        private readonly ILogger<Tcp.Session> _logger;

        public ClientSessionFactory(ILogger<Tcp.Session> logger)
        {
            _logger = logger;
        }

        public ClientSession Create()
        {
            return new ClientSession(_logger);
        }
    }
}
