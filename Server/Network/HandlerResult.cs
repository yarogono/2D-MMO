using System.Buffers;

namespace Server.Network;

internal sealed class HandlerResult : IDisposable
{
    private readonly IResponseMessage[] messages;
    private readonly int length;

    private HandlerResult(IResponseMessage[] messages, int length)
    {
        this.messages = messages;
        this.length = length;
    }

    public static HandlerResult From(IResponseMessage responseMessage)
    {
        var memoryOwner = ArrayPool<IResponseMessage>.Shared.Rent(1);
        memoryOwner[0] = responseMessage;
        return new HandlerResult(memoryOwner, 1);
    }

    public static Task<HandlerResult> FromTask(IResponseMessage responseMessage)
    {
        return Task.FromResult(From(responseMessage));
    }

    public IEnumerable<IResponseMessage> GetResponseMessages()
    {
        return messages.Take(length);
    }

    public void Dispose()
    {
        ArrayPool<IResponseMessage>.Shared.Return(messages);
    }
}