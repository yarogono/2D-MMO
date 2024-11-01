using Logging;
using Microsoft.Extensions.Logging;

namespace Server.Session
{
    internal class ClientSessionFactory : IClientSessionFactory
    {
        private readonly IServerLogger _logger;

        public ClientSessionFactory(IServerLogger logger)
        {
            _logger = logger;
        }

        public ClientSession Create()
        {
            return new ClientSession(_logger);
        }
    }
}
