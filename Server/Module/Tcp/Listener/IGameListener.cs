using System.Net;

namespace Tcp.Listener
{
    public interface IGameListener
    {
        public void Init<T>(IPEndPoint endPoint, Func<Session> sessionFactory, T logger, int register = 10, int backlog = 100);
    }
}
