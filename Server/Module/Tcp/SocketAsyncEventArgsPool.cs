using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcp
{
    public class SocketAsyncEventArgsPool
    {
        ConcurrentBag<SocketAsyncEventArgs> Pool = new();

        public void Push(SocketAsyncEventArgs arg)
        {
            Pool.Add(arg);
        }

        public SocketAsyncEventArgs Pop()
        {
            if (Pool.TryTake(out var result))
            {
                return result;
            }

            return null;
        }
    }
}
