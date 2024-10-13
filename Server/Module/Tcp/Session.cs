using System.Net.Sockets;

namespace Tcp
{
    public abstract class Session
    {
        Socket _socket;
        int _disconnected = 0;


        public SocketAsyncEventArgs ReceiveEventArgs { get; private set; }
        public SocketAsyncEventArgs SendEventArgs { get; private set; }

        void Clear()
        {

        }


    }
}
