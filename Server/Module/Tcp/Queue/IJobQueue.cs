namespace Tcp.Queue
{
    public interface IJobQueue
    {
        void Push(Action job);
    }
}
