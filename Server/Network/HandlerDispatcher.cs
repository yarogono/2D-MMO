using Server.Handlers;

namespace Server.Network;

public sealed class HandlerDispatcher<TRequest, THandler> : IHandlerDispatcher
    //where TRequest : IRequestMessage<TRequest>
    //where THandler : IHandler<TRequest>
{
    private readonly THandler handler;

    public HandlerDispatcher(THandler handler)
    {
        this.handler = handler;
    }

    public Opcodes Opcode => TRequest.Opcode;

    public Task<HandlerResult> ExectueAsync(PacketReader reader)
    {
        return handler.ExectueAsync(TRequest.Read(reader));
    }
}
